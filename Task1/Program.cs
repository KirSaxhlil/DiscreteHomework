﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CombClasses;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f' };
            Combination obj = new Combination(alphabet, 3);
            Console.WriteLine(obj.GetObj());
            while (obj.GetObj() != obj.GetLastObj())
            {
                obj.nextObj();
                Console.WriteLine(obj.GetObj());
            }
            Console.ReadLine();
        }
    }
}
