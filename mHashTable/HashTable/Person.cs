using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class Person
    {
        public int index;
        public int id=0;
        private int age;
        private string FName;
        private string LName;
        public Person(string FName, string LName, int age)
        {
            id++;
            this.age = age;
            this.FName = FName;
            this.LName = LName;
        }
        public override int GetHashCode()
        {
            int hashCode = 0;
            char[] mas = (FName + LName).ToArray();
            foreach (char f in mas)
            {
                hashCode += f;
            }
            return hashCode;
        }
    }
}
