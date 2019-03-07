using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class ServiceReader
    {
        public bool RegisterReader(Reader reader, out string message)
        {
            try
            {
                using (var db = new LiteDatabase(@"library.db"))
                {
                    var readers = db.GetCollection<Reader>("Readers");

                    readers.Insert(reader);
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
        public Reader ReaderLogOn(string login, string password, out string message)
        {

            Reader reader = null;

            try
            {
                using (var db = new LiteDatabase(@"library.db"))
                {
                    var readers = db.GetCollection<Reader>("Readers");

                    IEnumerable<Reader> results =
                        readers.Find(x => x.login.Equals(login) &&
                                        x.password.Equals(password));
                    if (results.Any())
                    {
                        message = "";
                        return results.FirstOrDefault(); ;
                    }
                    else
                    {
                        message = "Неправильно ввели логин или пароль";
                        return reader;

                    }
                    
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return reader;
            }
        }
    }
}
