using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGSLibrary
{
    //ABSTRACT CLASS
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual new string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
