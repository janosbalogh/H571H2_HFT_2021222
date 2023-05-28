using H571H2_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H571H2_HFT_2021222.Repository
{
    public class CompanyRepository : Repository<Company>, IRepository<Company>
    {
        public CompanyRepository(SteamDbContext ctx) : base(ctx){}

        public override Company Read(int id)
        {
            return ctx.Companies.FirstOrDefault(x => x.CompanyID == id);
        }

        public override void Update(Company item)
        {
            var old = Read(item.CompanyID);
            
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t=> t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
