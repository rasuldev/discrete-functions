using System;

namespace DiscreteFunctions
{
    public abstract class DiscreteFunctionBase
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

        protected DiscreteFunctionBase()
        {
        }

        protected DiscreteFunctionBase(Array values) : this(null, values)
        {
        }

        protected DiscreteFunctionBase(Array nodes, Array values)
        {
            Nodes = nodes;
            Values = values;
        }

        #region Operators
        // X coordinates of discrete functions are supposed to be the same: 
        // no check of x-coords equality performs
        public static DiscreteFunctionBase operator +(DiscreteFunctionBase df1, DiscreteFunctionBase df2)
        {
            return df1.BinOp(df2, Operation.Add);
        }

        public static DiscreteFunctionBase operator -(DiscreteFunctionBase df1, DiscreteFunctionBase df2)
        {
            return df1.BinOp(df2, Operation.Sub);
        }

        public static DiscreteFunctionBase operator *(DiscreteFunctionBase df1, DiscreteFunctionBase df2)
        {
            return df1.BinOp(df2, Operation.Mul);
        }

        public static DiscreteFunctionBase operator /(DiscreteFunctionBase df1, DiscreteFunctionBase df2)
        {
            return df1.BinOp(df2, Operation.Div);
        }

        protected abstract DiscreteFunctionBase BinOp(DiscreteFunctionBase right, Operation op);

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