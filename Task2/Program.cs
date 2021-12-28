using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CombClasses;
using System.IO;

namespace Task2
{
    class Program
    {
        static char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f' };
        static bool CheckA(ArrangementR obj)
        {
            int q = 0;
            for(int i = 0; i < obj.GetObj().Length; i++)
            {
                if (obj.GetObj()[i] == 'a') q++;
            }

            return q == 2;
        }

        static bool CheckOnlyA(ArrangementR obj)
        {
            int[] q = new int[alphabet.Length];
            for(int i = 0; i < obj.GetObj().Length; i++)
            {
                q[obj.GetIndOfChar(obj.GetObj()[i])]++;
            }
            bool notR = true;
            for(int i = 1; i < q.Length; i++)
            {
                if(q[i] > 1)
                {
                    notR = false;
                    break;
                }
            }
            return q[0] == 2 && notR;
        }
        static void Main(string[] args)
        {
            StreamWriter output = new StreamWriter("A Repetitions.txt");
            StreamWriter output2 = new StreamWriter("Only A Repetitions.txt");
            ArrangementR obj = new ArrangementR(alphabet, 5);
            if (CheckA(obj)) output.WriteLine(obj.GetObj());
            if (CheckOnlyA(obj)) output2.WriteLine(obj.GetObj());
            while (obj.GetObj() != obj.GetLastObj())
            {
                obj.nextObj();
                if(CheckA(obj)) output.WriteLine(obj.GetObj());
                if (CheckOnlyA(obj)) output2.WriteLine(obj.GetObj());
            }
            output.Close();
            output2.Close();
        }
    }
}
