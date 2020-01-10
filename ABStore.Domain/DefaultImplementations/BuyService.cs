using ABStore.Domain.Interfaces;
using Agregate.Enteties;
using Agregate.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABStore.Domain.DefaultImplementations
{
    public class BuyService : IBuyService
    {
        private IUserRepo _UserRepo;
        private IGameRepo _GameRepo;
        private IPriceCalculationStrategy _priceCalculationStrategy;
       public  BuyService(IUserRepo userRepo, IGameRepo gameRepo, IPriceCalculationStrategy priceCalculationStrategy)
        {
            _priceCalculationStrategy = priceCalculationStrategy;
            _UserRepo = userRepo;
            _GameRepo = gameRepo;
        }
        public void BuyGame(Game game,User usr)
        {
            usr.Money -= (float)_priceCalculationStrategy.CalculatePrice(game);
            LibraryItem li = new LibraryItem();
            li.GameId = game.Id;
            li.User = usr;
            li.UserId = usr.Id;
            if(usr.UserLibrary == null)
            {
                usr.UserLibrary = new List<LibraryItem>();
            }
            
            usr.UserLibrary.Add(li);
            _UserRepo.UpdateUser(usr);
        }
    }
}
