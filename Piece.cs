using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;


namespace Chess
{

    enum MYCOLOR { WHITE, BLACK };
    abstract class Piece
    {
        public MYCOLOR col;
        string PictureName;

        public Piece(MYCOLOR C, string n)
        {
            col = C;
            PictureName = n;
        }

        public abstract bool IsLegal(int sr, int sc, int er, int ec, Piece[,] Ps);

        public void Draw(Cell C)
        {
            C.Image = Image.FromFile("..\\..\\Resources\\" + PictureName);

        }




        public static bool Isvertical(int sr, int sc, int er, int ec)
        {
            return sc == ec;
        }
        public static bool IsHorizontol(int sr, int sc, int er, int ec)
        {
            return sr == er;
        }
        public static bool IsDiagonal(int sr, int sc, int er, int ec)
        {
            return Math.Abs(sr - er) == Math.Abs(sc - ec);
        }

        public static bool IsverticalClear(int sri, int sci, int eri, int eci,Piece [,]Ps)
        {
            int startr = (sri < eri) ? sri + 1 : eri + 1;
            int endr = (sri < eri) ? eri - 1 : sri - 1;
            for (int r = startr; r <= endr; r++)
            {
                //this.BackColor = Color.Gray;
                if (Ps[r,sci] != null)
                    return false;
            }
            return true;
        }

        public static bool IsHorizontolClear(int sri, int sci, int eri, int eci,Piece [,]Ps)
        {
            int startc = (sci < eci) ? sci + 1 : eci + 1;
            int endc = (sci < eci) ? eci - 1 : sci - 1;
            for (int c = startc; c <= endc; c++)
            {
                if (Ps[sri,c] != null)
                    return false;
            }
            return true;
        }
        public static bool IsDiagonalClear(int sri, int sci, int eri, int eci, Piece[,] Ps)
        {
            int dr = eri - sri;
            int dc = eci - sci;
            if (dr < 0 && dc < 0)
            {
                dr = -dr;
                for (int t = 1; t < dr; t++)
                {
                    if (Ps[eri + t, eci + t] != null)
                        return false;
                }
                return true;
            }
            if (dr > 0 && dc > 0)
            {
                for (int t = 1; t < dr; t++)
                {
                    if (Ps[sri + t, sci + t] != null)
                        return false;
                }
                return true;
            }
            if (dr < 0 && dc > 0)
            {
                for (int t = 1; t < dr; t++)
                {
                    if (Ps[eri + t, sci + t] != null)
                        return false;
                }
                return true;
            }
            if (dr > 0 && dc < 0)
            {
                for (int t = 1; t < dr; t++)
                {
                    if (Ps[sri + t, eci + t] != null)
                        return false;
                }
                return true;
            }
            return true;
        }
    }
}
