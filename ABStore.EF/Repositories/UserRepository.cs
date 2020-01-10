using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Agregate.Repos;
using Agregate.Enteties;
using System.Data.Entity;

namespace ABStore.EF.Repositories
{
    public  class UserRepository:IUserRepo

    {
        //#region IUserRepo Members
        public List<User> getAllUsers()
        {
            using(var ctx = new ABStoreContext())
            {
                return ctx.Users.Include(x => x.UserLibrary).ToList();
            }
        }
       public void RegisterUser(User user)
        {
            using (var ctx = new ABStoreContext())
            {
                ctx.Users.Add(user);
                ctx.Entry(user).State = EntityState.Added;
                ctx.SaveChanges();

            }
        }
        public void UpdateUser(User user)
        {
            using (var ctx = new ABStoreContext())
            {
                ctx.Users.Attach(user);
                ctx.Entry(user).State = EntityState.Modified;

                foreach (var libItem in user.UserLibrary) {
                    if (libItem.Id == 0) {
                        ctx.Entry(libItem).State = EntityState.Added;
                    }
                }
                ctx.SaveChanges();
            }
        }
        public void DeleteUser(int userId)
        {
            using (var ctx = new ABStoreContext())
            {
                User usr = ctx.Users.Include(x => x.UserLibrary).First(x => x.Id == userId);
               
                ctx.Users.Remove(usr);
                ctx.SaveChanges();
            }
        }
        public User getUsrDetails(int usrId)
        {
            using (var ctx = new ABStoreContext())
            {
                return ctx.Users.Include(x => x.UserLibrary).First(x => x.Id == usrId);
            }
        }
        public User getUserByLogin(string usrLogin)
        {
            using (var ctx = new ABStoreContext())
            {
                return ctx.Users.Include(x => x.UserLibrary).First(x => x.Login == usrLogin);
            }
        }
        public List<LibraryItem> getUserLibrary(string usrLogin)
        {
            using(var ctx = new ABStoreContext())
            {
                return ctx.Users.First(x => x.Login == usrLogin).UserLibrary;

            }
           
        }
        //#endregion
    }

}
