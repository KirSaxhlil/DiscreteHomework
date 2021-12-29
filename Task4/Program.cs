using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CombClasses;
using System.IO;

namespace Task4
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
            int q2 = 0, qR = 0, q3 = 0; ;
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (q[i] > 1) qR++;
                if (q[i] == 2) q2++;
                if (q[i] == 3) q3++;
            }

            return q2+q3 == qR && q2 == r && q3 == 1;
        }
        static void Main(string[] args)
        {
            StreamWriter output = new StreamWriter("7-Length wrods.txt");
            ArrangementR obj = new ArrangementR(alphabet, 7);
            if (Check(obj, 1)) output.WriteLine(obj.GetObj());
            while (obj.GetObj() != obj.GetLastObj())
            {
                obj.nextObj();
                if (Check(obj, 1)) output.WriteLine(obj.GetObj());
            }
            output.Close();
            output = new StreamWriter("9-Length words.txt");
            obj = new ArrangementR(alphabet, 9);
            if (Check(obj, 2)) output.WriteLine(obj.GetObj());
            while (obj.GetObj() != obj.GetLastObj())
            {
                obj.nextObj();
                if (Check(obj, 2)) output.WriteLine(obj.GetObj());
            }
            output.Close();
        }
    }
}
