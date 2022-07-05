using System.Collections.Generic;
using System.Linq;

namespace Otus.Counting.Radix.Bucket.Sortings.Logic
{
    public class CountingSortWithSimpleType
    {
        private int[] _array;


        public CountingSortWithSimpleType(int[] array)
        {
            _array = array;
        }


        public int[] Run()
        {
            var uniqueValuesArray = FormUniqueValuesArray();

            return PushElementsToNewArray(uniqueValuesArray);
        }


        #region Support methods

        private Dictionary<int, int> FormUniqueValuesArray()
        {
            var uniqueValuesArray = new Dictionary<int, int>();

            for (var i = 0; i < _array.Length; i++)
            {
                var currentElement = _array[i];

                if (uniqueValuesArray.ContainsKey(currentElement))
                {
                    uniqueValuesArray[currentElement]++;
                }
                else
                {
                    uniqueValuesArray.Add(currentElement, 1);
                }
            }

            for (var i = 1; i < uniqueValuesArray.Count; i++)
            {
                var previousElement = uniqueValuesArray.ElementAt(i - 1);
                var currentElement = uniqueValuesArray.ElementAt(i);
                
                uniqueValuesArray[currentElement.Key] = currentElement.Value + previousElement.Value;
            }

            return uniqueValuesArray;
        }

        private int[] PushElementsToNewArray(Dictionary<int, int> uniqueValuesArray)
        {
            var newArray = new int[_array.Length];

            for (var i = _array.Length - 1; i >= 0; i--)
            {
                var currentElement = _array[i];
                var indexUpperBound = --uniqueValuesArray[currentElement];
                
                newArray[indexUpperBound] = currentElement;
            }

            return newArray;
        }

        #endregion
    }
}
