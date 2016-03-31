using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    interface HashTable
    {
        int size();      
        Person[] toArray();
        void clear();       
        void add(Person p);
        Person del(int hashCode);
        Person get(int hashCode);
    }
}
