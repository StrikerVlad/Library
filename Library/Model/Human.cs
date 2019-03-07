using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public abstract class Human
    {
        public string name { get; set; }
        public string fname { get; set; }
        public DateTime DateofBirth { get; set; }

        public Human(string name, string fname, DateTime dob)
        {
            this.name = name;
            this.fname = fname;
            DateofBirth = dob;
        }
        public Human()
        {

        }
    }
}
