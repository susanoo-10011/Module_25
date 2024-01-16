using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module_25.Entity;

namespace Module_25
{
    public class BookRepository
    {
        public List<BookEntity> SelectBookById(AppContext db, int Id)
        {
            var book = db.Books.Where(book => book.Id == Id).ToList();
            return book;
        }

        public List<BookEntity> SelectBooks(AppContext db, int id)
        {
            var allBooks = db.Books.ToList();
            return allBooks;
        }

        public void AddNewBook()
        {
            Console.Write("Введите название новой книги: ");
            var name = Console.ReadLine();

            Console.Write("Введите ФИО автора книги: ");
            var author = Console.ReadLine();

            Console.Write("Введите жанр книги: ");
            var genre = Console.ReadLine();

            try
            {
                Console.Write("Введите год издания новой книги: ");
                var result = int.TryParse(Console.ReadLine(), out int year);
                if ((!result) || (year < 0))
                    throw new Exception();

                using (var db = new AppContext())
                {
                    var book = new BookEntity { Name = name, Author = author, Year = year, Genre = genre };
                    db.Books.Add(book);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }
        }

        public void DeleteBookById()
        {
            Console.Write($"Введите Id книги для удаления");

            try
            {
                bool result = int.TryParse(Console.ReadLine(), out var id);
                if (!result)
                    throw new Exception();

                using (var db = new AppContext())
                {
                    var book = db.Books.Where(book => book.Id == id).FirstOrDefault();
                    if (book == null)
                        throw new Exception();
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }
        }

        public void FindById()
        {
            Console.Write("Введите ID книги для поиска: ");
            try
            {
                bool result = int.TryParse(Console.ReadLine(), out int id);
                if (!result)
                    throw new Exception("Введен неверный Id");
                using (var db = new AppContext())
                {
                    var book = db.Books.Where(b => b.Id == id).FirstOrDefault();
                    Console.WriteLine($"\nВаша книга: {book.Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение: {ex.Message}");
            }
        }

        public void FindByTitle()
        {
            Console.Write("Введите название книги для поиска: ");
            try
            {
                var name = Console.ReadLine();
                using (var db = new AppContext())
                {
                    var book = db.Books.Where(b => b.Name == name).FirstOrDefault();
                    if (book == null)
                        Console.WriteLine("Книга с таким названием не найдена");
                    Console.WriteLine($"Ваша книга: {book.Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }
        }

        public void FindAll()
        {
            try
            {
                using (var db = new AppContext())
                {
                    var books = db.Books.ToList();
                    Console.WriteLine("Список книг: ");
                    foreach (var book in books)
                    {
                        Console.Write(book.Name + " | ");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }
        }

        public void GenreYearBookList()
        {
            try
            {
                using (var db = new AppContext())
                {
                    Console.Write("Введите жанр книги: ");
                    var genre = Console.ReadLine();
                    var findGenre = db.Books.Any(b => b.Genre == genre);

                    Console.Write("Введите начальный год диапазона поиска: ");
                    var resultYear1 = int.TryParse(Console.ReadLine(), out int year1);

                    Console.Write("Введите конечный год диапазона поиска: ");
                    var resultYear2 = int.TryParse(Console.ReadLine(), out int year2);

                    var books = db.Books.Where(b => b.Genre == genre && (b.Year >= year1 && b.Year <= year2)).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение: {ex.Message}");
            }
        }

        public void AutorsBooksCount()
        {
            try
            {
                Console.Write("Введите ФИО автора для поиска книг: ");
                var author = Console.ReadLine();
                using (var db = new AppContext())
                {
                    var isAuthor = db.Books.Any(b => b.Author == author);

                    var result = db.Books.
                        Where(b => b.Author == author).
                        Select(b => new { Author = b.Author, Name = b.Name, Year = b.Year, Quantity = b.Quantity }).
                        OrderBy(b => b.Name).ToList();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение: {ex.Message}");
            }
        }

        public void GenreBooksCount()
        {
            try
            {
                Console.Write("Введите жанр для поиска книг: ");
                var genre = Console.ReadLine();
                using (var db = new AppContext())
                {
                    var isGenre = db.Books.Any(b => b.Genre == genre);

                    var result = db.Books.
                        Where(b => b.Genre == genre).
                        Select(b => new { Name = b.Name, Quantity = b.Quantity }).
                        OrderBy(b => b.Name).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение: {ex.Message}");
            }
        }

        public void SordedBooksByTitle()
        {
            try
            {
                using (var db = new AppContext())
                {
                    var sortedBooks = db.Books.OrderBy(b => b.Name).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }
        }

        public void SortedBooksByYearDescending()
        {
            try
            {
                using (var db = new AppContext())
                {
                    var sortedBooks = db.Books.OrderByDescending(b => b.Year).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }
        }

        public void LastBook()
        {
            try
            {
                using (var db = new AppContext())
                {
                    var maxYear = db.Books.Max(b => b.Year);
                    var lastBook = db.Books.Where(b => b.Year == maxYear).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }
        }

        public void UpdateBookYearById()
        {
            Console.Write($"Введите Id книги для обновления года");

            try
            {
                bool result = int.TryParse(Console.ReadLine(), out var id);
                if (!result)
                    throw new Exception();

                using (var db = new AppContext())
                {
                    var book = db.Books.Where(book => book.Id == id).FirstOrDefault();
                    if (book == null)
                        throw new Exception();

                    Console.Write("Введите новый год издания");
                    var resultYear = int.TryParse(Console.ReadLine(), out int newYear);
                    if ((!resultYear) || (newYear < 0) || (newYear > DateTime.Now.Year))
                        throw new Exception();

                    book.Year = newYear;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }
        }
    }
}
