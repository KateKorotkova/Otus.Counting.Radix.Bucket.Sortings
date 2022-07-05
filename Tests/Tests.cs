using NUnit.Framework;
using Otus.Counting.Radix.Bucket.Sortings.Logic;

namespace Tests
{
    public class Tests
    {
        //private int[] _initialArray = { 32, 95, 16, 82, 24, 66, 35, 19, 75, 54, 40, 43, 93, 68 };
        //private int[] _sortedArray = { 16, 19, 24, 32, 35, 40, 43, 54, 66, 68, 75, 82, 93, 95 };

        private int[] _initialArray = { 0, 1, 0, 2, 0, 3, 0, 4, 2, 1, 3, 4, 0, 2, 3, 4 };
        private int[] _sortedArray = { 0, 0, 0, 0, 0, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4 };


        [Test]
        public void Can_Sort_Via_Bucket_Sort()
        {
            var sorter = new BucketSort(GetInitialArray());

            var sortedArray = sorter.Run();

            CollectionAssert.AreEqual(_sortedArray, sortedArray);
        }

        [Test]
        public void Can_Sort_simple_Types_Via_Counting_Sort()
        {
            var sorter = new CountingSortWithSimpleType(GetInitialArray());

            var sortedArray = sorter.Run();

            CollectionAssert.AreEqual(_sortedArray, sortedArray);
        }


        #region Support Methods

        private int[] GetInitialArray()
        {
            var tmpArray = new int[_initialArray.Length];

            _initialArray.CopyTo(tmpArray, 0);

            return tmpArray;
        }

        #endregion
    }
}