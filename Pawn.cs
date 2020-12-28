using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Pawn : Piece
    {

        public Pawn(MYCOLOR C, string n) : base (C,n)
        {
            
        }


        public override bool IsLegal(int Sr, int Sc, int Er, int Ec, Piece[,] Ps)
        {
            int Dr = Math.Abs(Er - Sr);
            int Dc = Math.Abs(Ec - Sc);
        if (Ps[Sr,Sc].col == MYCOLOR.BLACK)
        {
            if ((Isvertical(Sr,Sc,Er,Ec) && IsverticalClear(Sr,Sc,Er,Ec, Ps)))
            {
                if (Sr == 1)
                {
                    if ((Er == Sr + 2 || Er == Sr + 1) && Ec == Sc && Ps[Er,Ec] == null)
                        return true;
                    else
                        return false;
                }
                if (Er == Sr + 1 && Ec == Sc && Ps[Er,Ec] == null)
                    return true;
                else
                    return false;
            }
            if (IsDiagonalClear(Sr, Sc, Er, Ec, Ps))
            {
                if ((Er == Sr + 1 && (Ec == Sc + 1 || Ec == Sc - 1)) && Ps[Er,Ec] != null)
                    return true;
                else
                    return false;
            }
        }
        else
        {
            if (Sr == 6)
            {
                if (((Er == Sr - 2 || Er == Sr - 1) && Ec == Sc && Ps[Er,Ec] == null) &&
                    IsverticalClear(Sr, Sc, Er, Ec, Ps))
                    return true;
                else
                    return false;
            }
            if (Isvertical(Sr, Sc, Er, Ec) && IsverticalClear(Sr, Sc, Er, Ec, Ps))
            {
                if (Er == Sr - 1 && Ec == Sc && Ps[Er,Ec] == null)
                    return true;
                else
                    return false;
            }
            if (IsDiagonalClear(Sr, Sc, Er, Ec, Ps))
            {
                if ((Er == Sr - 1 && (Ec == Sc + 1 || Ec == Sc - 1)) && (Ps[Er,Ec] != null))
                    return true;
                else
                    return false;
            }
        }
        return false;
    }
    }
}
