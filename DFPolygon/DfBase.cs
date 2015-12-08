using System;

namespace DiscreteFunctions
{
    public abstract class DfBase
    {
        /// <summary>
        /// Domain (x - coords)
        /// </summary>
        public Array Nodes { get; protected set; }
        /// <summary>
        /// Values of a function
        /// </summary>
        public Array Values { get; protected set; }
        public string Name { get; set; }

        protected DfBase()
        {
        }

        protected DfBase(Array values) : this(null, values)
        {
        }

        protected DfBase(Array nodes, Array values)
        {
            Nodes = nodes;
            Values = values;
        }

        #region Operators
        // X coordinates of discrete functions are supposed to be the same: 
        // no check of x-coords equality performs
        public static DfBase operator +(DfBase df1, DfBase df2)
        {
            return df1.BinOp(df2, Operation.Add);
        }

        public static DfBase operator -(DfBase df1, DfBase df2)
        {
            return df1.BinOp(df2, Operation.Sub);
        }

        public static DfBase operator *(DfBase df1, DfBase df2)
        {
            return df1.BinOp(df2, Operation.Mul);
        }

        public static DfBase operator /(DfBase df1, DfBase df2)
        {
            return df1.BinOp(df2, Operation.Div);
        }

        protected abstract DfBase BinOp(DfBase right, Operation op);

        #endregion



    }


    public class SetRaisedEventArgs : EventArgs
    {
        public Array Nodes { get; set; }
        public SetRaisedEventArgs(Array nodes)
        {
            Nodes = nodes;
        }
    }
}