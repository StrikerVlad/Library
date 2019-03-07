using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Library;
using Library.Model;
using LiteDB;
using Library.Accounts;



namespace LibraryOrganize.Model
{
    public class StartMenu
    {
        public static Admin AdminUser = new Admin();
        public static ServiceAdmin ServiceAdmin = new ServiceAdmin();
        public static Reader ReaderUser = new Reader();
        public static ServiceReader ServiceReader = new ServiceReader();
        public static ServiceLibrary ServiceLibrary = new ServiceLibrary();
        public static ServiceAccount ServiceAccount = new ServiceAccount();
        
        public static void StartMenuLib()
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в библиотеку имени Первого Президента Республики Гондурас");
            Console.WriteLine("Нажмите 1 если хотите зарегистрироваться");
            Console.WriteLine("Нажмите 2 если у вас уже есть аккаунт");
            Console.WriteLine("Нажмите 3 если возомнили себя админом");


            int choice = Int32.Parse(Console.ReadLine());
            if(choice==1)
            {
                RegisterUserMenu();
            }

            else if(choice == 2)
            {
                LogMenu();
            }

            else if(choice == 3)
            {
                LogAdminMenu();
            }
        }
        public static void RegisterUserMenu()
        {
            Console.Clear();
            Console.WriteLine("Доброго времени суток, спасибо что выбрали именно нашу библиотеку");
            Console.WriteLine("Нажмите 1 для продолжения");
            int number = Int32.Parse(Console.ReadLine());
            if (number != 1) {
                Console.Clear();
                Console.WriteLine("Если вы только что устроились нашим администратором\n назовите PIN для вызова меню регистрации вашего аккаунта");
                Console.WriteLine("Если вы рядовой пользователь просим покинуть вас данное меню");
                int Pin = Int32.Parse(Console.ReadLine());
                if (Pin == 322)
                {
                    Admin admin = new Admin();

                    Console.Write("name: ");
                    admin.name = Console.ReadLine();

                    Console.Write("fname: ");
                    admin.fname = Console.ReadLine();

                    Console.Write("Login: ");
                    admin.login = Console.ReadLine();

                    Console.Write("Password: ");
                    admin.password = Console.ReadLine();

                    string message = "";
                    if (ServiceAdmin.RegisterAdmin(admin, out message))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(message);
                        Console.ForegroundColor = ConsoleColor.White;

                        Thread.Sleep(3000);
                        StartMenuLib();
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(message);
                        Console.ForegroundColor = ConsoleColor.White;
                    }


                }
                else
                {
                    Console.Clear();

                    Reader reader = new Reader();

                    Console.Write("name: ");
                    reader.name = Console.ReadLine();

                    Console.Write("fname: ");
                    reader.fname = Console.ReadLine();

                    Console.Write("Login: ");
                    reader.login = Console.ReadLine();

                    Console.Write("Password: ");
                    reader.password = Console.ReadLine();

                    Console.Write("Email: ");
                    reader.Email = Console.ReadLine();

                    Console.Write("Address: ");
                    reader.Address = Console.ReadLine();

                    Console.Write("DateofBirth: ");
                    reader.DateofBirth = Convert.ToDateTime(Console.ReadLine());

                    Console.Write("TelephoneNumber: ");
                    reader.TelephoneNumber = Console.ReadLine();
                    string message = "";
                    if (ServiceReader.RegisterReader(reader, out message))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(message);
                        Console.ForegroundColor = ConsoleColor.White;

                        Thread.Sleep(3000);
                        StartMenuLib();
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(message);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Форма регистрации пользователя\n");

                Reader reader = new Reader();

                Console.Write("name: ");
                reader.name = Console.ReadLine();

                Console.Write("fname: ");
                reader.fname = Console.ReadLine();

                Console.Write("Login: ");
                reader.login = Console.ReadLine();

                Console.Write("Password: ");
                reader.password = Console.ReadLine();

                Console.Write("Email: ");
                reader.Email = Console.ReadLine();

                Console.Write("Address: ");
                reader.Address = Console.ReadLine();

                Console.Write("DateofBirth: ");
                reader.DateofBirth = Convert.ToDateTime(Console.ReadLine());

                Console.Write("TelephoneNumber");
                reader.TelephoneNumber = Console.ReadLine();
                string message = "";
                if (ServiceReader.RegisterReader(reader, out message))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.White;

                    Thread.Sleep(3000);
                    StartMenuLib();
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public static void LogMenu()
        {
            Console.Clear();
            Console.WriteLine("");

            Console.Write("Введите логин");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            string password = Console.ReadLine();
            string message = "";
            Reader reader = ServiceReader.ReaderLogOn(login, password, out message);

            if(reader != null)
            {
                ReaderUser = reader;
                ReaderUser.account = ServiceAccount.GetAccountByUserId(reader.ReaderId);
                AuthorizeUserMenu();
            }
        }

        

        public static void LogAdminMenu()
        {
            Console.Clear();
            Console.WriteLine("");

            Console.Write("Введите логин");
            string login = Console.ReadLine();
            Console.Write("Введите пароль");
            string password = Console.ReadLine();
            string message = "";
            Admin admin = ServiceAdmin.AdminLogOn(login, password, out message);

            if(admin != null)
            {
                AdminUser = admin;
                AdminUser.account = ServiceAccount.GetAccountByUserId(AdminUser.AdminId);
                AuthorizeAdminMenu();
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        public static void AuthorizeUserMenu()
        {
            Console.Clear();
            Console.WriteLine("Доброго времени суток {0} {1}",ReaderUser.name, ReaderUser.fname);
            if (ReaderUser.account != null)
            {
                Console.WriteLine("Холоп! Приветствуем тебя. Выберите что вы хотите сделать?");
                Console.WriteLine("1.Посмотреть список доступных книг");
                Console.WriteLine("2.Предложить на рассмотрение свою книгу");

                int choice = Int32.Parse(Console.ReadLine());

                if(choice == 1)
                {
                    ServiceLibrary.GetAllBooks();
                }

                if(choice == 2)
                {
                    Book book = new Book();
                    Console.WriteLine("Code: ");
                    book.code = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Author: ");
                    book.author = Console.ReadLine();
                    Console.WriteLine("Name: ");
                    book.Name = Console.ReadLine();
                    Console.WriteLine("Type: ");
                    book.type = Console.ReadLine();

                    Random random = new Random();
                    if(random.Next()%2==0)
                    {
                        string message = "";
                        ServiceLibrary.AddBook(book, out message);
                        Console.WriteLine("Ваша книга была принята");
                    }

                    else
                    {
                        Console.WriteLine("Ваша книга никому не нужна");
                    }
                }
                
            }
            else
            {
                Console.WriteLine("На данный момент у вас нет действующего аккаунта");
                Console.WriteLine("7.Для создания нового аккаунта");
            }
            int menu = Int32.Parse(Console.ReadLine());
            if (menu == 7)
            {
                ServiceAccount serviceAcc = new ServiceAccount();
                Account acc = serviceAcc.CreateReaderAccount(ReaderUser);
                string message = "";
                if (serviceAcc.CreateAccountDb(acc, out message))
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.White;

                    ReaderUser.account = ServiceAccount.GetAccountByUserId(ReaderUser.ReaderId);

                    Thread.Sleep(3000);
                    AuthorizeUserMenu();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public static void AuthorizeAdminMenu()
        {
            Console.Clear();
            Console.WriteLine("Доброго времени суток {0} {1}", AdminUser.name, AdminUser.fname);
            if(AdminUser.account!=null)
            {
                Console.WriteLine("Здоровей видали! Чем сегодня будешь заниматься");
                Console.WriteLine("1.Посмотреть список доступных книг");
                Console.WriteLine("2.Посмотреть список книг которые находятся в библиотеке");
                Console.WriteLine("3.Забить в базу новую книгу");
                Console.WriteLine("4.Поменять пароль пользователю");
                int choice = Int32.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    ServiceLibrary.GetAllBooks();
                }

                if (choice == 2)
                {
                    ServiceLibrary.GetAllBooks();
                }
                if (choice == 3)

                {
                    Book book = new Book();
                    Console.WriteLine("Code: ");
                    book.code = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Author: ");
                    book.author = Console.ReadLine();
                    Console.WriteLine("Name: ");
                    book.Name = Console.ReadLine();
                    Console.WriteLine("Type: ");
                    book.type = Console.ReadLine();
                    string message = "";
                    ServiceLibrary.AddBook(book, out message);
                } 

                if(choice == 4)
                {
                    Reader r = new Reader();
                    Console.WriteLine("Login: ");
                    r.login = Console.ReadLine();
                    r.password = Console.ReadLine();
                    string message = "";
                    ServiceAdmin.Passwordswap(r, out message);
                }


            }

            else
            {
                Console.WriteLine("Ты что до сих пор аккаунт не создал");
                Console.WriteLine("7. Для создания нового аккаунта");
            }
            int menu = Int32.Parse(Console.ReadLine());
            if (menu == 7)
            {
                ServiceAccount serviceAcc = new ServiceAccount();
                Account acc = serviceAcc.CreateAdminAccount(AdminUser);
                string message = "";
                if (serviceAcc.CreateAccountDb(acc, out message))
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.White;

                    AdminUser.account = ServiceAccount.GetAccountByUserId(AdminUser.AdminId);

                    Thread.Sleep(3000);
                    AuthorizeAdminMenu();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
