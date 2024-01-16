using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_25.Entity
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }


        public List<BookEntity> Books { get; set; } = new List<BookEntity>();
    }
}
