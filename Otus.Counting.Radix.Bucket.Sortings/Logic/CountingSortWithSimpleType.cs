using System.Collections.Generic;
using System.Linq;

namespace Otus.Counting.Radix.Bucket.Sortings.Logic
{
    public class CountingSortWithSimpleType
    {
        private int[] _array;
        private int? _denominator;


        public CountingSortWithSimpleType(int[] array, int? denominator = null)
        {
            _array = array;
            _denominator = denominator;
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
                var currentElement = ExtractDigitFrom(i);

                if (uniqueValuesArray.ContainsKey(currentElement))
                {
                    uniqueValuesArray[currentElement]++;
                }
                else
                {
                    uniqueValuesArray.Add(currentElement, 1);
                }
            }

            uniqueValuesArray = uniqueValuesArray.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

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
                var currentElement = ExtractDigitFrom(i);
                var indexUpperBound = --uniqueValuesArray[currentElement];
                
                newArray[indexUpperBound] = _array[i];
            }

            return newArray;
        }

        private int ExtractDigitFrom(int i)
        {
            if (!_denominator.HasValue)
                return _array[i];

            return (_array[i] % _denominator.Value) / (_denominator.Value / 10);
        }

        #endregion
    }
}
