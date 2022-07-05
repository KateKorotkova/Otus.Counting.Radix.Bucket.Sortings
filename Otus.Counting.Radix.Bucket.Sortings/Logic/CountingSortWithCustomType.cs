using System.Collections.Generic;
using System.Linq;

namespace Otus.Counting.Radix.Bucket.Sortings.Logic
{
    public class CountingSortWithCustomType
    {
        private User[] _array;


        public CountingSortWithCustomType(User[] array)
        {
            _array = array;
        }


        public User[] Run()
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

                if (uniqueValuesArray.ContainsKey(currentElement.Id))
                {
                    uniqueValuesArray[currentElement.Id]++;
                }
                else
                {
                    uniqueValuesArray.Add(currentElement.Id, 1);
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

        private User[] PushElementsToNewArray(Dictionary<int, int> uniqueValuesArray)
        {
            var newArray = new User[_array.Length];

            for (var i = _array.Length - 1; i >= 0; i--)
            {
                var currentElement = _array[i];
                var indexUpperBound = --uniqueValuesArray[currentElement.Id];
                
                newArray[indexUpperBound] = currentElement;
            }

            return newArray;
        }

        #endregion
    }

    public class User
    {
        public int Id { get; }
        public string Name { get; }


        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }


        public override bool Equals(object obj)
        {
            var otherUser = (User) obj;
            if (otherUser == null)
                return false;

            return Id == otherUser.Id && Name == otherUser.Name;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() + Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Id}, {Name}";
        }
    }
}
