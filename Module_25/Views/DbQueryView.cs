using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_25.Views
{
    public class DbQueryView
    {
        public void Show()
        {
            Console.WriteLine("Запрос в БД пользователей (нажмите 1)");
            Console.WriteLine("Запрос в БД книг (нажмите 2)");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        DbQueryUsersView dbQueryUsers = new DbQueryUsersView();
                        dbQueryUsers.Show();
                        break;
                    }
                case "2":
                    {
                        DbQueryBooksView dbQueryBooks = new DbQueryBooksView();
                        dbQueryBooks.Show();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Некорректная команда");
                        break;
                    }

            }
        }
    }
}
