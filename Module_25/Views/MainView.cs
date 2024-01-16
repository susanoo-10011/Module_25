using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_25.Views
{
    public class MainView
    {
        public void Show()
        {
            Console.WriteLine("Редактировать данные (нажмите 1)");
            Console.WriteLine("Произвести запрос (нажмите 2)");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        EditDbView editDbView = new EditDbView();
                        editDbView.Show();
                        break;
                    }
                case "2":
                    {
                        DbQueryView dbQueryView = new DbQueryView();
                        dbQueryView.Show();
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
