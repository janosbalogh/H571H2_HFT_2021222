using H571H2_HFT_2021222.Models;
using H571H2_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H571H2_HFT_2021222.Logic.Classes
{
    public class GameLogic : IGameLogic
    {
        IRepository<Game> gameRepository;

        public GameLogic(IRepository<Game> gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public void Create(Game item)
        {
            this.gameRepository.Create(item);
        }

        public void Delete(int id)
        {
            this.gameRepository.Delete(id);
        }

        public Game Read(int id)
        {
            return this.gameRepository.Read(id);
        }

        public IQueryable<Game> ReadAll()
        {
            return this.gameRepository.ReadAll();
        }

        public void Update(Game item)
        {
            this.gameRepository.Update(item);
        }

        public IEnumerable<KeyValuePair<string, int>> Top3CompanyWithMostGames()
        {
            return (from x in gameRepository.ReadAll()
                    group x by x.Company.Name into g
                    orderby g.Count() descending
                    select new KeyValuePair<string, int>
                    (g.Key, g.Count())).Take(3);
        }
    }
}
