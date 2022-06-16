using System;

namespace DataStructures
{
    public class CustomQueue <T> where T : IComparable<T>
    {
        private CustomLinkedList<T> _elements; // Uses a CustomLinkedList for a Queue

        public int Count { get; private set; } // Count of elements in the Queue

        public CustomQueue()
        {
            _elements = new CustomLinkedList<T>();
            Count = 0; // Default = 0
        }

        public void Enqueue(T? element) // Adds an element to the tail of the Queue
        {
            _elements.AddLast(element);
            Count++; // Increases the count of elements
        }

        public T? Dequeue() // Deletes the first element and returns it
        {
            if (Count == 0) // If a Queue is empty it returns a log about it
            {
                Console.WriteLine("Queue is empty");
                return default;
            }
            
            var firstElementOfQueue = _elements.Head.Value; // Remembers the first element
            _elements.RemoveFirst(); // Delete the first element
            Count--; // Reduces the count of elements

            return firstElementOfQueue; // Returns the first element
        }

        public T? Peak() // Checks the first element without deleting
        {
            if (Count != 0) return _elements.Head.Value; // Returns it if the count of elements != 0
            Console.WriteLine("Queue is empty"); // Otherwise returns a log and a default value
            return default;
        }

        public void PrintAll() // Prints all elements
        {
            var currentElement = _elements.Head;

            for (var i = 0; i < _elements.Count; i++)
            {
                Console.WriteLine(currentElement.Value);
                currentElement = currentElement.Next;
            }
        }
    }
}