using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class ServiceAdmin
    {

        public bool RegisterAdmin(Admin admin, out string message)
        {
            try
            {
                using (var db = new LiteDatabase(@"library.db"))
                {
                    var admins = db.GetCollection<Admin>("Admins");

                    admins.Insert(admin);
                }

                message = "Регистрация прошла успешно";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }

        }
        public Admin AdminLogOn(string login, string password, out string message)
        {
           
            Admin admin = null;

            try
            {
                
                using (var db = new LiteDatabase(@"library.db"))
                {
                    var admins = db.GetCollection<Admin>("Admins");

                    IEnumerable<Admin> results =
                        admins.Find(x => x.login.Equals(login) &&
                                        x.password.Equals(password));
                    if (results.Any())
                    {
                        message = "";
                        return results.FirstOrDefault(); ;
                    }
                    else
                    {
                        message = "Неправильно ввели логин или пароль, возможно вы не администратор";
                        return admin;
                       
                    }
                    
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return admin;
            }
        }

        public Reader Passwordswap(Reader r, out string message)
        {
            Reader reader = r;
            try
            {
                using (var db = new LiteDatabase(@"library.db"))
                {
                    var readers = db.GetCollection<Reader>("Readers");
                    var results = readers.Find(f => f.password == "" && f.login == "");

                    if (results.Any())
                    {
                        Console.WriteLine("Введите пароль");
                        string password = Console.ReadLine();
                        reader.password = password;
                        message = "";
                        return reader;
                    }

                    else
                    {
                        message = "Нет такого читателя";
                        return reader;
                    }
                }


                
            }

            catch(Exception ex)
            {
                message = ex.Message;
                return reader;
            }

            
        }

        
    }
}
