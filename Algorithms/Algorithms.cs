using System.Diagnostics;

namespace Algorithms
{
    public static class Algorithms
    {
        public static int[] SymmetricDifference(params IEnumerable<int>[] arrays)
        {
            List<int> result = new();

            foreach (int[] array in arrays)
            {
                List<int> combined = new();

                foreach (var item in result)
                {
                    if (!array.Contains(item) && !combined.Contains(item)) combined.Add(item);
                }

                foreach (var item in array)
                {
                    if (!result.Contains(item) && !combined.Contains(item)) combined.Add(item);
                }

                result = combined;
            }

            return result.ToArray();
        }
    }
}