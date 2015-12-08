namespace DiscreteFunctions
{
    public static class Utils
    {
        public static void CheckCompatibility<T1, T2, T3, T4>(Df2DChunked<T1, T2> df1, Df2DChunked<T3, T4> df2)
        {
            if (!HaveEqualSizes(df1.Y,df2.Y))
                throw new NotCompatibleException();
        }

        public static void CheckConsistency<T1, T2>(T1[][] nodes, T2[][] values)
        {
            if (!HaveEqualSizes(nodes, values))
                throw new ConsistenceException();

        }

        /// <summary>
        /// Checks if arr1 and arr2 have the same sizes of each element
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public static bool HaveEqualSizes<T1, T2>(T1[][] arr1, T2[][] arr2)
        {
            if (arr1.Length != arr2.Length)
                return false;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i].Length != arr2[i].Length)
                    return false;
            }
            return true;
        }
    }
}