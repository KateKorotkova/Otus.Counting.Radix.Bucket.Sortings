using System;
using NUnit.Framework;
using Otus.Counting.Radix.Bucket.Sortings.Logic;

namespace Tests
{
    public class TestsForPerformance
    {
        private Random _random = new Random();


        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        [TestCase(100000)]
        [TestCase(1000000)]
        public void Buckets_Sort(int arraySize)
        {
            var array = GenerateArray(arraySize);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            new BucketSort(array).Run();
            watch.Stop();

            Console.WriteLine(watch.ElapsedMilliseconds);
        }

        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        [TestCase(100000)]
        [TestCase(1000000)]
        public void Counting_Sort(int arraySize)
        {
            var array = GenerateArray(arraySize);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            new CountingSortWithSimpleType(array).Run();
            watch.Stop();

            Console.WriteLine(watch.ElapsedMilliseconds);
        }

        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        [TestCase(100000)]
        [TestCase(1000000)]
        public void Radix_Sort(int arraySize)
        {
            var array = GenerateArray(arraySize);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            new CountingSortWithSimpleType(array).Run();
            watch.Stop();

            Console.WriteLine(watch.ElapsedMilliseconds);
        }


        #region Helpers

        private int[] GenerateArray(int size)
        {
            var array = new int[size];

            for (var i = 0; i < array.Length; i++)
            {
                array[i] = _random.Next();
            }

            return array;
        }

        #endregion
    }
}