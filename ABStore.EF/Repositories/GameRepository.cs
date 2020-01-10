using Agregate.Enteties;
using Agregate.Repos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABStore.EF.Repositories
{
    public class GameRepository : IGameRepo
    {
        public void CreateGame(Game game)
        {
            using (var ctx = new ABStoreContext())
            {
                ctx.Games.Add(game);
                ctx.SaveChanges();
            }
        }
        public void UpdateGame(Game game)
        {
            using (var ctx = new ABStoreContext())
            {
                ctx.Games.Attach(game);
                ctx.Entry(game).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }
        public void DeleteGame(Game game)
        {
            using (var ctx = new ABStoreContext())
            {
                ctx.Games.Remove(game);
                ctx.SaveChanges();
            }
        }
       public Game FindByFullName(string fullName)
        {
            using (var ctx = new ABStoreContext())
            {
                return ctx.Games.First(x => x.Name == fullName);
            }
        }
       public Game FindById(int gameId)
        {
            using (var ctx = new ABStoreContext())
            {
                return ctx.Games.First(x => x.Id == gameId);
            }
        }
        public List<Game> getAllGames()
        {
            using (var ctx = new ABStoreContext())
            {
                return ctx.Games.ToList();
            }
        }
    }
}
