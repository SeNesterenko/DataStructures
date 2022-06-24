using System;
using System.Collections.Generic;

namespace DataStructures
{
    public static class Program 
    {
        public static void Main()
        {
            var k = new CustomQueue<int>();
            
            k.Enqueue(10);
            k.Enqueue(20);
            k.Enqueue(30);
            k.Enqueue(40);
            k.Enqueue(50);
            k.Enqueue(60);
            k.Enqueue(70);
            
            foreach (var o in k)
            {
                Console.WriteLine(o); 
            }
        }
    }
}