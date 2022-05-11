using NUnit.Framework;
using Moq;
using H571H2_HFT_2021222.Logic;
using H571H2_HFT_2021222.Models;
using H571H2_HFT_2021222.Repository;
using System.Collections.Generic;
using System.Linq;
using System;
using H571H2_HFT_2021222.Logic.Classes;

namespace H571H2_HFT_2021222.Test
{
    [TestFixture]
    public class Tester
    {
        CompanyLogic companyLogic;
        GameLogic gameLogic;
        Person personLogic;

        Mock<IRepository<Company>> mockCompanyRepo;
        Mock<IRepository<Game>> mockGameRepo;
        Mock<IRepository<Person>> mockPersonRepo;

        [SetUp]
        public void Init()
        {

        }
    }
}
