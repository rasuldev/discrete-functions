using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscreteFunctions;
using MiscUtil;

namespace DFPolygon
{
    class Program
    {
        static void Main(string[] args)
        {
            //DiscreteFunctionBase df1 = new Df2DChunked<double,double>(new [] {new [] {1.0,2,3}});
            //DiscreteFunctionBase df2 = new Df2DChunked<double,double>(new [] {new [] {1.0,2,3}});
            //DiscreteFunctionBase df1 = new DiscreteFunction2D(1.0, 2, 3);
            //DiscreteFunctionBase df2 = new DiscreteFunctions2DComplex(1.0 + new alglib.complex(0, 1), 2, 3);
            //var df3 = df1 + df2;

            //Console.WriteLine(df3);

            var x = 1;
            var y = new alglib.complex(0,1);
            y = x;
            //var z = Operator.AddAlternative(new alglib.complex(0, 1),1);
            Console.WriteLine(x+y);
        }
    }
}
