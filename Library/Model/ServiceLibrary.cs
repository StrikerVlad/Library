using System;
using LiteDB;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class ServiceLibrary
    {
        public bool AddBook(Book book, out string message)
        {
            try
            {
                using (var db = new LiteDatabase(@"library.db"))
                {
                    var Books = db.GetCollection<Book>("Books");

                    Books.Insert(book);
                }

                message = "Книга успешно добавлена";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }

        }

        public static List<Book> GetAllBooks()
        {
            try
            {
                using (var db = new LiteDatabase(@"library.db"))
                {
                    var books = db.GetCollection<Book>("Account");

                    return books.FindAll().ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public bool ReaderAddBook(Book book, out string message)
        {
            try
            {
                using (var db = new LiteDatabase(@"library.db"))
                {
                    var Books = db.GetCollection<Book>("Books");

                    Books.Insert(book);
                }

                message = "Книга успешно добавлена";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

    }
}
