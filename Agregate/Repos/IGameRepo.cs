using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agregate.Enteties;

namespace Agregate.Repos
{
     public interface IGameRepo
    {
        Game FindByFullName(string fullName);
        Game FindById(int gameId);
        List<Game> getAllGames();
        void CreateGame(Game game);
        void DeleteGame(Game game);
        void UpdateGame(Game game);

    }
}
