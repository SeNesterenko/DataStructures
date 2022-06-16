using System;

namespace DataStructures
{
public class DynamicArray <T> where T : IComparable<T>
    {
        public int Count { get; private set; } // Count of elements in the array

        private int _capacity; // The total volume that the array contains
        private T[] _elements; // Array of elements which capacity increases when Count = _capacity 

        public DynamicArray()
        {
            _capacity = 4; // Default capacity
            _elements = new T[_capacity]; // Creates the array with a volume of _capacity
        }

        public void Add(T element) // Adds a new element to array
        {
            CheckCapacity(); // Checks a size of the array, if it is larger than _capacity it is doubled
            
            _elements[Count] = element; // Adds a new element to the end of the array 
            Count++; // Increases the count in the array
        }

        public void Clear() // Clears the array
        {
            _elements = new T [_capacity]; // Creates a  new array 
            Count = 0;
        }

        public int IndexOf(T element) // Searches an index of element
        {
            const int index = int.MaxValue; // If the element isn't found, it returns the Max value
            
            for (var i = 0; i < _elements.Length; i++) // Checks the entire array
            {
                if (_elements[i]!.Equals(element)) // If it found an element, it returns its index
                {
                    return i;
                } 
            }
            
            return index;
        }

        public void Insert(int index, T element) // Inserts an element to index position
        {
            Count++; // Increases a count of elements
            CheckCapacity(); // Checks a size of the array, if it is larger than _capacity it is doubled
            _elements[Count] = _elements[Count - 1]; // Moves the penultimate element 1 index forward
            
            for (var i = _elements.Length - 2; i > index; i--) // Moves other elements 1 index forward
            {
                _elements[i] = _elements[i - 1];
            }

            _elements[index] = element; // Inserts an element to index
        }

        public void Remove(T element) // Removes an element
        {
            var isFoundElement = false; // Creates a flag that the element is found
            
            for (var i = 0; i < _elements.Length - 1; i++) // Checks the entire array
            {
                if (_elements[i].Equals(element)) // If an element is found a flag changes
                {
                    isFoundElement = true;
                }

                if (isFoundElement) // After finding the element, move all other elements to the left
                {
                    _elements[i] = _elements[i + 1];
                }
            }

            Count--; // Reduces the total number of elements
        }

        public void RemoveAt(int index) // Removes an element from a specific index
        {
            for (var i = index; i < _elements.Length - 1; i++)
            {
                _elements[i] = _elements[i + 1]; // Moves all elements to the left to the place of the deleted element
            }

            Count--; // Reduces the total number of elements
        }

        public void Sort() // Sorts all elements in an ascending order
        {
            var temp = new T [Count]; // Creates a new array by Count
            
            for (var i = 0; i < Count; i++) // Copies the array to the new array by Count
            {
                temp[i] = _elements[i];
            }
            
            Array.Sort(temp); // Sorts the new array

            _elements = temp; // Assigns the values of new array to the old array after sorting
            _capacity = Count; // Assigns the value of Count to the _capacity

        }

        public void Reverse() // Reverses the array
        {
            var temp = new T [Count]; // Creates a new array by Count
            var counter = 0; // Creates a new counter

            for (var i = Count - 1; i >= 0; i--)  // Copies the reverse array to the new array by Count
            {
                temp[counter] = _elements[i]; // Copies the last index to the first index, the penultimate index to the second ...
                counter++; // Increases the new counter
            }
            
            _elements = temp; // Assigns the values of the new array to the old array after reverse
            _capacity = Count; // Assigns the value of Count to the _capacity

        }

        public T Get(int index) // Gets an element by index
        {
            return _elements[index];
        }

        public void Set(int index, T element) // Sets an element to an index
        {
            _elements[index] = element;
        }

        public void Swap(int firstIndex, int secondIndex) // Swaps two elements
        {
            (_elements[firstIndex], _elements[secondIndex]) = (_elements[secondIndex], _elements[firstIndex]);
        }

        private void CheckCapacity() //Checks a size of the array
        {
            if (Count != _capacity) return; // If a count of the array is less than _capacity it returns
            Array.Resize(ref _elements, _capacity * 2); // Otherwise double the size of the array
            _capacity *= 2;
        }
    }
}