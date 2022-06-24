using System;
using System.Collections;

namespace DataStructures
{
    public class CustomStack <T> : IEnumerable
        where  T : IComparable<T>
    {
        private CustomLinkedList<T> _elements; // Uses a CustomLinkedList for the Heap
        public int Count { get; private set; } // Count of elements in a Heap

        public CustomStack()
        {
            _elements = new CustomLinkedList<T>();
            Count = 0;
        }

        public void Push(T element) // Adds an element to stack
        {
            _elements.AddLast(element); // Uses AddLast from a CustomLinkedList
            Count++; // Increases the Count 
        }

        public T Pop() // Deletes an element from the stack
        {
            switch (Count)
            {
                case 0: // If Count == 0 it write a log about it
                    Console.WriteLine("Stack is empty");
                    return default;
                
                case 1: // If Count == 1 it creates a new CustomLinkedList
                {
                    var lastElementOfSack = _elements.Tail.Value;
                    _elements = new CustomLinkedList<T>();
                    Count--;
                    return lastElementOfSack;
                }
            }

            var elementOfSack = _elements.Tail.Value; // Otherwise it deletes last element and reduces the Count
            _elements.Tail = _elements.Tail.Previous;
            Count--;
            
            return elementOfSack;
        }

        public T Peek() // Returns last element from a CustomLinkedList if Count > 0 otherwise it returns a default
        {
            return Count > 0 ? _elements.Tail.Value : default;
        }

        public void PrintAll() // Prints all elements
        {
            _elements.PrintAllReverse();
        }

        public IEnumerator GetEnumerator()
        {
            return _elements.GetEnumerator(true);
        }
    }
}