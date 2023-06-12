using H571H2_HFT_2021222.Models;
using H571H2_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H571H2_HFT_2021222.Logic.Classes
{
    public class PersonLogic : IPersonLogic
    {
        IRepository<Person> personRepository;

        public PersonLogic(IRepository<Person> personRepository)
        {
            this.personRepository = personRepository;
        }

        public void Create(Person item)
        {
            this.personRepository.Create(item);
        }

        public void Delete(int id)
        {
            this.personRepository.Delete(id);
        }

        public Person Read(int id)
        {
            return this.personRepository.Read(id);
        }

        public IQueryable<Person> ReadAll()
        {
            return this.personRepository.ReadAll();
        }

        public void Update(Person item)
        {
            this.personRepository.Update(item);
        }

        public IEnumerable<KeyValuePair<string, int>> ExecutiveSalaryAbove1000Employee()
        {
            return from x in personRepository.ReadAll()
                   where x.Company.EmployeeCount >= 1000
                   select new KeyValuePair<string, int>
                   (x.PersonName, x.Salary);
        }
        
    }
}
