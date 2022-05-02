using H571H2_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H571H2_HFT_2021222.Repository
{
    class PersonRepository:Repository<Person>, IRepository<Person>
    {
        public PersonRepository(SteamDbContext ctx) : base(ctx){}

        public override Person Read(int id)
        {
            return ctx.People.FirstOrDefault(t => t.PersonID == id);
        }

        public override void Update(Person item)
        {
            var old = Read(item.PersonID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
