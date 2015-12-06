using System;
using System.Linq;

namespace DiscreteFunctions
{
    public class DiscreteFunction2D : DiscreteFunction2DChunked<double, double>
    {

        #region Constructors
        protected DiscreteFunction2D(Array nodes, Array values) : base(nodes, values)
        {
        }

        public DiscreteFunction2D(double[] nodes, double[] values) : base(nodes == null ? null : new[] { nodes }, new[] { values })
        {
        }

        public DiscreteFunction2D(params double[] values) : base(new[] { values })
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

        public static DiscreteFunction2D operator +(DiscreteFunction2D left, DiscreteFunction2D right)
        {
            return Convert(BinOp(left, right, Operation.Add));
        }

        public static DiscreteFunction2D operator -(DiscreteFunction2D left, DiscreteFunction2D right)
        {
            return Convert(BinOp(left, right, Operation.Sub));
        }

        public static DiscreteFunction2D operator *(DiscreteFunction2D left, DiscreteFunction2D right)
        {
            return Convert(BinOp(left, right, Operation.Mul));
        }

        public static DiscreteFunction2D operator /(DiscreteFunction2D left, DiscreteFunction2D right)
        {
            return Convert(BinOp(left, right, Operation.Div));
        }

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