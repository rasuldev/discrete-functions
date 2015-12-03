using System;

namespace DiscreteFunctions
{
    public abstract class DiscreteFunctionBase
    {
        /// <summary>
        /// Domain (x - coords)
        /// </summary>
        protected Array Nodes;
        /// <summary>
        /// Values of a function
        /// </summary>
        protected Array Values;
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

        public abstract DiscreteFunctionBase Add(DiscreteFunctionBase right);
        public abstract DiscreteFunctionBase Subtract(DiscreteFunctionBase right);
        public abstract DiscreteFunctionBase Multiply(DiscreteFunctionBase right);
        public abstract DiscreteFunctionBase Divide(DiscreteFunctionBase right);
        //public abstract DiscreteFunctionBase Abs();

        // X coordinates of discrete functions are supposed to be the same: 
        // no check of x-coords equality performs
        public static DiscreteFunctionBase operator +(DiscreteFunctionBase df1, DiscreteFunctionBase df2)
        {
            return df1.Add(df2);
        }

        public static DiscreteFunctionBase operator -(DiscreteFunctionBase df1, DiscreteFunctionBase df2)
        {
            return df1.Subtract(df2);
        }

        public static DiscreteFunctionBase operator *(DiscreteFunctionBase df1, DiscreteFunctionBase df2)
        {
            return df1.Multiply(df2);
        }

        public static DiscreteFunctionBase operator /(DiscreteFunctionBase df1, DiscreteFunctionBase df2)
        {
            return df1.Divide(df2);
        }

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