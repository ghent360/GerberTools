using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace GerberLibrary.Core
{
    public class ComponentReference
    {
        public string name;
        public int sequence;

        private static char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public static ComponentReference parse(string str)
        {
            ComponentReference result = new ComponentReference();
            int seqLoc = str.IndexOfAny(digits);
            if (seqLoc < 0)
            {
                result.sequence = -1;
                result.name = str;
            }
            else
            {
                result.name = str.Substring(0, seqLoc);
                result.sequence = int.Parse(str.Substring(seqLoc), CultureInfo.InvariantCulture);
            }
            return result;
        }

        public override string ToString()
        {
            if (sequence < 0)
            {
                return name;
            }
            return String.Format(CultureInfo.InvariantCulture, "{0}{1}", name, sequence);
        }
    }

    public class ComponentLocation
    {
        public ComponentReference reference;
        public string value;
        public string package;
        public double x;
        public double y;
        public double rotation;
        public string layer;

        private static char[] KicadSeparator = { ' ' };

        public static ComponentLocation parseKicad(string kicadLine)
        {
            ComponentLocation result = new ComponentLocation();
            string[] components = kicadLine.Split(KicadSeparator, StringSplitOptions.RemoveEmptyEntries);
            if (components.Length != 7)
            {
                throw new InvalidOperationException("Expected 7 values");
            }
            result.reference = ComponentReference.parse(components[0]);
            result.value = components[1];
            result.package = components[2];
            result.x = double.Parse(components[3], CultureInfo.InvariantCulture);
            result.y = double.Parse(components[4], CultureInfo.InvariantCulture);
            result.rotation = double.Parse(components[5], CultureInfo.InvariantCulture);
            result.layer = components[6];
            return result;
        }

        public static ComponentLocation parseCsv(string csvLine)
        {
            ComponentLocation result = new ComponentLocation();
            using(StringReader rdr = new StringReader(csvLine))
            using(TextFieldParser csvParser = new TextFieldParser(rdr))
            {                 
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;
                string[] components = csvParser.ReadFields();
                if (components.Length != 7)
                {
                    throw new InvalidOperationException("Expected 7 values");
                }
                result.reference = ComponentReference.parse(components[0]);
                result.value = components[1];
                result.package = components[2];
                result.x = double.Parse(components[3], CultureInfo.InvariantCulture);
                result.y = double.Parse(components[4], CultureInfo.InvariantCulture);
                result.rotation = double.Parse(components[5], CultureInfo.InvariantCulture);
                result.layer = components[6];
                return result;
            }
        }

        public string ToCsv()
        {
            return String.Format(
                CultureInfo.InvariantCulture,
                "\"{0}\",\"{1}\",\"{2}\",{3:F6},{4:F6},{5:F6},{6}",
                reference.ToString(),
                value,
                package,
                x,
                y,
                rotation,
                layer);
        }

        public string ToKicad()
        {
            return String.Format(
                CultureInfo.InvariantCulture,
                "{0,-9} {1,-10} {2,-39} {3,10:F4} {4,10:F4} {5,9:F4}  {6}",
                reference.ToString(),
                value.Replace(" ", "_"),
                package.Replace(" ", "_"),
                x,
                y,
                rotation,
                layer);
        }

        public ComponentLocation Transform(double dx, double dy, double dxP, double dyP, double angleDeg)
        {
            double angle = angleDeg * (Math.PI * 2.0) / 360.0;
            double cosA = Math.Cos(angle);
            double sinA = Math.Sin(angle);

            ComponentLocation result = new ComponentLocation();
            result.reference = reference;
            result.package = package;
            result.value = value;
            result.layer = layer;
            double targetX = x + dxP;
            double tragetY = y + dyP;
            if (angle != 0)
            {
                double nX = targetX * cosA - tragetY * sinA;
                double nY = targetX * sinA + tragetY * cosA;
                targetX = nX;
                tragetY = nY;
            }
            result.x = targetX + dx;
            result.y = tragetY + dy;
            result.rotation = rotation + angleDeg;
            while (result.rotation < 0)
                result.rotation += 360;
            while (result.rotation >=360)
                result.rotation -= 360;

            return result;
        }
    }

    public class PositionFile
    {
        readonly List<string> header = new List<string>();
        public readonly List<ComponentLocation> components = new List<ComponentLocation>();

        public void Load(string filename)
        {
            var lines = File.ReadAllLines(filename);
            Parse(lines.ToList());
        }

        public void Load(StreamReader stream)
        {
            List<string> lines = new List<string>();
            while (!stream.EndOfStream)
            {
                lines.Add(stream.ReadLine());
            }
            Parse(lines);
        }

        private void Parse(List<string> lines)
        {
            if (lines.Count > 0 && lines[0].StartsWith("Ref,Val,Package,PosX,PosY,Rot,Side"))
            {
                ParseCsv(lines);
                return;
            }
            ParseKicad(lines);
        }

        private void ParseKicad(List<string> lines)
        {
            bool parseHeader = true;
            foreach(string line in lines)
            {
                if (parseHeader && line.StartsWith("#"))
                {
                    header.Add(line);
                    continue;
                }
                parseHeader = false;
                if (line.StartsWith("#"))
                {
                    // just a comment, ignore
                    continue;
                }
                components.Add(ComponentLocation.parseKicad(line));
            }
        }

        private void ParseCsv(List<string> lines)
        {
            bool parseHeader = true;
            foreach (string line in lines)
            {
                // Header is first line
                if (parseHeader)
                {
                    header.Add(line);
                    parseHeader = false;
                    continue;
                }
                if (line.StartsWith("#"))
                {
                    // just a comment, ignore
                    continue;
                }
                components.Add(ComponentLocation.parseCsv(line));
            }
        }

        Dictionary<string, int> ComputeDesignators()
        {
            Dictionary<string, int> designators = new Dictionary<string, int>();
            foreach (ComponentLocation component in components)
            {
                if (designators.ContainsKey(component.reference.name))
                {
                    int maxValue = designators[component.reference.name];
                    if (maxValue < component.reference.sequence)
                    {
                        designators[component.reference.name] = component.reference.sequence;
                    }
                }
                else
                {
                    if (component.reference.sequence < 0)
                    {
                        designators[component.reference.name] = 0;
                    }
                    else
                    {
                        designators[component.reference.name] = component.reference.sequence;
                    }
                }
            }
            return designators;
        }

        // Update component references so there is no collision with the designators from
        // another file.
        List<ComponentLocation> UpdateReferences(Dictionary<string, int> designators)
        {
            List<ComponentLocation> result = new List<ComponentLocation>(components.Count);
            foreach (ComponentLocation component in components)
            {
                ComponentLocation other = new ComponentLocation();
                other.reference = new ComponentReference();
                other.value = component.value;
                other.package = component.package;
                other.x = component.x;
                other.y = component.y;
                other.rotation = component.rotation;
                other.layer = component.layer;
                if (designators.ContainsKey(component.reference.name))
                {
                    other.reference.name = component.reference.name;
                    other.reference.sequence = component.reference.sequence + designators[component.reference.name] + 1;
                }
                else
                {
                    other.reference.name = component.reference.name;
                    other.reference.sequence = component.reference.sequence;
                }
                result.Add(other);
            }
            return result;
        }

        public void WriteCsv(string output, double dx = 0, double dy = 0, double dxP = 0, double dyP = 0, double angleDeg = 0)
        {
            using (StreamWriter sw = new StreamWriter(output))
                WriteCsv(sw, dx, dy, dxP, dyP, angleDeg);
        }

        public void WriteCsv(StreamWriter sw, double dx = 0, double dy = 0, double dxP = 0, double dyP = 0, double angleDeg = 0)
        {
            sw.WriteLine("Ref,Val,Package,PosX,PosY,Rot,Side");
            foreach(ComponentLocation component in components)
            {
                sw.WriteLine(component.Transform(dx, dy, dxP, dyP, angleDeg).ToCsv());
            }
        }

        public void WriteKicad(string output, double dx = 0, double dy = 0, double dxP = 0, double dyP = 0, double angleDeg = 0)
        {
            using (StreamWriter sw = new StreamWriter(output))
                WriteKicad(sw, dx, dy, dxP, dyP, angleDeg);
        }

        public void WriteKicad(StreamWriter sw, double dx = 0, double dy = 0, double dxP = 0, double dyP = 0, double angleDeg = 0)
        {
            sw.WriteLine("### Module positions - created on 12/13/2019 2:28:31 PM ###");
            sw.WriteLine("### Printed by GerberToole V1.0.0.0");
            sw.WriteLine("## Unit = mm, Angle = deg.");
            sw.WriteLine("## Side : top");
            sw.WriteLine("# Ref     Val        Package                                       PosX       PosY       Rot  Side");
            foreach (ComponentLocation component in components)
            {
                sw.WriteLine(component.Transform(dx, dy, dxP, dyP, angleDeg).ToKicad());
            }
            sw.WriteLine("## End");
        }


        public void Merge(PositionFile other)
        {
            components.AddRange(other.UpdateReferences(ComputeDesignators()));
        }

        public static void MergeAll(List<string> files, string output, IProgressLog log)
        {
            PositionFile result = new PositionFile();
            foreach (string fileName in files)
            {
                PositionFile posFile = new PositionFile();
                log.AddString(String.Format("Reading {0}", fileName));
                posFile.Load(fileName);
                log.AddString(String.Format("Merging {0}", fileName));
                result.Merge(posFile);
            }
            log.AddString(String.Format("Writing {0}", output));
            if (output.EndsWith(".csv"))
            {
                result.WriteCsv(output);
            }
            else
            {
                result.WriteKicad(output);
            }
        }
    }

    public class BOMLine : IEquatable<BOMLine>
    {
        public List<ComponentReference> designators;
        public string value;
        public string footprint;
        public Dictionary<int, string> extraAttributes;

        public static BOMLine parseCsv(string csvLine, int valueIdx, int designatorIdx, int footprintIdx)
        {
            BOMLine result = new BOMLine();
            using (StringReader rdr = new StringReader(csvLine))
            using (TextFieldParser csvParser = new TextFieldParser(rdr))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;
                string[] components = csvParser.ReadFields();
                for (int idx = 0; idx < components.Length; idx++)
                {
                    if (idx == valueIdx)
                    {
                        result.value = components[idx];
                    }
                    else if (idx == footprintIdx)
                    {
                        result.footprint = components[idx];
                    }
                    else if (idx == designatorIdx)
                    {
                        result.designators = parseDesignators(components[idx]);
                    }
                    else
                    {
                        if (result.extraAttributes == null)
                        {
                            result.extraAttributes = new Dictionary<int, string>();
                        }
                        result.extraAttributes.Add(idx, components[idx]);
                    }
                }
                return result;
            }
        }

        private static List<ComponentReference> parseDesignators(string designators)
        {
            string[] elements = designators.Split(',');
            List<ComponentReference> result = new List<ComponentReference>();
            foreach (string component in elements)
            {
                result.Add(ComponentReference.parse(component));
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as BOMLine);
        }

        public bool Equals(BOMLine other)
        {
            return other != null &&
                   value == other.value &&
                   footprint == other.footprint
                   /*&& EqualityComparer<Dictionary<int, string>>.Default.Equals(extraAttributes, other.extraAttributes)*/;
        }

        public override int GetHashCode()
        {
            int hashCode = 1829165486;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(value);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(footprint);
            /*hashCode = hashCode * -1521134295 + EqualityComparer<Dictionary<int, string>>.Default.GetHashCode(extraAttributes);*/
            return hashCode;
        }

        public string ToCsv(int valueIdx, int designatorIdx, int footprintIdx)
        {
            int maxIdx = Math.Max(Math.Max(valueIdx, designatorIdx), footprintIdx);
            foreach(var element in extraAttributes)
            {
                if (element.Key > maxIdx)
                {
                    maxIdx = element.Key;
                }
            }
            StringBuilder result = new StringBuilder();
            for (int idx = 0; idx <= maxIdx; idx++)
            {
                if (idx > 0) result.Append(",");
                string s;
                if (idx == valueIdx)
                {
                    s = value;
                }
                else if (idx == footprintIdx)
                {
                    s = footprint;
                }
                else if (idx == designatorIdx)
                {
                    s = printDesignators();
                }
                else
                {
                    s = extraAttributes[idx];
                }

                result.Append(String.Format(CultureInfo.InvariantCulture, "\"{0}\"", s));
            }
            return result.ToString();
        }

        private string printDesignators()
        {
            StringBuilder result = new StringBuilder();
            bool first = true;
            foreach(var d in designators)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    result.Append(',');
                }
                result.Append(d.ToString());
            }
            return result.ToString();
        }

        public static bool operator ==(BOMLine left, BOMLine right)
        {
            return EqualityComparer<BOMLine>.Default.Equals(left, right);
        }

        public static bool operator !=(BOMLine left, BOMLine right)
        {
            return !(left == right);
        }
    }

    public class BOMFile
    {
        private Dictionary<int, string> header = new Dictionary<int, string>();
        private int valueIdx = -1;
        private int designatorIdx = -1;
        private int footprintIdx = -1;
        public readonly HashSet<BOMLine> components = new HashSet<BOMLine>();

        public void Load(string filename)
        {
            var lines = File.ReadAllLines(filename);
            ParseCsv(lines.ToList());
        }

        public void Load(StreamReader stream)
        {
            List<string> lines = new List<string>();
            while (!stream.EndOfStream)
            {
                lines.Add(stream.ReadLine());
            }
            ParseCsv(lines);
        }

        private void ParseCsv(List<string> lines)
        {
            bool parseHeader = true;
            foreach (string line in lines)
            {
                // Header is first line
                if (parseHeader)
                {
                    using (StringReader rdr = new StringReader(line))
                    using (TextFieldParser csvParser = new TextFieldParser(rdr))
                    {
                        csvParser.CommentTokens = new string[] { "#" };
                        csvParser.SetDelimiters(new string[] { "," });
                        csvParser.HasFieldsEnclosedInQuotes = false;
                        var headerColumns = csvParser.ReadFields();
                        for (int idx = 0; idx < headerColumns.Length; idx++)
                        {
                            if (headerColumns[idx].CompareTo("Comment") == 0)
                                valueIdx = idx;
                            else if (headerColumns[idx].CompareTo("Designator") == 0)
                                designatorIdx = idx;
                            else if(headerColumns[idx].CompareTo("Footprint") == 0)
                                footprintIdx = idx;
                            header.Add(idx, headerColumns[idx]);
                        }
                        if (valueIdx < 0 || designatorIdx < 0 || footprintIdx < 0)
                        {
                            throw new InvalidOperationException("Could not locate Comment, Designator or Footprint");
                        }
                    }
                    parseHeader = false;
                    continue;
                }
                if (line.StartsWith("#"))
                {
                    // just a comment, ignore
                    continue;
                }
                components.Add(BOMLine.parseCsv(line, valueIdx, designatorIdx, footprintIdx));
            }
        }

        Dictionary<string, int> ComputeAllDesignators()
        {
            Dictionary<string, int> designators = new Dictionary<string, int>();
            foreach (BOMLine component in components)
            {
                foreach (ComponentReference reference in component.designators)
                {
                    if (designators.ContainsKey(reference.name))
                    {
                        int maxValue = designators[reference.name];
                        if (maxValue < reference.sequence)
                        {
                            designators[reference.name] = reference.sequence;
                        }
                    }
                    else
                    {
                        if (reference.sequence < 0)
                        {
                            designators[reference.name] = 0;
                        }
                        else
                        {
                            designators[reference.name] = reference.sequence;
                        }
                    }
                }
            }
            return designators;
        }

        // Update component references so there is no collision with the designators from
        // another file.
        List<BOMLine> UpdateReferences(Dictionary<string, int> designators)
        {
            List<BOMLine> result = new List<BOMLine>(components.Count);
            foreach (BOMLine component in components)
            {
                BOMLine other = new BOMLine();
                other.designators = new List<ComponentReference>();
                other.value = component.value;
                other.footprint = component.footprint;
                other.extraAttributes = component.extraAttributes;
                foreach (ComponentReference reference in component.designators)
                {
                    ComponentReference newReference = new ComponentReference();
                    if (designators.ContainsKey(reference.name))
                    {
                        newReference.name = reference.name;
                        newReference.sequence = reference.sequence + designators[reference.name] + 1;
                    }
                    else
                    {
                        newReference.name = reference.name;
                        newReference.sequence = reference.sequence;
                    }
                    other.designators.Add(newReference);
                }
                result.Add(other);
            }
            return result;
        }

        public void WriteCsv(string output, double dx = 0, double dy = 0, double dxP = 0, double dyP = 0, double angleDeg = 0)
        {
            using (StreamWriter sw = new StreamWriter(output))
                WriteCsv(sw);
        }

        private string printHeader()
        {
            StringBuilder result = new StringBuilder();
            int maxIdx = -1;
            foreach (var element in header)
            {
                if (element.Key > maxIdx)
                {
                    maxIdx = element.Key;
                }
            }
            for (int idx = 0; idx <= maxIdx; idx++)
            {
                if (idx > 0)
                {
                    result.Append(", ");
                }
                result.Append(header[idx]);
            }
            return result.ToString();

        }
        public void WriteCsv(StreamWriter sw)
        {
            sw.WriteLine(printHeader());
            foreach (BOMLine component in components)
            {
                sw.WriteLine(component.ToCsv(valueIdx, designatorIdx, footprintIdx));
            }
        }

        public void Merge(BOMFile other)
        {
            List<BOMLine> updatedComponents = other.UpdateReferences(ComputeAllDesignators());
            foreach (BOMLine element in updatedComponents)
            {
                BOMLine existingElement;
                if (components.TryGetValue(element, out existingElement))
                {
                    existingElement.designators.AddRange(element.designators);
                }
                else
                {
                    components.Add(element);
                }
            }
            foreach (var h in other.header)
            {
                if (!header.ContainsKey(h.Key))
                {
                    header[h.Key] = h.Value;
                }
            }
        }

        public static void MergeAll(List<string> files, string output, IProgressLog log)
        {
            BOMFile result = null;
            foreach (string fileName in files)
            {
                BOMFile bomFile = new BOMFile();
                log.AddString(String.Format("Reading {0}", fileName));
                bomFile.Load(fileName);
                log.AddString(String.Format("Merging {0}", fileName));
                if (result == null)
                {
                    result = bomFile;
                }
                else
                {
                    result.Merge(bomFile);
                }
            }
            log.AddString(String.Format("Writing {0}", output));
            result.WriteCsv(output);
        }
    }
}
