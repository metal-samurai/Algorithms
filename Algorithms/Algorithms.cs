using System.Diagnostics;

namespace Algorithms
{
    /// <summary>
    /// For much of this I am intentionally avoiding LINQ for the sake of practice. In production much of this code would be unnecessary.
    /// </summary>
    public static class Algorithms
    {
        /// <summary>
        /// Create a function that takes two or more arrays and returns an array of their symmetric difference. The returned array must contain only unique values (no duplicates).
        /// </summary>
        /// <param name="arrays"></param>
        /// <returns></returns>
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

        public class InventoryItem : IComparable<InventoryItem>
        {
            public int Count { get; set; }
            public string Name { get; set; } = string.Empty;

            public int CompareTo(InventoryItem? other)
            {
                return this.Name.CompareTo(other?.Name);
            }
        }

        /// <summary>
        /// Compare and update the inventory stored in a 2D array against a second 2D array of a fresh delivery. Update the current existing inventory item quantities (in current). If an item cannot be found, add the new item and quantity into the inventory array. The returned inventory array should be in alphabetical order by item.
        /// </summary>
        /// <param name="current"></param>
        /// <param name="delivery"></param>
        public static void UpdateInventory(List<InventoryItem> current, IEnumerable<InventoryItem> delivery)
        {
            foreach (InventoryItem item in delivery)
            {
                var found = current.FindIndex(x => x.Name == item.Name);
                if (found == -1) current.Add(item);
                else current[found].Count += item.Count;
            }

            current.Sort();
        }

        public static List<T[]> GetPermutations<T>(T[] array)
        {
            List<T[]> result = new();

            if (array.Length == 1) result.Add(array);
            else
            {
                for (var i = 0; i < array.Length; i++)
                {
                    T first = array[i];
                    List<T> remainder = array.ToList();
                    remainder.RemoveAt(i);

                    foreach (T[] perm in GetPermutations(remainder.ToArray()))
                    {
                        List<T> permutation = new() { first };
                        permutation.AddRange(perm);
                        result.Add(permutation.ToArray());
                    }
                }
            }
            
            return result;
        }

        /// <summary>
        /// Return the number of total permutations of the provided string that don't have repeated consecutive letters.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int PermAlone(string input)
        {
            int permCount = 0;
            
            foreach (char[] permutation in GetPermutations(input.ToCharArray()))
            {
                bool repeat = false;

                for (var i = 0; i < permutation.Length - 1; i++)
                {
                    if (permutation[i] == permutation[i + 1])
                    {
                        repeat = true;
                        break;
                    }
                }

                if (!repeat) permCount++;
            }

            return permCount;
        }
    }

    
}