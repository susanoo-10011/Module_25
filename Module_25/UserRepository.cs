using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module_25.Entity;

namespace Module_25
{
    public class UserRepository
    {
        public List<UserEntity> SelectUserById(AppContext db, int Id)
        {
            var user = db.Users.Where(user => user.Id == Id).ToList();
            return user;
        }

        public List<UserEntity> SelectUsers(AppContext db, int id)
        {
            var allUsersd = db.Users.ToList();
            return allUsersd;
        }

        public void AddUsers()
        {
            Console.Write("Введите имя нового пользователя: ");
            var name = Console.ReadLine();

            Console.Write("Введите Email нового пользователя: ");
            var email = Console.ReadLine();

            using (var db = new AppContext())
            {
                db.Users.Add(new UserEntity() { Name = name, Email = email });
                db.SaveChanges();
            }

        }

        public void RemoveUserById()
        {
            Console.Write($"Введите Id пользователя для удаления");

            int id = Convert.ToInt32(Console.ReadLine());

            using (var db = new AppContext())
            {
                var user = db.Users.Where(user => user.Id == id).FirstOrDefault();
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }


        public void UserTakeBook()
        {
            try
            {
                Console.Write("Введите Id пользователя, который хочет взять книгу: ");
                bool resultUserId = int.TryParse(Console.ReadLine(), out int userId);

                Console.Write("Введите Id книги, которую хочет взять пользователь");
                bool resultBookId = int.TryParse(Console.ReadLine(), out int bookId);

                using (var db = new AppContext())
                {
                    var user = db.Users.Include(u => u.Books).Where(user => user.Id == userId).FirstOrDefault();

                    var book = db.Books.Where(book => book.Id == bookId).FirstOrDefault();

                    user.Books.Add(book);
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FindById()
        {
            Console.Write("Введите ID пользователя для поиска: ");
            try
            {
                bool result = int.TryParse(Console.ReadLine(), out int id);
                using (var db = new AppContext())
                {
                    var user = db.Users.Where(user => user.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }
        }

        public bool UserHasBook()
        {
            try
            {
                Console.Write("Введите Id пользователя: ");
                bool resultUserId = int.TryParse(Console.ReadLine(), out int userId);

                Console.Write("Введите Id книги: ");
                bool resultBookId = int.TryParse(Console.ReadLine(), out int bookId);

                using (var db = new AppContext())
                {
                    var book = db.Books.Where(b => b.Id == bookId).FirstOrDefault();

                    var user = db.Users.Include(u => u.Books).Where(u => u.Id == userId).FirstOrDefault();

                    var result = db.Users.Include(us => us.Books).Where(us => us.Id == userId).Any(u => u.Books.Contains(book));
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение: {ex.Message}");
                return false;
            }
        }

        public void FindAll()
        {
            try
            {
                using (var db = new AppContext())
                {
                    var users = db.Users.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }
        }

        public int UserBooksCount()
        {
            try
            {
                Console.Write("Введите Id пользователя: ");
                bool resultUserId = int.TryParse(Console.ReadLine(), out int userId);

                using (var db = new AppContext())
                {
                    int result = db.Users.Include(us => us.Books).Where(u => u.Id == userId).Select(u => u.Books).Count();
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение: {ex.Message}");
                return 0;
            }
        }

        public void UpdateUserNameById()
        {
            Console.Write("Введите Id пользователя для обновления имени: ");

            try
            {
                bool result = int.TryParse(Console.ReadLine(), out var id);

                using (var db = new AppContext())
                {
                    var user = db.Users.Where(user => user.Id == id).FirstOrDefault();

                    Console.Write("Введите новое имя пользователя: ");
                    string newName = Console.ReadLine();

                    user.Name = newName;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение: {ex.Message}");
            }
        }
    }

}
