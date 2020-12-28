﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Queen : Piece 
    {
        public Queen(MYCOLOR C, string n)
            : base(C, n)
        {
            
        }


        public override bool IsLegal(int sr, int sc, int er, int ec, Piece[,] Ps)
    {
        return (IsDiagonal(sr, sc, er, ec) && IsDiagonalClear(sr, sc, er, ec, Ps) ||
            ((Isvertical(sr, sc, er, ec) && IsverticalClear(sr, sc, er, ec, Ps)) ||
           (IsHorizontol(sr, sc, er, ec) && IsHorizontolClear(sr, sc, er, ec, Ps))));
    }
    }
}
