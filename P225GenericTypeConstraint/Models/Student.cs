using P225GenericTypeConstraint.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P225GenericTypeConstraint.Models
{
    class Student : Human, ITest
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
    }
}
