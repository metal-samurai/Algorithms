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

                    List<T> remainder = new(array);
                    remainder.RemoveAt(i);

                    foreach (T[] permutation in GetPermutations(remainder.ToArray()))
                    {
                        result.Add(Enumerable.Repeat(first, 1).Concat(permutation).ToArray());
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

        /// <summary>
        /// Given an array arr, find element pairs whose sum equal the second argument arg and return the sum of their indices.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        /// <remarks>You may use multiple pairs that have the same numeric elements but different indices. Each pair should use the lowest possible available indices. Once an element has been used it cannot be reused to pair with another element.</remarks>
        public static int Pairwise(int[] array, int target)
        {
            int result = 0;
            bool[] used = new bool[array.Length];
            
            Array.Fill(used, false);

            for (var i = 0; i < array.Length - 1; i++)
            {
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (!(used[i] || used[j]) && array[i] + array[j] == target)
                    {
                        result += i + j;
                        used[i] = true;
                        used[j] = true;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Write a function which takes an array of integers as input and returns an array of these integers in sorted order from least to greatest.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] BubbleSort(int[] array)
        {
            int[] result = new int[array.Length];
            bool swapped = true;

            array.CopyTo(result, 0);

            while (swapped)
            {
                swapped = false;

                for (var i = 0; i < result.Length - 1; i++)
                {
                    if (result[i + 1] < result[i])
                    {
                        var temp = result[i];
                        result[i] = result[i + 1];
                        result[i + 1] = temp;

                        swapped = true;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Write a function which takes an array of integers as input and returns an array of these integers in sorted order from least to greatest.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] SelectionSort(int[] array)
        {
            int[] result = new int[array.Length];
            List<int> remainder = new(array);

            for (var i = 0; i < array.Length; i++)
            {
                var lowestValue = remainder[0];
                var lowestIndex = 0;

                for (var j = 1; j < remainder.Count; j++)
                {
                    if (remainder[j] < lowestValue)
                    {
                        lowestValue = remainder[j];
                        lowestIndex = j;
                    }
                }

                result[i] = lowestValue;
                remainder.RemoveAt(lowestIndex);
            }

            return result;
        }

        /// <summary>
        /// Write a function which takes an array of integers as input and returns an array of these integers in sorted order from least to greatest.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] InsertionSort(int[] array)
        {
            List<int> result = new(array.Length) { array[0] };

            for (var i = 1; i < array.Length; i++)
            {
                bool inserted = false;
                for (var j = 0; j < result.Count; j++)
                {
                    if (result[j] >= array[i])
                    {
                        result.Insert(j, array[i]);
                        inserted = true;
                        break;
                    }
                }

                if (!inserted) result.Add(array[i]);
            }

            return result.ToArray();
        }

        /// <summary>
        /// Write a function which takes an array of integers as input and returns an array of these integers in sorted order from least to greatest.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] QuickSort(int[] array)
        {
            if (array.Length < 2) return array;

            List<int> left = new();
            List<int> middle = new();
            List<int> right = new();
            int pivot = array[0];

            foreach (int item in array)
            {
                if (item < pivot) left.Add(item);
                else if (item > pivot) right.Add(item);
                else middle.Add(item);
            }
            
            return QuickSort(left.ToArray()).Concat(middle).Concat(QuickSort(right.ToArray())).ToArray();
        }
    }

    
}