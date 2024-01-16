using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_25.Views
{
    public class EditDbBooksView
    {
        public void Show()
        {
            BookRepository bookRepository = new BookRepository();

            Console.WriteLine("Добавить новую книгу (нажмите 1)");
            Console.WriteLine("Удалить книгу по Id (нажмите 2)");
            Console.WriteLine("Редактировать год издания (нажмите 3)");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        bookRepository.AddNewBook();
                        break;
                    }
                case "3":
                    {
                        bookRepository.DeleteBookById();
                        break;
                    }
                case "4":
                    {
                        bookRepository.UpdateBookYearById();
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
