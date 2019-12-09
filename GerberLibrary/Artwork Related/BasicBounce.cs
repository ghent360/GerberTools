﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GerberLibrary
{
    class BasicBounce : GerberLibrary.ArtWork.Functions.BounceInterface
    {

        public override void RDBounce(GerberLibrary.ArtWork.Functions.RDElem[] FieldA, GerberLibrary.ArtWork.Functions.RDElem[] FieldB, int iW, int iH, float feed, float kill, double[] distancefield, float du = 0.2097f, float dv = 0.105f)
        {
            for (int y = 0; y < iH; y++)
            {

                for (int x = 0; x < iW; x++)
                {
                    var C = GetF(FieldA, x, y, iW, iH);
                    var C0 = GetF(FieldA, x - 1, y, iW, iH);
                    var C1 = GetF(FieldA, x + 1, y, iW, iH);
                    var C2 = GetF(FieldA, x, y - 1, iW, iH);
                    var C3 = GetF(FieldA, x, y + 1, iW, iH);

                    float df = (float)distancefield[x + y * iW];

                    var localfeed = feed * (1 - (1 + df) * 0.01f);

                    float lapR = C0.R + C1.R + C2.R + C3.R - 4 * C.R;
                    float lapG = C0.G + C1.G + C2.G + C3.G - 4 * C.G;

                    float DU = du * lapR - C.R * C.G * C.G + localfeed * (1.0f - C.R);
                    float DV = dv * lapG + C.R * C.G * C.G - (localfeed + kill) * C.G;

                    SetF(FieldB, x, y, iW, iH, C.R + .9f * DU, C.G + .9f * DV);
                }
            }
        }

        private static void SetF(GerberLibrary.ArtWork.Functions.RDElem[] FieldB, int x, int y, int iW, int iH, float p1, float p2)
        {
            x = (x + iW) % iW;
            y = (y + iH) % iH;
            FieldB[x + y * iW].R = p1;
            FieldB[x + y * iW].G = p2;
        }

        static GerberLibrary.ArtWork.Functions.RDElem GetF(GerberLibrary.ArtWork.Functions.RDElem[] FieldA, int x, int y, int iW, int iH)
        {
            x = (x + iW) % iW;
            y = (y + iH) % iH;
            return FieldA[x + y * iW];
        }

        public override void BounceN(int p, GerberLibrary.ArtWork.Functions.RDElem[] FieldA, GerberLibrary.ArtWork.Functions.RDElem[] FieldB, int iW, int iH, float feedrate, float killrate, double[] DistanceFieldBlur)
        {

            for (int i = 0; i < p / 2; i++)
            {
                RDBounce(FieldA, FieldB, iW, iH, feedrate, killrate, DistanceFieldBlur);
                RDBounce(FieldB, FieldA, iW, iH, feedrate, killrate, DistanceFieldBlur);
            }


        }
    }
}
