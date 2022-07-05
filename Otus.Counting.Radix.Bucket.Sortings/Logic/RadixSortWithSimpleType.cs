using System;
using System.Linq;

namespace Otus.Counting.Radix.Bucket.Sortings.Logic
{
    public class RadixSortWithSimpleType
    {
        private int[] _array;


        public RadixSortWithSimpleType(int[] array)
        {
            _array = array;
        }


        public int[] Run()
        {
            var max = _array.Max();
            var numberOfDozens = max.ToString().Length;
            var startDenominator = (int) Math.Pow(10, numberOfDozens);

            for (var denominator = 10; denominator <= startDenominator; denominator *= 10)
            {
                _array = new CountingSortWithSimpleType(_array, denominator).Run();
            }

            return _array;
        }
    }
}
