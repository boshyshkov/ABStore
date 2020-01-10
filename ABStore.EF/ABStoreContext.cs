using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Agregate.Enteties;

namespace ABStore.EF
{
    class ABStoreContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibraryItem>().HasRequired(x => x.User).WithMany(x => x.UserLibrary).HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);
            
        }

    }
}
