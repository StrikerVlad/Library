using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Reader : Human
    {
        public int ReaderId { get; set; }
        public string password { get; set; }
        public string login { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }

        public Reader(string name, string fname, DateTime dob, string password, string login, string Address, string TelephoneNumber, string Email):base(name, fname,dob)
        {
            this.name = name;
            this.password = password;
            this.login = login;
            this.Address = Address;
            this.TelephoneNumber = TelephoneNumber;
            this.Email = Email;
            this.DateofBirth = dob;
        }

        public Reader():base()
        {

        }
        public List<Accounts.Account> account = new List<Accounts.Account>();
    }
}

