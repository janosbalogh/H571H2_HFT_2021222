using H571H2_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H571H2_HFT_2021222.Logic.Classes
{
    public interface IGameLogic
    {
        void Create(Game item);
        Game Read(int id);
        IQueryable<Game> ReadAll();
        void Update(Game item);
        void Delete(int id);
        public IEnumerable<KeyValuePair<string, int>> Top3CompanyWithMostGames();
        public IEnumerable<KeyValuePair<string, int>> CompaniesWithFpsGames();
        public IEnumerable<KeyValuePair<string, int>> CompanyNameLongerThan20();
        public IEnumerable<KeyValuePair<string, int>> TOP10MostPlayedGamesExecutiveAge();

    }
}
