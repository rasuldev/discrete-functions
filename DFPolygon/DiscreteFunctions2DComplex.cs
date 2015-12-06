using System;
using System.Linq;

namespace DiscreteFunctions
{
    public class DiscreteFunctions2DComplex : DiscreteFunction2DChunked<alglib.complex, alglib.complex>
    {
        public DiscreteFunctions2DComplex(Array nodes, Array values) : base(nodes, values)
        {
        }

        public DiscreteFunctions2DComplex(alglib.complex[][] nodesChunks, alglib.complex[][] valuesChunks) : base(nodesChunks, valuesChunks)
        {
        }

        public DiscreteFunctions2DComplex(alglib.complex[][] chunks) : base(chunks)
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

        protected override DiscreteFunctionBase BinOp(DiscreteFunctionBase right, Operation op)
        {
            var df = base.BinOp(right, op);
            return
                right is DiscreteFunction2D ? Convert(df) : df;
        }

        public static DiscreteFunction2D Convert(DiscreteFunction2DChunked<double, double> df)
        {
            return new DiscreteFunction2D(df.X?[0], df.Y[0]);
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