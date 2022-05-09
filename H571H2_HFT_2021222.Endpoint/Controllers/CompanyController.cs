using H571H2_HFT_2021222.Logic;
using H571H2_HFT_2021222.Logic.Classes;
using H571H2_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace H571H2_HFT_2021222.Endpoint.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        ICompanyLogic logic;

        public CompanyController(ICompanyLogic logic)
        {
            this.logic = logic;
        }



        // GET: api/<SteamController>
        [HttpGet]
        public IEnumerable<Company> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<SteamController>/5
        [HttpGet("{id}")]
        public Company Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<SteamController>
        [HttpPost]
        public void Post([FromBody] Company value)
        {
            this.logic.Create(value);
        }

        // PUT api/<SteamController>/5
        [HttpPut]
        public void Put([FromBody] Company value)
        {
        }

        // DELETE api/<SteamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
