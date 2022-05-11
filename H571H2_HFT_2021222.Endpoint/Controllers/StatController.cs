using H571H2_HFT_2021222.Logic.Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace H571H2_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IGameLogic gameLogic;
        IPersonLogic personLogic;

        public StatController(IGameLogic logic, IPersonLogic personLogic)
        {
            this.gameLogic = logic;
            this.personLogic = personLogic;
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> Top3CompanyWithMostGames()
        {
            return this.gameLogic.Top3CompanyWithMostGames();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> CompaniesWithFpsGames()
        {
            return this.gameLogic.CompaniesWithFpsGames();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> CompanyNameLongerThan20()
        {
            return this.gameLogic.CompanyNameLongerThan20();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> ExecutiveSalaryAbove1000Employee()
        {
            return this.personLogic.ExecutiveSalaryAbove1000Employee();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> TOP10MostPlayedGamesExecutiveAge()
        {
            return this.gameLogic.TOP10MostPlayedGamesExecutiveAge();
        }

    }
}
