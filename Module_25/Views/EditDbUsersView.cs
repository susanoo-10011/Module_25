using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_25.Views
{
    public class EditDbUsersView
    {
        public void Show()
        {
            Console.WriteLine("Добавить нового пользователя (нажмите 1)");
            Console.WriteLine("Удалить пользователя по Id (нажмите 2)");
            Console.WriteLine("Обновить имя пользователя (нажмите 3)");
            Console.WriteLine("Выдать книгу пользователю (нажмите 4)");

            UserRepository userRepository = new UserRepository();

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        userRepository.AddUsers();
                        break;
                    }
                case "2":
                    {
                        userRepository.RemoveUserById();
                        break;
                    }
                case "3":
                    {
                        userRepository.UpdateUserNameById();
                        break;
                    }
                case "4":
                    {
                        userRepository.UserTakeBook();
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
