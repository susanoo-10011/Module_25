using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_25.Views
{
    public class EditDbView
    {
        public void Show()
        {
            Console.WriteLine("Работа с данными пользователей (нажмите 1)");
            Console.WriteLine("Работа с данными книг (нажмите 2)");


            switch (Console.ReadLine())
            {
                case "1":
                    {
                        EditDbUsersView editDbUsersView = new EditDbUsersView();
                        editDbUsersView.Show();
                        break;
                    }
                case "2":
                    {
                        EditDbBooksView editDbBooksView = new EditDbBooksView();
                        editDbBooksView.Show();
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
