using Agregate.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABStore.Domain.Interfaces
{
   public interface IPriceCalculationStrategy
    {
        double CalculatePrice(Game game);
    }
}
