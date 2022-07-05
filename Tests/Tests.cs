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
        public void Can_Sort_Simple_Types_Via_Counting_Sort()
        {
            var sorter = new CountingSortWithSimpleType(GetInitialArray());

            var sortedArray = sorter.Run();

            CollectionAssert.AreEqual(_sortedArray, sortedArray);
        }

        [Test]
        public void Can_Sort_Custom_Types_Via_Counting_Sort()
        {
            var users = new User[]
            {
                new User(0, "a"),
                new User(1, "b"),
                new User(0, "c"),
                new User(2, "d"),
                new User(0, "e"),
                new User(3, "f"),
            };


            var sortedArray = new CountingSortWithCustomType(users).Run();


            var expectedSortedUsers = new User[]
            {
                new User(0, "a"),
                new User(0, "c"),
                new User(0, "e"),
                new User(1, "b"),
                new User(2, "d"),
                new User(3, "f")
            };
            CollectionAssert.AreEqual(expectedSortedUsers, sortedArray);
        }

        [Test]
        public void Can_Sort_Simple_Types_Via_Radix_Sort()
        {
            var initialArray = new[] { 333, 555, 351, 144, 132, 123 };
            var sortedArray = new[] { 123, 132, 144, 333, 351, 555 };

            var sorter = new RadixSortWithSimpleType(GetInitialArray(initialArray));

            var result = sorter.Run();

            CollectionAssert.AreEqual(sortedArray, result);
        }


        #region Support Methods

        private int[] GetInitialArray(int[] array = null)
        {
            var res = array ?? _initialArray;

            var tmpArray = new int[res.Length];

            res.CopyTo(tmpArray, 0);

            return tmpArray;
        }

        #endregion
    }
}