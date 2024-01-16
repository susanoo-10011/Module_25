using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_25.Views
{
    public class DbQueryUsersView
    {
        public void Show()
        {
            Console.WriteLine("Найти пользователя по Id (нажмите 1)");
            Console.WriteLine("Показать всех пользователей (нажмите 2)");
            Console.WriteLine("Поиск книги на руках у пользователя (нажмите 3)");
            Console.WriteLine("Количество книг на руках у пользователя (нажмите 4)");

            UserRepository userRepository = new UserRepository();

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        userRepository.FindById();
                        break;
                    }
                case "2":
                    {
                        userRepository.FindAll();
                        break;
                    }
                case "3":
                    {
                        userRepository.UserHasBook();
                        break;
                    }
                case "4":
                    {
                        userRepository.UserBooksCount();
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
