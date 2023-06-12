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
            if (item.GameName.Length<4)
            {
                throw new ArgumentException();
            }
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
                    group x by x.Company.CompanyName into g
                    orderby g.Count() descending
                    select new KeyValuePair<string, int>
                    (g.Key, g.Count())).Take(3);
        }

        public IEnumerable<KeyValuePair<string, int>> CompaniesWithFpsGames()
        {
            return (from x in gameRepository.ReadAll()
                   where x.Genre.Contains("FPS")
                   select new KeyValuePair<string, int>(x.Company.CompanyName, x.companyID)).Distinct();
        }

        public IEnumerable<KeyValuePair<string, int>> CompanyNameLongerThan20()
        {
            return from x in gameRepository.ReadAll()
                   where x.Company.CompanyName.Length > 20
                   group x by x.Company.CompanyName into g
                   orderby g.Key.Length descending
                   select new KeyValuePair<string, int>
                   (g.Key, g.Key.Length);
        }

        public IEnumerable<KeyValuePair<string, int>> TOP10MostPlayedGamesExecutiveAge()
        {
            return (from x in gameRepository.ReadAll()                    
                    orderby x.AverageForever descending
                    select new KeyValuePair<string, int>
                    (x.Company.Executive.PersonName, x.Company.Executive.Age)).Take(10).Distinct();
        }
    }
}
