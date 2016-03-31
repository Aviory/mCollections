using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LList2_2
{
    public class LList1x : IList
    {
        Header header = new Header();
        public class Header
        {
            public Node top = null;
            public Node last = null;
        }
        public class Node
        {
            public int val = 0;
            public Node next;
            public Node prev;
            public Node(int val)
            {
                this.val = val;
                next = null;
                prev = null;
            }
        }
        public Node start = null;
        public Node end = null;


        public int size()
        {
            int ret = 0;
            Node p = start;
            while (p != null)
            {
                ret++;
                p = p.next;
            }
            return ret;
        }

        public void clear()
        {
            start = null;
            end = null;
        }

        public void init(int[] ini)
        {
            if (ini == null)
            {
                ini = new int[0];
            }

            for (int i = ini.Length - 1; i >= 0; i--)
            {
                addStart(ini[i]);
            }

        }

        public int[] toArray()
        {
            int[] tmp = new int[size()];

            int i = 0;
            Node p = start;
            for (i = 0; i < tmp.Length; i++)
            {
                tmp[i] = p.val;
                p = p.next;
            }

            return tmp;
        }

        public void set(int pos, int val)
        {
            Node p = start;
            if (p == null)
            {
                throw new IndexOutOfRangeException();
            }
            int ret = 0;
            Node tmp = new Node(val);
            if (p == null)
            {
                p = new Node(p.val);
            }
            while (ret != pos)
            {
                p = p.next;
                ret++;
            }
            p.val = val;
        }

        public int get(int pos)
        {
            if (pos < 0 || pos > size())
            {
                throw new NullReferenceException();
            }
            if (start == null)
            {
                throw new IndexOutOfRangeException();
            }
            Node p = start;

            int ret = 0;
            while (ret != pos)
            {
                p = p.next;
                ret++;
            }
            return p.val;
        }

        public void addStart(int val)
        {
            Node tmp = new Node(val);

            if (start == null)
            {
                start = tmp;
                end = tmp;
            }
            else
            {
                tmp.next = start;
                tmp.next.prev = tmp;
                start = tmp;
                tmp.prev = null;
            }
        }

        public void addEnd(int val)
        {
            if (start == null)
            {
                start = new Node(val);
                end = start;
                return;
            }

            Node p = start;
            while (p != end)
            {
                p = p.next;
            }
            p.next = new Node(val);
            p.next.prev = p;
        }

        public void addPos(int pos, int val)
        {
            if (pos < 0 || pos > size())
            {
                throw new IndexOutOfRangeException();
            }

            if (pos == 0)
            {
                addStart(val);
            }
            else if (pos == size())
            {
                addEnd(val);
            }
            else
            {
                Node p = start;
                Node tmp = new Node(val);
                for (int i = 0; i < pos - 1; i++)
                {
                    p = p.next;
                }
                tmp.prev = p;
                tmp.next = p.next;
                p.next.prev = tmp;
                p.next = tmp;
            }
        }

        public int delStart()
        {
            if (start == null)
            {
                throw new IndexOutOfRangeException();
            }

            int ret = start.val;
            if (start == end)
            {
                start = end = null;
                return ret;
            }
            start = start.next;
            start.prev = null;
            return ret;
        }

        public int delEnd()
        {

            if (start == null)
            {
                throw new IndexOutOfRangeException();
            }

            int ret = 0;
            if (start == end)
            {
                ret = start.val;
                start = null;
            }
            else
            {
                Node p = start;
                while (p.next != null)
                {
                    p = p.next;
                }
                ret = p.val;
                p.prev.next = null;

            }
            return ret;
        }

        public int delPos(int pos)
        {
            int ret = 0;
            Node p = start;
            if (pos < 0 || p == null || pos >= size())
            {
                throw new IndexOutOfRangeException();
            }
            if (pos == 0 || start.next == null)
            {
                ret = delStart();
            }
            else if (pos == size() - 1)
            {
                ret = delEnd();
            }
            else
            {
                p = start;

                Node tmp = p;
                for (int i = 0; i < pos; i++)
                {
                    tmp = p;
                    p = p.next;
                }
                ret = p.val;
                p.prev.next = p.next;
                p.next.prev = p.prev;
                p = null;
            }
            return ret;
        }

        public int min()
        {
            if (start == null)
            {
                throw new IndexOutOfRangeException();
            }

            Node p = start;
            int min = p.val;
            while (p != null)
            {
                if (min > p.val)
                {
                    min = p.val;
                }
                p = p.next;
            }
            return min;
        }

        public int max()
        {
            if (start == null)
            {
                throw new NullReferenceException();
            }

            Node p = start;
            int max = p.val;
            while (p.next != null)
            {
                p = p.next;
                if (max < p.val)
                {

                    max = p.val;
                }
            }
            return max;
        }

        public int minIndex()
        {
            Node p = start;
            if (p == null)
            {
                throw new InvalidOperationException();
            }
            int m = min();
            int minIn = 0;
            while (p.val != m)
            {
                minIn++;
                p = p.next;

            }

            return minIn;
        }

        public int maxIndex()
        {
            Node p = start;
            if (p == null)
            {
                throw new InvalidOperationException();
            }
            int m = max();
            int maxIn = 0;
            while (p.val != m)
            {
                maxIn++;
                p = p.next;

            }

            return maxIn;
        }

        public void reverse()
        {
            Node p = null;
            
            while (start != null)
            {
                p = start;
                addStart(p.val);
                start = start.next;

            }
            start = p;
        }

        public void halfRevers()
        {
            Node p = start;
            if (p == end || p.next == end)
            {
                p = new Node(p.val);
            }
            else
            {
                int half = size() / 2;
                int d = size() % 2;
                for (int i = 0; i < half + d; i++)
                {
                    p = p.next;
                }

                Node tmp = start;
                int val = 0;
                for (int i = 0; i < half; i++)
                {
                    val = p.val;
                    p.val = tmp.val;
                    tmp.val = val;
                    p = p.next;
                    tmp = tmp.next;
                }
            }
        }

        public void sort()
        {
            if (start == null)
            {
                throw new NullReferenceException();
            }
            Node p = start;
            Node tmp;
            Node current;

            int tmpData = 0;
            bool flag = true;

            while (flag)
            {
                tmp = start;
                current = tmp.next;
                flag = false;
                while (current != end)
                {
                    if (tmp.val > current.val)
                    {
                        tmpData = tmp.val;
                        tmp.val = current.val;
                        current.val = tmpData;
                        flag = true;
                    }
                    tmp = tmp.next;
                    current = current.next;
                }

            }

        }
    }
}
