using System;
using System.Linq;

namespace DiscreteFunctions
{
    public class Df2DComplex : Df2DChunked<alglib.complex, alglib.complex>
    {
        public Df2DComplex(Array nodes, Array values) : base(nodes, values)
        {
        }

        public Df2DComplex(alglib.complex[][] nodesChunks, alglib.complex[][] valuesChunks) : base(nodesChunks, valuesChunks)
        {
        }

        public Df2DComplex(alglib.complex[][] chunks) : base(chunks)
        {
        }

        public Df2DComplex(params alglib.complex[] values) : base(new[] { values })
        {
        }


        #region Operators

        //public static DiscreteFunction2D operator +(DiscreteFunction2D left, DiscreteFunction2D right)
        //{
        //    return Convert(BinOp(left, right, Operation.Add));
        //}

        //public static DiscreteFunction2D operator -(DiscreteFunction2D left, DiscreteFunction2D right)
        //{
        //    return Convert(BinOp(left, right, Operation.Sub));
        //}

        //public static DiscreteFunction2D operator *(DiscreteFunction2D left, DiscreteFunction2D right)
        //{
        //    return Convert(BinOp(left, right, Operation.Mul));
        //}

        //public static DiscreteFunction2D operator /(DiscreteFunction2D left, DiscreteFunction2D right)
        //{
        //    return Convert(BinOp(left, right, Operation.Div));
        //}

        #endregion

        #region Operations

        protected override DfBase BinOp(DfBase right, Operation op)
        {
            var df = base.BinOp(right, op);
            return
                right is Df2D ? Convert(df) : df;
        }

        public static Df2D Convert(Df2DChunked<double, double> df)
        {
            return new Df2D(df.X?[0], df.Y[0]);
        }


        #endregion

        //public string ToString(string format)
        //{
        //    string str;
        //    if (X == null)
        //        str = string.Join(";", Y.Select(x => x.ToString(format)));
        //    else
        //        str = string.Join(";", X.Zip(Y, (x, y) => x.ToString(format) + "->" + y.ToString(format)));

        //    return $"({str})";
        //}

        //public override string ToString()
        //{
        //    return ToString("F3");
        //}


    }
}