﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchematicReader
{
    public struct Block /*: IEquatable<Block>*/
                         //IComparable<Block>
    {
        public readonly int X;
        public readonly int Y;
        public readonly int Z;
        public readonly byte BlockID;
        public readonly byte Data;
        //public readonly int ID;

        public Block(int x, int y, int z, byte blockID, byte data/*, int iD*/)
        {
            X = x;
            Y = y;
            Z = z;
            BlockID = blockID;
            Data = data;
            //ID = iD;
        }

        //public override int GetHashCode()
        //{
        //    //the index of the block at X,Y,Z is (Y×length + Z)×width + X
        //    return (Y * SchematicReader.LengthSchematic + Z) * SchematicReader.WidthSchematic + X;
        //}

        //public bool Equals(Block other)
        //{
        //    return this.GetHashCode() == other.GetHashCode();
        //}

        public override string ToString()
        {
            return string.Format("ID: {3}:{4}, X: {0}, Y: {1}, Z: {2}", X, Y, Z, BlockID, Data);
        }

        //public int CompareTo(Block other)
        //{
        //    return this.GetHashCode().CompareTo(other.GetHashCode());
        //}
    }

    public class BlockComparer : IEqualityComparer<Block>
    {
        public bool Equals(Block x, Block y)
        {
            return x.X == y.X && x.Y == y.Y && x.Z == y.Z;
        }

        public int GetHashCode(Block obj)
        {
            return obj.X.GetHashCode() ^ (obj.Y.GetHashCode() << 2) ^ (obj.Z.GetHashCode() >> 2);
        }
    }
}
