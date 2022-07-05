using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace Otus.Counting.Radix.Bucket.Sortings.Logic
{
    public class BucketSort
    {
        private int[] _array;

        public BucketSort(int[] array)
        {
            _array = array;
        }


        public int[] Run()
        {
            var max = _array.Max();
            
            var buckets = FormBuckets(max);

            ExtractElementsFromBuckets(buckets);

            return _array;
        }

        #region Support methods

        private void ExtractElementsFromBuckets(List<int>[] buckets)
        {
            var initialArrayIndex = 0;

            for (var i = 0; i < buckets.Length; i++)
            {
                var elementInBucket = buckets[i];
                if (elementInBucket == null || elementInBucket.Count == 0)
                    continue;

                if (elementInBucket.Count == 1)
                {
                    _array[initialArrayIndex++] = elementInBucket.First();
                }
                else
                {
                    elementInBucket.ForEach(x => { _array[initialArrayIndex++] = x; });
                }
            }
        }

        private List<int>[] FormBuckets(int max)
        {
            var buckets = new List<int>[_array.Length];

            for (var i = 0; i < _array.Length; i++)
            {
                var currentElement = _array[i];

                var indexInBucket = (currentElement * _array.Length) / (max + 1);

                var elementInBucket = buckets[indexInBucket];
                if (elementInBucket == null)
                {
                    buckets[indexInBucket] = new List<int> {currentElement};
                }
                else
                {
                    InsertIntoListInBucket(elementInBucket, currentElement);
                }
            }

            return buckets;
        }

        private void InsertIntoListInBucket(List<int> elementInBucket, int currentElement)
        {
            var indexToInsert = 0;

            for (var j = 0; j < elementInBucket.Count; j++)
            {
                if (elementInBucket[j] < currentElement)
                {
                    indexToInsert = j + 1;
                }
            }

            elementInBucket.Insert(indexToInsert, currentElement);
        }

        #endregion
    }
}
