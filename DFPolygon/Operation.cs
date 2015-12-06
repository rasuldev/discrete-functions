using System;
using System.Collections.Generic;
using MiscUtil;

namespace DiscreteFunctions
{
    public enum Operation { Add, Sub, Mul, Div }


    public static class OperationExtensions
    {
        public static Func<T, T, T> Operator<T>(this Operation op)
        {
            return OperationHelper<T>.Operators[op];
        }

        public static string Sign(this Operation op)
        {
            return Signs[op];
        }

        public static Dictionary<Operation, string> Signs => new Dictionary<Operation, string>()
        {
            [Operation.Add] = "+",
            [Operation.Sub] = "-",
            [Operation.Mul] = "*",
            [Operation.Div] = "/"
        };
    }

    public static class OperationHelper<T>
    {
        public static Dictionary<Operation, Func<T, T, T>> Operators { get; } =
            new Dictionary<Operation, Func<T, T, T>>()
            {
                [Operation.Add] = Operator<T>.Add,
                [Operation.Sub] = Operator<T>.Subtract,
                [Operation.Mul] = Operator<T>.Multiply,
                [Operation.Div] = Operator<T>.Divide
            };
    }
}