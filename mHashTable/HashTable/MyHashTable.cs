using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class MyHashTable : IEnumerable, HashTable
    {
        Person[] mas = new Person[997];
        public int size()
        {
            int i = 0;
            foreach (Person p in mas)
            {
                if (p != null)
                    i++;
            }
            return i;
        }
        public Person[] toArray()
        {
            Person[] m = new Person [size()] ;
            int i = 0;
            foreach (Person p in mas)
            {
                if (p!= null)
                {
                    m[i] = p;
                    i++;
                }
            }
            return m;
        }
        public void clear()
        {
            mas = new Person[997];
        }
        public void add(Person p)
        {
            int i = colizionLine(p.GetHashCode() % 997);
            mas[i] = p;
        }

        private int colizionLine(int i)
        {
            if (mas[i] ==null)
                return i;
            else
                while(mas[i]!=null)
                {
                    if (i >= mas.Length)
                        i = 0;
                    else
                        i++;
                }
                return i;
        }
        //private int colizionRange(int i)
        //{
        //    if (mas[i] == null)
        //        return i;
        //    else
        //        mas[i] = new mas[11];
        //        {
        //            if (i >= mas.Length)
        //                i = 0;
        //            else
        //                i++;
        //        }
        //    return i;

        //}

        public Person del(int hashCode)
        {
            int index = hashCode % 997;
            Person tmp = mas[index];
            if (tmp.GetHashCode() == hashCode)
            {
                mas[index] = null;
                return tmp;
            }
            else
            {
                int i = 1;
                while (tmp.GetHashCode() != hashCode)
                {
                    if (index + i < mas.Length)
                    {
                        tmp = mas[index + i];
                        if (tmp.GetHashCode() == hashCode)
                        {
                            mas[index + i] = null;
                            return tmp;
                        }
                        else
                            i++;
                    }
                    else
                    {
                        index = 0;
                        i = 0;
                    }
                }
            }
            return tmp;
        }
        public Person get(int hashCode)
        {
            int index = hashCode % 997;
            Person tmp = mas[index];
            if (tmp.GetHashCode() == hashCode)
                return tmp;
            else {
                int i = 1;
                while (tmp.GetHashCode() != hashCode)
                {
                    if (index + i < mas.Length)
                    {
                        tmp = mas[index + i];

                        if (tmp.GetHashCode() == hashCode)
                            return tmp;
                        else
                            i++;
                    }
                    else
                    {
                        index = 0;
                        i = 0;
                    }
                }
            }
            return tmp;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Person p in mas)
            {
                yield return p;
            }
        }
    }
}
