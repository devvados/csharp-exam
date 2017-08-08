using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTask
{
    class Person
    {
        int _age;
        string _surname, _name, _telephone;

        public Person() { }

        public Person(string s, string n, int a, string t)
        {
            Name = n;
            Surname = s;
            Age = a;
            Telephone = t;
        }

        public string Surname { get => _surname; set => _surname = value; }
        public string Name { get => _name; set => _name = value; }
        public int Age { get => _age; set => _age = value; }
        public string Telephone { get => _telephone; set => _telephone = value; }
    }
}
