using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscreteFunctions;

namespace DFPolygon
{
    class Program
    {
        static void Main(string[] args)
        {
            //DiscreteFunctionBase df1 = new DiscreteFunction2DChunked<double,double>(new [] {new [] {1.0,2,3}});
            //DiscreteFunctionBase df2 = new DiscreteFunction2DChunked<double,double>(new [] {new [] {1.0,2,3}});
            DiscreteFunctionBase df1 = new DiscreteFunction2D(1.0, 2, 3);
            DiscreteFunctionBase df2 = new DiscreteFunction2D(1.0, 2, 3);
            var df3 = df1 + df2;

            Console.WriteLine(df3);
        }
    }
}
