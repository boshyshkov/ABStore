using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agregate.Enteties
{
    public class User
    {
     
        public string Login { get; set; }
        public string Password { get; set; }
        public float Money { get; set; }
        public int Id { get; set; }
        public bool isPublisher { get; set; }
        public List<LibraryItem> UserLibrary { get; set; }
              
        

    }
   public class LibraryItem
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
