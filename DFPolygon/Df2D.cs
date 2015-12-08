using System;
using System.Linq;

namespace DiscreteFunctions
{
    public class Df2D : Df2DChunked<double, double>
    {

        #region Constructors
        public Df2D(double[] nodes, double[] values) : base(nodes == null ? null : new[] { nodes }, new[] { values })
        {
        }

        public Df2D(params double[] values) : base(new[] { values })
        {
        }

        #endregion



        public new double[] X
        {
            get { return base.X?[0]; }
            set { base.X = value == null ? null : new[] { value }; }
        }

        public new double[] Y
        {
            get { return base.Y?[0]; }
            set { base.Y = value == null ? null : new[] { value }; }
        }

        #region Operators

        public static Df2D operator +(Df2D left, Df2D right)
        {
            return Convert(BinOp(left, right, Operation.Add));
        }

        public static Df2D operator -(Df2D left, Df2D right)
        {
            return Convert(BinOp(left, right, Operation.Sub));
        }

        public static Df2D operator *(Df2D left, Df2D right)
        {
            return Convert(BinOp(left, right, Operation.Mul));
        }

        public static Df2D operator /(Df2D left, Df2D right)
        {
            return Convert(BinOp(left, right, Operation.Div));
        }

        #endregion

        #region Operations

        protected override DfBase BinOp(DfBase right, Operation op)
        {



            var df = base.BinOp(right, op);
            // this is df2D. If BinOp was successfully applied to this and right,
            // then right either is df2D, or can be converted to df2D. So we can always
            // treat result of BinOp as df2D 
            return Convert(df);

            // Alternative option:
            // return right is DiscreteFunction2D ? Convert(df) : df;
        }

        public static Df2D Convert(Df2DChunked<double, double> df)
        {
            return new Df2D(df.X?[0], df.Y[0]);
        }


        #endregion

        public string ToString(string format)
        {
            string str;
            if (X == null)
                str = string.Join(";", Y.Select(x => x.ToString(format)));
            else
                str = string.Join(";", X.Zip(Y, (x, y) => x.ToString(format) + "->" + y.ToString(format)));

            return $"({str})";
        }

        public override string ToString()
        {
            return ToString("F3");
        }
    }
}