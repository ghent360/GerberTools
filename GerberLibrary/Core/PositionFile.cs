using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                    designators[component.reference.name] = component.reference.sequence;
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
}
