using System;
using GerberLibrary.Core;

namespace PosFileTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            PositionFile pf = new PositionFile();
            pf.Load(@"C:\Users\pc-user\Documents\PrntrBoardV2\hardware\Gerber\TMC2660_Driver-top-pos.csv");
            pf.WriteCsv(@"C:\Users\pc-user\Documents\ttt-top.csv");
            pf.WriteKicad(@"C:\Users\pc-user\Documents\ttt-top.pos");
            pf.Merge(pf);
            */
            BOMFile bf = new BOMFile();
            bf.Load(@"C:\Users\pc-user\Documents\PrntrBoardV2\hardware\TMC2660_Driver-bom.csv");
            bf.WriteCsv(@"C:\Users\pc-user\Documents\ttt-bom.csv");
            bf.Merge(bf);
            bf.WriteCsv(@"C:\Users\pc-user\Documents\ttt-bom2.csv");
        }
    }
}
