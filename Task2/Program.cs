using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CombClasses;

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
        }
    }
}
