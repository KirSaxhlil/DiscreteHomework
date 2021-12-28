using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombClasses
{
    //Базовый класс
    abstract class CombClass
    {
        protected char[] set; //алфавит
        protected char[] obj; //текущий объект

        abstract public void nextObj(); //сгенерировать следующий объект

        virtual public string GetObj() //получить текущий объект
        {
            string str = "";
            for (int i = 0; i < obj.Length; i++) str += obj[i];
            return str;
        }

        abstract public string GetLastObj(); //получить последний объект

        protected int GetIndOfChar(char c) //номер элемента в алфавите
        {
            for(int i = 0; i < set.Length; i++)
            {
                if (set[i] == c) return i;
            }
            return -1;
        }

        protected void swapElems(int i, int j) //смена элементов местами
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
            while (nextElem(ref obj[i--])); //пока можно переходить на следующую позицию, меняем эелемент
        }

        protected bool nextElem(ref char elem)
        {
            int index = GetIndOfChar(elem);
            if (index == set.Length - 1) //если элемент является крайним в алфавите
            {
                elem = set[0]; //то берем первый
                return true; //можно переходить на следующую позицию
            }
            else
            {
                elem = set[index + 1]; //иначе берем следующий
                return false; //нельзя переходить на следующую позицию
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
            for(int i = obj.Length-1; i > -1; i--) //поиск первой позиции (1), где левый элемент меньше правого
            {
                if(GetIndOfChar(obj[i-1]) < GetIndOfChar(obj[i])) {
                    a = i-1;
                    t = GetIndOfChar(obj[i - 1]);
                    break;
                }
            }

            for (int i = obj.Length - 1; i > -1; i--) //поиск первой позиции, где эелемент больше чем элемент на позиции (1)
            {
                if (GetIndOfChar(obj[i]) > t)
                {
                    b = i;
                    break;
                }
            }
            swapElems(a, b); //меняем их

            for (int i = 1; i <= (obj.Length-a)/2; i++) //последовательность правее (1) переворачиваем
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
                for (int i = obj.Length - 1; i > -1; i--) //поиск первой позиции (1), где левый элемент меньше правого
                {
                    if (GetIndOfChar(obj[i - 1]) < GetIndOfChar(obj[i]))
                    {
                        a = i - 1;
                        t = GetIndOfChar(obj[i - 1]);
                        break;
                    }
                }

                for (int i = obj.Length - 1; i > -1; i--) //поиск первой позиции, где эелемент больше чем элемент на позиции (1)
                {
                    if (GetIndOfChar(obj[i]) > t)
                    {
                        b = i;
                        break;
                    }
                }
                swapElems(a, b); //меняем их

                for (int i = 1; i <= (obj.Length - a) / 2; i++) //последовательность правее (1) переворачиваем
                {
                    swapElems(a + i, obj.Length - i);
                }
            } while (a > k - 1); //выполняем, пока позиция (1) не зайдет в длину k
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
            //прохожу по всем двоичным последовательностям
            bool state = false;
            for(int i = set.Length-1; i >= 0; i--) //автомат x+1
            {
                if(!state) //состояние q0
                {
                    if(keep[i] == true) //1(0)
                    {
                        keep[i] = false;
                    }
                    else if(keep[i] == false) //0(1) -> q1
                    {
                        keep[i] = true;
                        state = true;
                    }
                }
                //в состоянии q1 изменений не происходит
            }
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
            } while (q != k); //ищем сочетание нужной длины
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
                if (GetIndOfChar(obj[i]) == set.Length - 1) { //если элемент крайний в алфавите...
                    obj[i] = obj[i - 1];
                    nextElem(ref obj[i]); //заменяем со сдвигом
                    for (int j = i + 1; j < obj.Length; j++) obj[j] = obj[i]; //и клонируем
                    next = true;
                }
                else next = nextElem(ref obj[i]);
                i--;
            }
        }
    }
}
