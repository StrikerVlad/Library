using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public struct Book
    {
        public string Name { get; set; }
        public int code { get; set; }
        public string type { get; set; }
        public string author { get; set; }

        public Book(string name, int code, string type, string author)
        {
            this.Name = name;
            this.code = code;
            this.type = type;
            this.author = author;
        }
    }
}
