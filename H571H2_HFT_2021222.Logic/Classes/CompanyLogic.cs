﻿using H571H2_HFT_2021222.Models;
using H571H2_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H571H2_HFT_2021222.Logic
{
    class CompanyLogic : ICompanyLogic
    {
        IRepository<Company> companyRepository;

        public CompanyLogic(IRepository<Company> companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public void Create(Company item)
        {
            this.companyRepository.Create(item);
        }

        public void Delete(int id)
        {
            this.companyRepository.Delete(id);
        }

        public Company Read(int id)
        {
            return this.companyRepository.Read(id);
        }

        public IQueryable<Company> ReadAll()
        {
            return this.companyRepository.ReadAll();
        }

        public void Update(Company item)
        {
            this.companyRepository.Update(item);
        }
    }
}