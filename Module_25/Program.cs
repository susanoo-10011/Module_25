using Microsoft.EntityFrameworkCore.Storage;
using Module_25.Entity;
using Module_25.Views;

namespace Module_25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                foreach (var item in CreateBooks())
                {
                    db.Books.Add(item);
                }
                db.SaveChanges();
            }

            using (var db = new AppContext())
            {
                foreach (var item in CreateUsers())
                {
                    db.Users.Add(item);
                }
                db.SaveChanges();
            }

                MainView mainView = new MainView();
                mainView.Show(); ;
        }

        public static List<BookEntity> CreateBooks()
        {
            var books = new List<BookEntity>
            {
                new BookEntity() { Name = "The Known World", Year = 2003, Author = "Edward P. Jones", Genre = "Historical Fiction" },
                new BookEntity() { Name = "Austerlitz", Year = 2001, Author = "W. G. Sebald", Genre = "Historical Fiction" },
                new BookEntity() { Name = "Never Let Me Go", Year = 2005, Author = "Kazuo Ishiguro", Genre = "Dystopian Fiction" },
                new BookEntity() { Name = "A Visit From The Goon Squad", Year = 2010, Author = "Jennifer Egan", Genre = "Literary Fiction" },
                new BookEntity() { Name = "Americanah", Year = 2013, Author = "Chimamanda Ngozi Adichie", Genre = "Literary Fiction" },
                new BookEntity() { Name = "The Sellout", Year = 2015, Author = "Paul Beatty", Genre = "Satire" },
                new BookEntity() { Name = "Freedom: A Novel", Year = 2010, Author = "Jonathan Franzen", Genre = "Literary Fiction" },
                new BookEntity() { Name = "The Human Stain", Year = 2000, Author = "Philip Roth", Genre = "Literary Fiction" }
            };

            return books;
        }

        public static List<UserEntity> CreateUsers()
        {
            var users = new List<UserEntity>
            {
             new UserEntity() { Name = "John Doe", Email = "john@example.com" },
             new UserEntity() { Name = "Jane Smith", Email = "jane@example.com" },
             new UserEntity() { Name = "Bob Johnson", Email = "bob@example.com" },
             new UserEntity() { Name = "Alice Williams", Email = "alice@example.com" },
             new UserEntity() { Name = "Charlie Brown", Email = "charlie@example.com" },
             new UserEntity() { Name = "Emily Davis", Email = "emily@example.com" }
            };
            return users;
        }
    }
}
