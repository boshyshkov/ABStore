using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agregate.Enteties
{
   public class Game
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int Id { get; set; }
        public string Genre { get ; set; }
        public bool isAvailableDiscount { get; set; }
        public string PublisherName { get; set; }

    }
}
