using System;
using System.Collections.Generic;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue();
            queue.Enqueue(new Person("Kate", 15));
            queue.Enqueue(new Person("Sam", 15));
            queue.Enqueue(new Person("Alice", 17));
            queue.Enqueue(new Person("Tom", 11));

            Console.WriteLine();
            var firstItem = queue.Dequeue();
            Console.Write($"Извлеченный элемент: ");
            firstItem.Print(); // Извлеченный элемент: Name: Kate Age: 15
            var secondItem = queue.Dequeue();
            Console.Write($"Извлеченный элемент: ");
            secondItem.Print(); // Извлеченный элемент: Name: Sam Age: 15
            queue = new Queue();
            var Item = queue.Peak(); //null
        }
    }

    /// <summary>
    /// Класс Person
    /// Содержит 2 публичных поля Name и Age
    /// Также должен быть конструктор который принимает Name, Age
    /// </summary>
    public class Person
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Print()
        {
            Console.WriteLine("Name: " + Name + " Age: " + Age);
        }
    }


     public class Queue
    {
        private LinkedList<Person> _elements;

        public int Count { get; private set; }

        public Queue()
        {
            _elements = new LinkedList<Person>();
            Count = 0;
        }

        public void Enqueue(Person element)
        {
            _elements.AddLast(element);
            Count++;
        }

        public Person Dequeue()
        {
            Person firstElementOfQueue = default;

            if (Count <= 0) return firstElementOfQueue == null ? default : firstElementOfQueue;
            firstElementOfQueue = _elements.First.Value;
            _elements.RemoveFirst();
            Count--;

            return firstElementOfQueue == null ? default : firstElementOfQueue;
        }

        public Person Peak()
        {
            return Count == 0 ? default : _elements.First.Value;
        }

        public void Print()
        {
            var currentElement = _elements.First;

            for (var i = 0; i < _elements.Count; i++)
            {
                Console.WriteLine(currentElement.Value);
                currentElement = currentElement.Next;
            }
        }
    }
}