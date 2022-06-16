using System;

namespace DataStructures
{

    public class CustomLinkedList <T> where  T : IComparable<T>
    {
        public class Node <T> // A peace of a CustomLinkedList
        {
            public Node<T> Next; // Next node
            public Node<T> Previous; // Previous node
            public T Value; // Value

            public Node(T value, Node<T> next, Node<T> previous)
            {
                Value = value;
                Next = next;
                Previous = previous;
            }
        }
        
        public Node<T>? Head; // First node in LinkedList
        public Node<T>? Tail; // Last node in LinkedList
        public int Count { get; private set; } // Count of Nodes

        public CustomLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void AddLast(T element) // Adds a new last node
        {
            if (CheckHeadOfLinkedList(element)) // Checks first node exists
            {
                return;
            }
            
            if (Head == Tail) // If Head == Node creates a new independence last node 
            {
                Tail = new Node<T>(element, null, Head);
                Head.Next = Tail;
                Count++;
                return;
            }

            var newNode = new Node<T>(element, null, Tail); // Otherwise adds a new Last node
            Tail.Next = newNode;
            Tail = newNode;
            Count++;
        }

        public void AddFirst(T element) // Adds a new first node
        {
            if (CheckHeadOfLinkedList(element)) // Checks the first node exists
            {
                return;
            }

            if (Head == Tail) // If Head == Node creates a new independence first node 
            {
                Head = new Node<T>(element, Tail, null);
                Tail.Previous = Head;
                Count++;
                return;
            }

            var newNode = new CustomLinkedList<T>.Node<T>(element, Head, null); // Otherwise adds a new first node
            Head.Previous = newNode;
            Head = newNode;
            Count++;
        }

        public void PrintAll() // Prints all nodes
        {
            var current = Head;
            Console.WriteLine(Head.Value);

            while (current.Next != null && current != null)
            {
                Console.WriteLine(current.Next.Value);
                current = current.Next;
            }
        }
        
        public void PrintAllReverse() // Reversed Print of all nodes
        {
            var current = Tail;
            Console.WriteLine(Tail.Value);

            while (current.Previous != null)
            {
                Console.WriteLine(current.Previous.Value);
                current = current.Previous;
            }
        }

        public void Remove(T element) // Removes the node by an element
        {
            var current = Head; // Gets the first element

            while (current != null) // Checks all nodes 
            {

                if (current.Value.Equals(element) && current.Equals(Head)) // If element is the Head, makes the second element the Head
                {
                    Head = current.Next;
                    Head.Previous = null;
                    Count--;
                    return;
                }

                if (current.Value.Equals(element) && current.Equals(Tail)) // If element is the Tail, makes the penultimate element the Tail
                {
                    Tail = current.Previous;
                    Tail.Next = null;
                    Count--;
                    return;
                }
                
                if (current.Value.Equals(element)) // If element is found 
                {
                    current.Previous.Next = current.Next; // Previous node remembers a next node
                    current.Next.Previous = current.Previous; // Next node remembers the previous node
                    Count--;
                    return;
                }

                if (current.Next != null) // If a next element is not equal to null
                {
                    current = current.Next; // Changes current element
                    continue;
                }

                current = null; // Otherwise it will be equal to null
            }
        }

        public void RemoveFirst() // Removes the first node
        {
            Head = Head.Next; // Head = next node

            if (Head == null)
            {
                Count--;
                return;
            }
            
            Head.Previous = null; // Previous link on node = null
            Count--;
            
            if (Head.Next == null) // If the node is left alone, equates the Tail and the Head 
            {
                Tail = Head;
            }
        }

        public void RemoveLast() // Removes the last node
        {
            Tail = Tail.Previous; // Tail = Previous node

            if (Tail == null)
            {
                Count--;
                return;
            }
            
            
            Tail.Next = null; // Next link on node = null
            Count--;


            if (Tail.Previous == null) // If the node is left alone, equates the Tail and the Head 
            {
                Head = Tail;
            }
        }

        public void Clear() // Clears all nodes
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        private bool CheckHeadOfLinkedList(T element) // Checks if the first node exists
        {
            if (Count != 0) return false; // If Count > 0 it continue
            Head = new Node<T>(element, null, null); // Otherwise creates a new node
            Tail = Head;
            Count++;
            return true;
        }
    }
}