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
    }
}