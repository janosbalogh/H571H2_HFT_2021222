using H571H2_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H571H2_HFT_2021222.Logic
{
    public interface IGameLogic
    {
        void Create(Game item);
        Game Read(int id);
        IQueryable<Game> ReadAll();
        void Update(Game item);
        void Delete(int id);
    }
}
