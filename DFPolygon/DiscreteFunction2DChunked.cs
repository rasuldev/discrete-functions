using System;
using MiscUtil;

namespace DiscreteFunctions
{
    public class DiscreteFunction2DChunked<TNodes, TValues> : DiscreteFunctionBase
    {

        //protected int ChunksCount = 0;

        protected DiscreteFunction2DChunked(Array nodes, Array values) : base(nodes, values)
        {
        }

        public DiscreteFunction2DChunked(TNodes[][] nodesChunks, TValues[][] valuesChunks)
            : base(nodesChunks, valuesChunks)
        {
            Utils.CheckConsistency(nodesChunks, valuesChunks);
        }
        public DiscreteFunction2DChunked(TValues[][] chunks) : base(chunks) { }



        public virtual TNodes[][] X
        {
            get { return (TNodes[][])Nodes; }
            set { Nodes = value; }
        }

        public virtual TNodes[][] Y
        {
            get { return (TNodes[][])Values; }
            set { Values = value; }
        }


        #region Operators
        // All operators are applied to Values (Y coords). Nodes (X coords) of discrete functions are supposed to be the same:
        // no check of nodes equality is performed
        public static DiscreteFunction2DChunked<TNodes, TValues> operator +(DiscreteFunction2DChunked<TNodes, TValues> df1, DiscreteFunction2DChunked<TNodes, TValues> df2)
        {
            var op = Operator<TValues>.Add;
            return BinOp(df1, df2, op, "+");
        }

        public static DiscreteFunction2DChunked<TNodes, TValues> operator -(DiscreteFunction2DChunked<TNodes, TValues> df1, DiscreteFunction2DChunked<TNodes, TValues> df2)
        {
            var op = Operator<TValues>.Subtract;
            return BinOp(df1, df2, op, "-");
        }

        public static DiscreteFunction2DChunked<TNodes, TValues> operator *(DiscreteFunction2DChunked<TNodes, TValues> df1, DiscreteFunction2DChunked<TNodes, TValues> df2)
        {
            var op = Operator<TValues>.Multiply;
            return BinOp(df1, df2, op, "*");
        }

        public static DiscreteFunction2DChunked<TNodes, TValues> operator /(DiscreteFunction2DChunked<TNodes, TValues> df1, DiscreteFunction2DChunked<TNodes, TValues> df2)
        {
            var op = Operator<TValues>.Divide;
            return BinOp(df1, df2, op, "/");
        }

        protected static DiscreteFunction2DChunked<TNodes, TValues> BinOp(DiscreteFunction2DChunked<TNodes, TValues> df1, DiscreteFunction2DChunked<TNodes, TValues> df2, Func<TValues, TValues, TValues> binOperation, string opDescription = "~")
        {
            Utils.CheckCompatibility(df1, df2);
            var values1 = (TValues[][])df1.Values;
            var values2 = (TValues[][])df2.Values;
            var sum = new TValues[values1.Length][];
            for (int j = 0; j < values1.Length; j++)
            {
                sum[j] = new TValues[values1[j].Length];
                for (int i = 0; i < values1[j].Length; i++)
                {
                    sum[j][i] = binOperation(values1[j][i], values2[j][i]);
                }
            }
            opDescription = $" {opDescription} ";
            return new DiscreteFunction2DChunked<TNodes, TValues>(df1.Nodes, sum) { Name = df1.Name + opDescription + df2.Name };
        }


        #endregion


        #region Operations

        public override DiscreteFunctionBase Add(DiscreteFunctionBase right)
        {
            throw new NotImplementedException();
        }

        public override DiscreteFunctionBase Subtract(DiscreteFunctionBase right)
        {
            throw new NotImplementedException();
        }

        public override DiscreteFunctionBase Multiply(DiscreteFunctionBase right)
        {
            throw new NotImplementedException();
        }

        public override DiscreteFunctionBase Divide(DiscreteFunctionBase right)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}