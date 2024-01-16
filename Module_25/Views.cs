using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module_25.Entity;

namespace Module_25
{
    public class V
    {

        public void MainView()
        {
            Console.WriteLine();
            Console.WriteLine("1. Получить список книг определенного жанра и вышедших между определенными годами.");
            Console.WriteLine("2. Получить количество книг определенного автора в библиотеке.");
            Console.WriteLine("3. Получить количество книг определенного жанра в библиотеке.");
            Console.WriteLine("4. Получить булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.");
            Console.WriteLine("5. Получить булевый флаг о том, есть ли определенная книга на руках у пользователя.");
            Console.WriteLine("6. Получить количество книг на руках у пользователя.");
            Console.WriteLine("7. Получение последней вышедшей книги.");
            Console.WriteLine("8. Получение списка всех книг, отсортированного в алфавитном порядке по названию.");
            Console.WriteLine("9. Получение списка всех книг, отсортированного в порядке убывания года их выхода.");

            Console.WriteLine();
            Console.WriteLine("Выберите действие:");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":

                    break;
                case "2":

                    break;
                case "3":

                    break;
                case "4":

                    break;
                case "5":

                    break;
                case "6":

                    break;
                case "7":

                    break;
                case "8":

                    break;
                case "9":

                    break;
            }
        }
    }
}
