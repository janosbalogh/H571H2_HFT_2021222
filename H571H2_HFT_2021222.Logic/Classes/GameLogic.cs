using H571H2_HFT_2021222.Models;
using H571H2_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H571H2_HFT_2021222.Logic
{
    class GameLogic : IGameLogic
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
    }
}
