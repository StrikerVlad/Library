using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.Model
{
    public class Admin : Human
    {
        public int AdminId { get; set; }
        public string password { get; set; }
        public string login { get; set; }

        public Admin(string name, string fname, int id, DateTime dob, string login, string password):base(name, fname, dob)
        {
            this.name = name;
            this.fname = fname;
            this.login = login;
            this.password = password;
            this.DateofBirth = dob;
            this.AdminId = id;
        }
        public Admin():base()
        {

        }

        public List<Accounts.Account> account = new List<Accounts.Account>();
    }
}
