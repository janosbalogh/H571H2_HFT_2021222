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
    public class PersonController : ControllerBase
    {
        IPersonLogic logic;
        

        public PersonController(IPersonLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<Person> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public Person Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<PersonController>
        [HttpPost]
        public void Create([FromBody] Person value)
        {
            this.logic.Create(value);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Person value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
