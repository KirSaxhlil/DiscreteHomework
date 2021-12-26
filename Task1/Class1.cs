using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombClasses
{
    abstract class CombClass
    {
        protected char[] set;
        protected char[] obj;

        abstract public void nextObj();

        public string GetObj()
        {
            string str = "";
            for (int i = 0; i < obj.Length; i++) str += obj[i];
            return str;
        }
    }

    class ArrangementR: CombClass
    {
        int k;

        public ArrangementR(char[] set, int k)
        {
            this.set = set;
            this.k = k;
            obj = new char[k];
            for (int i = 0; i < k; k++) obj[i] = set[0];
        }

        public override void nextObj()
        {
            int i = k - 1;
            while (nextElem(ref obj[i--]));
        }

        protected bool nextElem(ref char elem)
        {
            int index = 0;
            for (int i = 0; i < set.Length; i++)
            {
                if (set[i] == elem) index = i;
            }
            if (index == set.Length - 1)
            {
                elem = set[0];
                return true;
            }
            else
            {
                elem = set[index + 1];
                return false;
            }
        }
    }
}
