namespace DiscreteFunctions
{
    public static class Utils
    {
        public static void CheckCompatibility<T1, T2, T3, T4>(DiscreteFunction2DChunked<T1, T2> df1, DiscreteFunction2DChunked<T3, T4> df2)
        {
            if (df1.Y.Length != df2.Y.Length)
                throw new NotCompatibleException();
        }

        public static void CheckConsistency<T1, T2>(T1[][] nodes, T2[][] values)
        {
            if (nodes.Length != values.Length)
                throw new ConsistenceException();
            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i].Length != values[i].Length)
                    throw new ConsistenceException();
            }
        }
    }
}