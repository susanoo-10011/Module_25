using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_25.Entity
{
    public class BookEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Quantity { get; set; }
        public List<UserEntity> userEntities { get; set; } = new List<UserEntity>();
    }
}
