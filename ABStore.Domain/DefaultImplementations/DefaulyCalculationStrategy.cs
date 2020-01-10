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
   public class DefaultCalculationStrategy : IPriceCalculationStrategy
    {
        private IGameRepo _gameRepository;
       public DefaultCalculationStrategy(IGameRepo gameRepo)
        {
            _gameRepository = gameRepo;
        }
       public double CalculatePrice(Game game)
        {
            Game currGame;
            double price=0;
            currGame = _gameRepository.FindByFullName(game.Name);
            if(DateTime.Today.DayOfYear == 255 && currGame.isAvailableDiscount == true)
            {
                price = currGame.Price;
            }
            else
                price = currGame.Price + currGame.Price * 0.15;
            return price;
        }
    }
}
