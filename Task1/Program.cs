using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CombClasses;
using System.IO;

namespace Task1
{
    class Program
    {
        static void OutObj(CombClass obj, StreamWriter output) //запись объектов в файл
        {
            output.WriteLine(obj.GetObj());
            while (obj.GetObj() != obj.GetLastObj())
            {
                obj.nextObj();
                output.WriteLine(obj.GetObj());
            }
        }

        static void Main(string[] args)
        {
            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f' };

            // Построение всех размещений с повторениями
            StreamWriter output = new StreamWriter("ArrangementsR.txt");
            ArrangementR obj1;
            for (int i = 1; i <= alphabet.Length; i++)
            {
                obj1 = new ArrangementR(alphabet, i);
                OutObj(obj1, output);
            }
            output.Close();

            // Построение всех перестановок
            output = new StreamWriter("Permutations.txt");
            Permutation obj2 = new Permutation(alphabet);
            OutObj(obj2, output);
            output.Close();

            // Построение всех размещений
            output = new StreamWriter("Arrangements.txt");
            Arrangement obj3;
            for (int i = 1; i <= alphabet.Length; i++)
            {
                obj3 = new Arrangement(alphabet, i);
                OutObj(obj3, output);
            }
            output.Close();

            // Построение всех подмножеств
            output = new StreamWriter("SubSets.txt");
            SubSet obj4 = new SubSet(alphabet);
            OutObj(obj4, output);
            output.Close();

            // Построение всех сочетаний
            output = new StreamWriter("Combinations.txt");
            Combination obj5;
            for (int i = 1; i <= alphabet.Length; i++)
            {
                obj5 = new Combination(alphabet, i);
                OutObj(obj5, output);
            }
            output.Close();

            // Построение всех сочетаний с повторениями
            output = new StreamWriter("CombinationsR.txt");
            CombinationR obj6;
            for (int i = 1; i <= alphabet.Length; i++)
            {
                obj6 = new CombinationR(alphabet, i);
                OutObj(obj6, output);
            }
            output.Close();
        }
    }
}
