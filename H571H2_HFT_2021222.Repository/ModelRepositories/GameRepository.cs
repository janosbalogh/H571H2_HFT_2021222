using H571H2_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H571H2_HFT_2021222.Repository
{
    public class GameRepository : Repository<Game>, IRepository<Game>
    {
        public GameRepository(SteamDbContext ctx) : base(ctx){}
        public override Game Read(int id)
        {
            return ctx.Games.FirstOrDefault(t => t.GameID == id);
        }

        public override void Update(Game item)
        {
            var old = Read(item.GameID);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }               
            }
            ctx.SaveChanges();
        }
    }
}
