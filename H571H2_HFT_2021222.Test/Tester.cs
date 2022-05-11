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
        PersonLogic personLogic;

        Mock<IRepository<Company>> mockCompanyRepo;
        Mock<IRepository<Game>> mockGameRepo;
        Mock<IRepository<Person>> mockPersonRepo;

        [SetUp]
        public void Init()
        {
            mockCompanyRepo = new Mock<IRepository<Company>>();
            mockGameRepo = new Mock<IRepository<Game>>();
            mockPersonRepo = new Mock<IRepository<Person>>();

            
            mockGameRepo.Setup(c => c.ReadAll()).Returns(new List<Game>()
            {
                new Game("1#moba#Dota 2#1#1437883#285737#35726#1523#0#0#546508"){ Company = new Company("1#Valve#1#USA#360"){ Executive = new Person(){ Name ="Gabe Newell", Age = 56} }},
                new Game("2#fps#Counter-Strike: Global Offensive#1#5619875#749716#30200#766#0#0#730849"){ Company = new Company("1#Valve#1#USA#360"){ Executive = new Person(){ Name ="Gabe Newell", Age = 56 } }},
                new Game("3#battle royale#PUBG: BATTLEGROUNDS#2#1126362#883021#22329#778#0#0#407073"){Company = new Company("2#KRAFTON, Inc.#2#South Korea#2100"){ Executive = new Person(){ Name ="Kim Chang-han" , Age = 45} }},
                new Game("4#survival#Rust#3#676194#101067#21374#1332#3999#3999#82414"){ Company =new Company("3#Facepunch Studios#3#UK#20"){ Executive = new Person(){ Name ="Garry Newman", Age = 60 } }},
                new Game("5#sports, driving#Rocket League#4#489784#61605#15582#452#0#0#38236"){ Company = new Company("4#Psyonix LLC#4#USA#189"){ Executive = new Person(){ Name ="Dave Hagewood", Age = 53} }},
                new Game("6#fps#Tom Clancy's Rainbow Six Siege#5#915089#135174#13570#453#1999#1999#55863"){ Company = new Company("5#Ubisoft Montreal#5#Canada#2300"){ Executive = new Person(){ Name ="Yannis Mallat", Age = 39 } }}

            }.AsQueryable());

            mockPersonRepo.Setup(c => c.ReadAll()).Returns(new List<Person>()
            {
                new Person("1#Gabe Newell#210807#53#1"){ Company = new Company("1#Valve#1#USA#360") },
                new Person("2#Kim Chang-han#808384#44#2"){ Company = new Company("2#KRAFTON, Inc.#2#South Korea#2100") },
                new Person("3#Garry Newman#391659#46#3") { Company = new Company("3#Facepunch Studios#3#UK#20") },
                new Person("4#Dave Hagewood#476097#44#4") { Company = new Company("4#Psyonix LLC#4#USA#189") },
                new Person("5#Yannis Mallat#815266#56#5") { Company = new Company("5#Ubisoft Montreal#5#Canada#2300") }
            }.AsQueryable());

            companyLogic = new CompanyLogic(mockCompanyRepo.Object);
            gameLogic = new GameLogic(mockGameRepo.Object);
            personLogic = new PersonLogic(mockPersonRepo.Object);
        }


        [Test]
        public void CreateCompany()
        {
            var company = new Company() { Name = "Zen Studios" };

            companyLogic.Create(company);

            mockCompanyRepo.Verify(z => z.Create(company), Times.Once);
        }
        [Test]
        public void CreateGame()
        {
            var game = new Game() { Name = "3D Solitaire" };

            gameLogic.Create(game);

            mockGameRepo.Verify(z => z.Create(game), Times.Once);
        }
        [Test]
        public void CreatePerson()
        {
            var person = new Person() { Name = "Kovács Béla" };

            personLogic.Create(person);

            mockPersonRepo.Verify(z => z.Create(person), Times.Once);
        }

        [Test]
        public void Top3CompanyWithMostGamesTest()
        {
            var actual = gameLogic.Top3CompanyWithMostGames().ToList();
            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string,int>("Valve", 2),
                new KeyValuePair<string,int>("KRAFTON, Inc.", 1),
                new KeyValuePair<string,int>("Facepunch Studios",1),

            };
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CompaniesWithFpsGamesTest()
        {
            var actual = gameLogic.CompaniesWithFpsGames().ToList();
            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string,int>("Valve",1),
                new KeyValuePair<string,int>("Ubisoft Montreal",5),
            };
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CompanyNameLongerThan20Test()
        {
            var actual = gameLogic.CompanyNameLongerThan20().ToList();
            var expected = new List<KeyValuePair<string, int>>()
            {
                //There is no company with longer name than 20 character
            };
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ExecutiveSalaryAbove1000EmployeeTest()
        {
            var actual = personLogic.ExecutiveSalaryAbove1000Employee().ToList();
            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string,int>("Kim Chang-han",808384),
                new KeyValuePair<string,int>("Yannis Mallat", 815266),

            };
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TOP10MostPlayedGamesExecutiveAgeTest()
        {
            var actual = gameLogic.TOP10MostPlayedGamesExecutiveAge().ToList();

            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string,int>("Gabe Newell", 56),
                new KeyValuePair<string,int>("Kim Chang-han", 45),
                new KeyValuePair<string,int>("Garry Newman", 60),
                new KeyValuePair<string,int>("Dave Hagewood", 53),
                new KeyValuePair<string,int>("Yannis Mallat", 39),            

            };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateCompanyWithInvalidInputTest()
        {
            var test = new Company() { Name = "ASD" };


            Assert.That(() => companyLogic.Create(test), Throws.TypeOf<ArgumentException>());
        }
        public void CreateGameWithInvalidInputTest()
        {
            var test = new Game() { Name = "DSA" };


            Assert.That(() => gameLogic.Create(test), Throws.TypeOf<ArgumentException>());
        }
    }
}
