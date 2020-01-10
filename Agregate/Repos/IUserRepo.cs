using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agregate.Enteties;
namespace Agregate.Repos
{
   public interface IUserRepo
    {
        List<User> getAllUsers();
        User getUsrDetails(int usrId);
        void RegisterUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        User getUserByLogin(string userLogin);
        List<LibraryItem> getUserLibrary(string usrLogin);
    }
}
