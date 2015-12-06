﻿using System;
using System.Collections.Generic;
using MiscUtil;

namespace DiscreteFunctions
{
    public class DiscreteFunction2DChunked<TNodes, TValues> : DiscreteFunctionBase
    {

        protected DiscreteFunction2DChunked(Array nodes, Array values) : base(nodes, values)
        {
        }

        public DiscreteFunction2DChunked(TNodes[][] nodesChunks, TValues[][] valuesChunks)
            : base(nodesChunks, valuesChunks)
        {
            if (nodesChunks != null)
                Utils.CheckConsistency(nodesChunks, valuesChunks);
        }
        public DiscreteFunction2DChunked(TValues[][] chunks) : base(chunks) { }



        public TNodes[][] X
        {
            get { return (TNodes[][])Nodes; }
            set
            {
                Utils.CheckConsistency(value, Y);
                Nodes = value;
            }
        }

        public TNodes[][] Y
        {
            get { return (TNodes[][])Values; }
            set
            {
                if (X != null)
                    Utils.CheckConsistency(X, value);
                Values = value;
            }
        }

        #region Operations

        protected DiscreteFunction2DChunked<TNodes, TValues> Convert(DiscreteFunctionBase df)
        {
            var dfChunked = df as DiscreteFunction2DChunked<TNodes, TValues>;
            if (dfChunked == null)
                throw new NotSupportedException($"Operator is not defined on {this.GetType()} and {df.GetType()}.");
            return dfChunked;
        }


        protected override DiscreteFunctionBase BinOp(DiscreteFunctionBase right, Operation op)
        {
            return BinOp(this, Convert(right), op);
        }

        protected static DiscreteFunction2DChunked<TNodes, TValues> BinOp(
            DiscreteFunction2DChunked<TNodes, TValues> left, DiscreteFunction2DChunked<TNodes, TValues> right,
            Operation op)
        {
            return BinOp(left, right, op.Operator<TValues>(), op.Sign());
        }


        protected static DiscreteFunction2DChunked<TNodes, TValues> BinOp(DiscreteFunction2DChunked<TNodes, TValues> left, DiscreteFunction2DChunked<TNodes, TValues> right, Func<TValues, TValues, TValues> binOperator, string opDescription = "~")
        {
            Utils.CheckCompatibility(left, right);
            var values1 = (TValues[][])left.Values;
            var values2 = (TValues[][])right.Values;
            var sum = new TValues[values1.Length][];
            for (int j = 0; j < values1.Length; j++)
            {
                sum[j] = new TValues[values1[j].Length];
                for (int i = 0; i < values1[j].Length; i++)
                {
                    sum[j][i] = binOperator(values1[j][i], values2[j][i]);
                }
            }
            opDescription = $" {opDescription} ";
            return new DiscreteFunction2DChunked<TNodes, TValues>(left.Nodes, sum) { Name = left.Name + opDescription + right.Name };
        }
        #endregion

        #region Operators
        // All operators are applied to Values (Y coords). Nodes (X coords) of discrete functions are supposed to be the same:
        // no check of nodes equality is performed
        public static DiscreteFunction2DChunked<TNodes, TValues> operator +(DiscreteFunction2DChunked<TNodes, TValues> left, DiscreteFunction2DChunked<TNodes, TValues> right)
        {
            return BinOp(left, right, Operation.Add);
        }

        public static DiscreteFunction2DChunked<TNodes, TValues> operator -(DiscreteFunction2DChunked<TNodes, TValues> left, DiscreteFunction2DChunked<TNodes, TValues> right)
        {
            return BinOp(left, right, Operation.Sub);
        }

        public static DiscreteFunction2DChunked<TNodes, TValues> operator *(DiscreteFunction2DChunked<TNodes, TValues> left, DiscreteFunction2DChunked<TNodes, TValues> right)
        {
            return BinOp(left, right, Operation.Mul);
        }

        public static DiscreteFunction2DChunked<TNodes, TValues> operator /(DiscreteFunction2DChunked<TNodes, TValues> left, DiscreteFunction2DChunked<TNodes, TValues> right)
        {
            return BinOp(left, right, Operation.Div);
        }

        #endregion
    }
}