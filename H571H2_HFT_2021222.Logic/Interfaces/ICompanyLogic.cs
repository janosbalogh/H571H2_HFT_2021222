using H571H2_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H571H2_HFT_2021222.Logic
{
    public interface ICompanyLogic
    {
        void Create(Company item);
        Company Read(int id);
        IQueryable<Company> ReadAll();
        void Update(Company item);
        void Delete(int id);
    }
}
