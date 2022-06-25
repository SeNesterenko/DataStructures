using System;
using System.Collections.Generic;

namespace DataStructures
{
    public static class Program 
    {
        public static void Main()
        {
            var k = new Heap<int>();
            
            k.Add(10);
            k.Add(20);
            k.Add(30);
            k.Add(40);
            k.Add(50);
            k.Add(60);
            k.Add(70);
            
            for (var i = 0; i < k.Count; i++)
            {
                Console.WriteLine(k[i]);
            }
        }
    }
}