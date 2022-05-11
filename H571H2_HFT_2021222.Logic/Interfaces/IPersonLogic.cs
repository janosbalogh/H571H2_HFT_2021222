using H571H2_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H571H2_HFT_2021222.Logic.Classes
{
    public interface IPersonLogic
    {
        void Create(Person item);
        Person Read(int id);
        IQueryable<Person> ReadAll();
        void Update(Person item);
        void Delete(int id);
        public IEnumerable<KeyValuePair<string, int>> ExecutiveSalaryAbove1000Employee();
    }
}
