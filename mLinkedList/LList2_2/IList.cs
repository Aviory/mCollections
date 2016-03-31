using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LList2_2
{
    interface IList
    {
        int size();
        void clear();
        void init(int[] ar);
        int[] toArray();
        void set(int pos, int val);
        int get(int pos);

        void addStart(int val);
        void addEnd(int val);
        void addPos(int pos, int val);

        int delStart();
        int delEnd();
        int delPos(int pos);

        int min();
        int max();
        int minIndex();
        int maxIndex();
        void reverse();
        void halfRevers();
        void sort();
    }
}
