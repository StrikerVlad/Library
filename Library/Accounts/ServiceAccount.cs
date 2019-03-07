using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Library.Accounts
{
    public class ServiceAccount
    {
        
        Random rnd = new Random();
        public Account CreateAdminAccount(Model.Admin admin)
        {
            Account account = new Account();
            account.Number = rnd.Next().ToString();
            account.Type = admin.GetType().ToString();
            account.id = rnd.Next(1, 1000);
            account.UserId = admin.AdminId;

            return account;
        }


        public Account CreateReaderAccount(Model.Reader reader)
        {
            Account account = new Account();
            account.Number = rnd.Next().ToString();
            account.Type = reader.GetType().ToString();
            account.id = rnd.Next(1, 1000);
            account.UserId = reader.ReaderId;

            return account;
        }


        public bool CreateAccountDb(Account account, out string message)
        {
            try
            {
                using (var db = new LiteDatabase(@"library.db"))
                {
                    var accounts = db.GetCollection<Account>("Account");

                    accounts.Insert(account);
                }

                message = "Создание аккаунта прошло успешно";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }
        public static List<Account> GetAccountByUserId(int id)
        {
            try
            {
                using (var db = new LiteDatabase(@"library.db"))
                {
                    var accounts = db.GetCollection<Account>("Account");

                    return accounts.FindAll().ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
