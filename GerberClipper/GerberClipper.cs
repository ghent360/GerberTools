﻿using GerberLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerberClipper
{
    class GerberClipper: IProgressLog
    {
        static void Main(string[] args)
        {
            if (args.Count() < 3)
            {
                Console.WriteLine("Usage: GerberClipper.exe <outlinegerber> <subject> <outputfile>");
                return;
            }

            string outline = args[0];
            string infile = args[1];
            string outputfile = args[2];

            GerberImageCreator GIC = new GerberImageCreator();
            GIC.AddBoardsToSet(new List<string>() { outline, infile }, true, new GerberClipper());

            GIC.ClipBoard(infile, outputfile, new GerberClipper());
        }

        public void AddString(string text, float progress = -1F)
        {
            Console.WriteLine("{0}", text);
        }
    }
}
