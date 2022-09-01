using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tests
{
    [TestClass()]
    public class AlgorithmsTests
    {
        [TestMethod()]
        public void SymmetricDifferenceTest()
        {
            Assert.IsTrue(Algorithms.SymmetricDifference(new int[] { 1, 2, 3 }, new int[] { 5, 2, 1, 4 }).OrderBy(x => x).SequenceEqual(new int[] { 3, 4, 5 }));
            Assert.IsTrue(Algorithms.SymmetricDifference(new int[] { 1, 2, 3, 3 }, new int[] { 5, 2, 1, 4 }).OrderBy(x => x).SequenceEqual(new int[] { 3, 4, 5 }));
            Assert.IsTrue(Algorithms.SymmetricDifference(new int[] { 1, 2, 3 }, new int[] { 5, 2, 1, 4, 5 }).OrderBy(x => x).SequenceEqual(new int[] { 3, 4, 5 }));
            Assert.IsTrue(Algorithms.SymmetricDifference(new int[] { 1, 2, 5 }, new int[] { 2, 3, 5 }, new int[] { 3, 4, 5 }).OrderBy(x => x).SequenceEqual(new int[] { 1, 4, 5 }));
            Assert.IsTrue(Algorithms.SymmetricDifference(new int[] { 1, 1, 2, 5 }, new int[] { 2, 2, 3, 5 }, new int[] { 3, 4, 5, 5 }).OrderBy(x => x).SequenceEqual(new int[] { 1, 4, 5 }));
            Assert.IsTrue(Algorithms.SymmetricDifference(new int[] { 3, 3, 3, 2, 5 }, new int[] { 2, 1, 5, 7 }, new int[] { 3, 4, 6, 6 }, new int[] { 1, 2, 3 }).OrderBy(x => x).SequenceEqual(new int[] { 2, 3, 4, 6, 7 }));
            Assert.IsTrue(Algorithms.SymmetricDifference(new int[] { 3, 3, 3, 2, 5 }, new int[] { 2, 1, 5, 7 }, new int[] { 3, 4, 6, 6 }, new int[] { 1, 2, 3 }, new int[] { 5, 3, 9, 8 }, new int[] { 1 }).OrderBy(x => x).SequenceEqual(new int[] { 1, 2, 4, 5, 6, 7, 8, 9 }));
        }

        [TestMethod()]
        public void UpdateInventoryTest1()
        {
            List<Algorithms.InventoryItem> current = new(new Algorithms.InventoryItem[] { new Algorithms.InventoryItem() { Count = 21, Name = "Bowling Ball" }, new Algorithms.InventoryItem() { Count = 2, Name = "Dirty Sock" }, new Algorithms.InventoryItem() { Count = 1, Name = "Hair Pin" }, new Algorithms.InventoryItem() { Count = 5, Name = "Microphone" } });
            Algorithms.InventoryItem[] delivery = new Algorithms.InventoryItem[] { new Algorithms.InventoryItem() { Count = 2, Name = "Hair Pin" }, new Algorithms.InventoryItem() { Count = 3, Name = "Half-Eaten Apple" }, new Algorithms.InventoryItem() { Count = 67, Name = "Bowling Ball" }, new Algorithms.InventoryItem() { Count = 7, Name = "Toothpaste" } };
            Algorithms.InventoryItem[] expected = new Algorithms.InventoryItem[] { new Algorithms.InventoryItem() { Count = 88, Name = "Bowling Ball" }, new Algorithms.InventoryItem() { Count = 2, Name = "Dirty Sock" }, new Algorithms.InventoryItem() { Count = 3, Name = "Hair Pin" }, new Algorithms.InventoryItem() { Count = 3, Name = "Half-Eaten Apple" }, new Algorithms.InventoryItem() { Count = 5, Name = "Microphone" }, new Algorithms.InventoryItem() { Count = 7, Name = "Toothpaste" } };

            Algorithms.UpdateInventory(current, delivery);

            Assert.AreEqual(expected.Length, current.Count);
            
            for (var i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i].Name, current[i].Name);
                Assert.AreEqual(expected[i].Count, current[i].Count);
            }
        }

        [TestMethod()]
        public void UpdateInventoryTest2()
        {
            List<Algorithms.InventoryItem> current = new(new Algorithms.InventoryItem[] { new Algorithms.InventoryItem() { Count = 21, Name = "Bowling Ball" }, new Algorithms.InventoryItem() { Count = 2, Name = "Dirty Sock" }, new Algorithms.InventoryItem() { Count = 1, Name = "Hair Pin" }, new Algorithms.InventoryItem() { Count = 5, Name = "Microphone" } });
            Algorithms.InventoryItem[] delivery = Array.Empty<Algorithms.InventoryItem>();
            Algorithms.InventoryItem[] expected = new Algorithms.InventoryItem[] { new Algorithms.InventoryItem() { Count = 21, Name = "Bowling Ball" }, new Algorithms.InventoryItem() { Count = 2, Name = "Dirty Sock" }, new Algorithms.InventoryItem() { Count = 1, Name = "Hair Pin" }, new Algorithms.InventoryItem() { Count = 5, Name = "Microphone" } };

            Algorithms.UpdateInventory(current, delivery);

            Assert.AreEqual(expected.Length, current.Count);

            for (var i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i].Name, current[i].Name);
                Assert.AreEqual(expected[i].Count, current[i].Count);
            }
        }

        [TestMethod()]
        public void UpdateInventoryTest3()
        {
            List<Algorithms.InventoryItem> current = new();
            Algorithms.InventoryItem[] delivery = new Algorithms.InventoryItem[] { new Algorithms.InventoryItem() { Count = 2, Name = "Hair Pin" }, new Algorithms.InventoryItem() { Count = 3, Name = "Half-Eaten Apple" }, new Algorithms.InventoryItem() { Count = 67, Name = "Bowling Ball" }, new Algorithms.InventoryItem() { Count = 7, Name = "Toothpaste" } };
            Algorithms.InventoryItem[] expected = new Algorithms.InventoryItem[] { new Algorithms.InventoryItem() { Count = 67, Name = "Bowling Ball" }, new Algorithms.InventoryItem() { Count = 2, Name = "Hair Pin" }, new Algorithms.InventoryItem() { Count = 3, Name = "Half-Eaten Apple" }, new Algorithms.InventoryItem() { Count = 7, Name = "Toothpaste" } };

            Algorithms.UpdateInventory(current, delivery);

            Assert.AreEqual(expected.Length, current.Count);

            for (var i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i].Name, current[i].Name);
                Assert.AreEqual(expected[i].Count, current[i].Count);
            }
        }

        [TestMethod()]
        public void UpdateInventoryTest4()
        {
            List<Algorithms.InventoryItem> current = new(new Algorithms.InventoryItem[] { new Algorithms.InventoryItem() { Count = 0, Name = "Bowling Ball" }, new Algorithms.InventoryItem() { Count = 0, Name = "Dirty Sock" }, new Algorithms.InventoryItem() { Count = 0, Name = "Hair Pin" }, new Algorithms.InventoryItem() { Count = 0, Name = "Microphone" } });
            Algorithms.InventoryItem[] delivery = new Algorithms.InventoryItem[] { new Algorithms.InventoryItem() { Count = 1, Name = "Hair Pin" }, new Algorithms.InventoryItem() { Count = 1, Name = "Half-Eaten Apple" }, new Algorithms.InventoryItem() { Count = 1, Name = "Bowling Ball" }, new Algorithms.InventoryItem() { Count = 1, Name = "Toothpaste" } };
            Algorithms.InventoryItem[] expected = new Algorithms.InventoryItem[] { new Algorithms.InventoryItem() { Count = 1, Name = "Bowling Ball" }, new Algorithms.InventoryItem() { Count = 0, Name = "Dirty Sock" }, new Algorithms.InventoryItem() { Count = 1, Name = "Hair Pin" }, new Algorithms.InventoryItem() { Count = 1, Name = "Half-Eaten Apple" }, new Algorithms.InventoryItem() { Count = 0, Name = "Microphone" }, new Algorithms.InventoryItem() { Count = 1, Name = "Toothpaste" } };

            Algorithms.UpdateInventory(current, delivery);

            Assert.AreEqual(expected.Length, current.Count);

            for (var i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i].Name, current[i].Name);
                Assert.AreEqual(expected[i].Count, current[i].Count);
            }
        }

        [TestMethod()]
        public void PermAloneTest()
        {
            Assert.AreEqual(2, Algorithms.PermAlone("aab"));
            Assert.AreEqual(0, Algorithms.PermAlone("aaa"));
            Assert.AreEqual(8, Algorithms.PermAlone("aabb"));
            Assert.AreEqual(3600, Algorithms.PermAlone("abcdefa"));
            Assert.AreEqual(2640, Algorithms.PermAlone("abfdefa"));
            Assert.AreEqual(0, Algorithms.PermAlone("zzzzzzzz"));
            Assert.AreEqual(1, Algorithms.PermAlone("a"));
            Assert.AreEqual(0, Algorithms.PermAlone("aaab"));
            Assert.AreEqual(12, Algorithms.PermAlone("aaabb"));
        }

        [TestMethod()]
        public void PairwiseTest()
        {
            Assert.AreEqual(11, Algorithms.Pairwise(new int[] { 1, 4, 2, 3, 0, 5 }, 7));
            Assert.AreEqual(1, Algorithms.Pairwise(new int[] { 1, 3, 2, 4 }, 4));
            Assert.AreEqual(1, Algorithms.Pairwise(new int[] { 1, 1, 1 }, 2));
            Assert.AreEqual(10, Algorithms.Pairwise(new int[] { 0, 0, 0, 0, 1, 1 }, 1));
            Assert.AreEqual(0, Algorithms.Pairwise(Array.Empty<int>(), 100));
        }

        [TestMethod()]
        public void BubbleSortTest()
        {
            var test = new int[] { 1, 4, 2, 8, 345, 123, 43, 32, 5643, 63, 123, 43, 2, 55, 1, 234, 92 };

            Assert.IsTrue(Algorithms.BubbleSort(test).SequenceEqual(test.OrderBy(x => x)));
        }

        [TestMethod()]
        public void SelectionSortTest()
        {
            var test = new int[] { 1, 4, 2, 8, 345, 123, 43, 32, 5643, 63, 123, 43, 2, 55, 1, 234, 92 };

            Assert.IsTrue(Algorithms.SelectionSort(test).SequenceEqual(test.OrderBy(x => x)));
        }

        [TestMethod()]
        public void InsertionSortTest()
        {
            var test = new int[] { 1, 4, 2, 8, 345, 123, 43, 32, 5643, 63, 123, 43, 2, 55, 1, 234, 92 };

            Assert.IsTrue(Algorithms.InsertionSort(test).SequenceEqual(test.OrderBy(x => x)));
        }

        [TestMethod()]
        public void QuickSortTest()
        {
            var test = new int[] { 1, 4, 2, 8, 345, 123, 43, 32, 5643, 63, 123, 43, 2, 55, 1, 234, 92 };
            
            Assert.IsTrue(Algorithms.QuickSort(test).SequenceEqual(test.OrderBy(x => x)));
        }
    }
}