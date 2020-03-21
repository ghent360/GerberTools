using System;
using GerberLibrary.Core;

namespace PosFileTest
{
    class Program
    {
        static void Main(string[] args)
        {
            PositionFile pf = new PositionFile();
            pf.Load(@"C:\Users\pc-user\Documents\PrntrBoardV2\hardware\Gerber\TMC2660_Driver-top-pos.csv");
            pf.WriteCsv(@"C:\Users\pc-user\Documents\ttt-top.csv");
            pf.WriteKicad(@"C:\Users\pc-user\Documents\ttt-top.pos");
            pf.Merge(pf);
        }
    }
}
