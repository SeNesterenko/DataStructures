using System;
using System.Collections;

namespace DataStructures
{
    public class Heap <T> : IEnumerable
     where T : IComparable<T>
    {
        public int Count => _heap.Count; // Count of elements in a Heap

        private DynamicArray<T?> _heap; // Uses a DynamicArray for the Heap

        public T this[int index] => _heap[index]; // Indexer

        public Heap() => _heap = new DynamicArray<T?>();

        public void Add (T? element) // Adds a new element to the Heap
        { 
            _heap.Add(element);  
            ShiftUp(_heap.Count - 1); // Checks a value of parents and sorts
        }

        public T? ExtractMaximumElement() // Extracts a maximum value element
        {
            var result = _heap.Get(0); // Gets the first element because it has the maximum value
            _heap.Set(0, _heap.Get(_heap.Count - 1)); // Sets a minimal element to the first index
            _heap.Set(_heap.Count - 1, default); // Sets the last index to a default value
            
            ShiftDown(0); // Checks a child of the first element and sorts
            return result;
        }

        public T? Get(int index) // Gets an element by index
        {
            return _heap.Get(index);
        }

        private void ShiftUp(int index) // Sorts elements by parent 
        {
            var parentIndex = (index - 1) / 2; // A formula of a parent position

            if (_heap.Get(index)!.CompareTo(_heap.Get(parentIndex)) <= 0) return; // If a value of index < a value of parentIndex just returns
            _heap.Swap(index, parentIndex); // Swaps the parent element to the child element
            ShiftUp(parentIndex); // Checks a value of the parents and sorts
        }

        private void ShiftDown(int index) // Sorts elements by child
        {
            var leftChildIndex = 2 * index + 1; // Formula of a left child
            var rightChildIndex = 2 * index + 2; // Formula of a right child

            if (leftChildIndex >= _heap.Count) // If an index of the left child >= Count, than there is no point in performing the check further
            {
                return;
            }

            var maxChildIndex = leftChildIndex; // Lets assume that the element of the leftChild is larger

            if (rightChildIndex < _heap.Count &&
                _heap.Get(leftChildIndex)!.CompareTo(_heap.Get(rightChildIndex)) < 0) // If the leftChild is less than the rightChild
            {
                maxChildIndex = rightChildIndex; // The rightChild is larger
            }

            if (_heap.Get(index)!.CompareTo(_heap.Get(maxChildIndex)) > 0) // If the maxChildIndex > index just returns
            {
                return;
            }
            
            _heap.Swap(index, maxChildIndex); // Otherwise it swaps
            ShiftDown(maxChildIndex); // Checks a child of the first element and sorts
        }

        public IEnumerator GetEnumerator()
        {
            return new HeapEnumerator(this);
        }

        private class HeapEnumerator : IEnumerator
        {

            private Heap<T> _heap;
            private int _index;
            public HeapEnumerator(Heap<T> heap)
            {
                _heap = heap;
                _index = -1;
            }

            public bool MoveNext()
            {
                _index++;

                return _heap.Count > _index;
            }

            public void Reset()
            {
                _index = -1;
            }

            public object Current => _heap.Get(_index);
        }
    }
}