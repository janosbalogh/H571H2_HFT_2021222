using H571H2_HFT_2021222.Endpoint.Services;
using H571H2_HFT_2021222.Logic;
using H571H2_HFT_2021222.Logic.Classes;
using H571H2_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;

        public PersonController(IPersonLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("PersonCreated", value);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Person value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("PersonUpdated", value);
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var personToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("PersonDeleted", personToDelete);
        }
    }
}
