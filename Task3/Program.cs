using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CombClasses;
using System.IO;

namespace Task3
{
    class Program
    {
        static char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f' };
        static bool Check(ArrangementR obj, int r)
        {
            int[] q = new int[alphabet.Length];
            for (int i = 0; i < obj.GetObj().Length; i++)
            {
                q[obj.GetIndOfChar(obj.GetObj()[i])]++;
            }
            int q2 = 0, qR = 0;
            for (int i = 0; i < obj.GetObj().Length; i++)
            {
                if (q[i] > 1) qR++;
                if (q[i] == 2) q2++;
            }

            return q2 == qR && q2 == r;
        }
        static void Main(string[] args)
        {
        }
    }
}
