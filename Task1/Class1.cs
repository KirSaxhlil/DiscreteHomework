﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombClasses
{
    //Базовый класс
    abstract class CombClass
    {
        protected char[] set;
        protected char[] obj;

        abstract public void nextObj();

        virtual public string GetObj()
        {
            string str = "";
            for (int i = 0; i < obj.Length; i++) str += obj[i];
            return str;
        }

        abstract public string GetLastObj();

        protected int GetIndOfChar(char c)
        {
            for(int i = 0; i < set.Length; i++)
            {
                if (set[i] == c) return i;
            }
            return -1;
        }

        protected void swapElems(int i, int j)
        {
            char tmp = obj[i];
            obj[i] = obj[j];
            obj[j] = tmp;
        }
    }

    //Размещения с повторениями
    class ArrangementR: CombClass
    {
        protected int k;

        public ArrangementR(char[] set, int k)
        {
            this.set = set;
            this.k = k;
            obj = new char[k];
            for (int i = 0; i < k; i++) obj[i] = set[0];
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

        public override string GetLastObj()
        {
            string str = "";
            for (int i = 0; i < obj.Length; i++) str += set[set.Length - 1];
            return str;
        }
    }

    //Перестановки
    class Permutation : CombClass
    {
        public Permutation(char[] set)
        {
            this.set = set;
            obj = new char[set.Length];
            for(int i = 0; i < obj.Length; i++)
            {
                obj[i] = set[i];
            }
        }
        public override void nextObj()
        {
            int a = 0, t = 0, b = 0;
            for(int i = obj.Length-1; i > -1; i--)
            {
                if(GetIndOfChar(obj[i-1]) < GetIndOfChar(obj[i])) {
                    a = i-1;
                    t = GetIndOfChar(obj[i - 1]);
                    break;
                }
            }

            for (int i = obj.Length - 1; i > -1; i--)
            {
                if (GetIndOfChar(obj[i]) > t)
                {
                    b = i;
                    break;
                }
            }
            swapElems(a, b);

            for(int i = 1; i <= (obj.Length-a)/2; i++)
            {
                swapElems(a+i, obj.Length - i);
            }
        }

        public override string GetLastObj()
        {
            string str = "";
            for(int i = 0; i < obj.Length; i++)
            {
                str += set[set.Length - 1 - i];
            }
            return str;
        }
    }

    //Размещения
    class Arrangement : CombClass
    {
        int k;
        public Arrangement(char[] set, int k)
        {
            this.set = set;
            this.k = k;
            obj = new char[set.Length];
            for(int i = 0; i<obj.Length; i++)
            {
                obj[i] = set[i];
            }
}

        public override void nextObj()
        {
            int a = 0, t = 0, b = 0;
            do
            {
                a = 0; t = 0; b = 0;
                for (int i = obj.Length - 1; i > -1; i--)
                {
                    if (GetIndOfChar(obj[i - 1]) < GetIndOfChar(obj[i]))
                    {
                        a = i - 1;
                        t = GetIndOfChar(obj[i - 1]);
                        break;
                    }
                }

                for (int i = obj.Length - 1; i > -1; i--)
                {
                    if (GetIndOfChar(obj[i]) > t)
                    {
                        b = i;
                        break;
                    }
                }
                swapElems(a, b);

                for (int i = 1; i <= (obj.Length - a) / 2; i++)
                {
                    swapElems(a + i, obj.Length - i);
                }
            } while (a > k - 1);
        }

        public override string GetObj()
        {
            string str = "";
            for (int i = 0; i < k; i++) str += obj[i];
            return str;
        }

        public override string GetLastObj()
        {
            string str = "";
            for (int i = 0; i < k; i++)
            {
                str += set[set.Length - 1 - i];
            }
            return str;
        }
    }

    //Подмножества
    class SubSet : CombClass
    {
        protected bool[] keep;

        public SubSet(char[] set)
        {
            this.set = set;
            keep = new bool[set.Length];
            for (int i = 0; i < keep.Length; i++)
            {
                keep[i] = false;
            }
        }

        public override void nextObj()
        {
            bool state = false;
            for(int i = set.Length-1; i >= 0; i--)
            {
                if(!state)
                {
                    if(keep[i] == true)
                    {
                        keep[i] = false;
                    }
                    else if(keep[i] == false)
                    {
                        keep[i] = true;
                        state = true;
                    }
                }
            }
            /*int a = -1, b = -5, q = 0;
            for (int i = 0; i < keep.Length; i++) if (keep[i]) q++;
            bool f = false;
            /*for(int i = 0; i < keep.Length; i++)
            {
                if (keep[i] == true)
                {
                    b = a = i;
                    f = true;
                }
                //else if(f)
                //{
                //    b = i-1;
                //    break;
                //}
            }
            for(int i = set.Length-1; i >= 0; i--)
            {
                if(keep[i] == true)
                {
                    b = a = i;
                    break;
                }
            }

            for (int j = (q <= 1 ? 0 : a+1); j < keep.Length; j++)
            {
                if (keep[j] == true)
                {
                    b = j;
                    break;
                }
            }
            if (a == -1 && q == 0) keep[a + 1] = true;
            else if (b >= keep.Length-1)
            {
                if(a != set.Length-1)
                {
                    keep[b] = false;
                    if(a!= -1) keep[a] = false;
                    keep[a + 1] = true;
                    keep[a + 2] = true;
                }
                else
                {
                    for (int i = 0; i < q + 1; i++) keep[i] = true;
                    for (int i = q + 2; i < set.Length; i++) keep[i] = false;
                }
                //keep[b] = false;
                //keep[a + 1] = true;
                //keep[a + 2] = true;
            }
            else
            {
                keep[b] = false;
                keep[b + 1] = true;
            }*/
        }

        public override string GetObj()
        {
            string str = "";
            for(int i = 0; i < set.Length; i++)
            {
                if (keep[i]) str += set[i];
            }
            return str;
        }

        public override string GetLastObj()
        {
            string str = "";
            for (int i = 0; i < set.Length; i++)
            {
                str += set[i];
            }
            return str;
        }
    }

    //Сочетания
    class Combination : SubSet
    {
        int k;
        public Combination(char[] set, int k): base(set)
        {
            this.k = k;
        }

        public override void nextObj()
        {
            int q = 0;
            do
            {
                q = 0;
                base.nextObj();
                for (int i = 0; i < set.Length; i++)
                    if (keep[i]) q++;
            } while (q != k);
        }

        public override string GetLastObj()
        {
            string str = "";
            for (int i = 0; i < k; i++) str += set[i];
            return str;
        }
    }

    //Сочетания с повторениями
    class CombinationR : ArrangementR
    {
        public CombinationR(char[] set, int k) : base(set, k) { }

        public override void nextObj()
        {
            int i = k - 1;
            bool next = true;
            while (next)
            {
                next = false;
                if (GetIndOfChar(obj[i]) == set.Length - 1) {
                    while (obj[i] != obj[i-1])
                    {
                        nextElem(ref obj[i]);
                    }
                    nextElem(ref obj[i]);
                    for (int j = i + 1; j < obj.Length; j++) obj[j] = obj[i];
                    next = true;
                }
                else next = nextElem(ref obj[i]);
                i--;
            }
        }
    }
}
