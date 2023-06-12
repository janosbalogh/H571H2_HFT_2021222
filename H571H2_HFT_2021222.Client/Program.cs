using ConsoleTools;
using H571H2_HFT_2021222.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace H571H2_HFT_2021222.Client
{
    internal class Program
    {
        static RestService rest;

        #region CRUD
        static void Create(string entity)
        {
            if (entity == "Company")
            {
                Console.WriteLine("Enter a company Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the country: ");
                string country = Console.ReadLine();
                Console.WriteLine("Enter the number of employees: ");
                string employees = Console.ReadLine();
                rest.Post(new Company() { CompanyName = name, Country = country, EmployeeCount = int.Parse(employees) }, "company");
            }
            else if (entity == "Game")
            {
                Console.WriteLine("Enter a Game name: ");
                string name = Console.ReadLine(); 
                Console.WriteLine("Enter a genre: ");
                string genre = Console.ReadLine();
                Console.WriteLine("Enter the average player number: ");
                int average = int.Parse(Console.ReadLine());
                rest.Post(new Game() { GameName = name, Genre = genre, AverageForever = average }, "game");
            }
            else if (entity == "Person")
            {
                Console.WriteLine("Enter a Person name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the person's age: ");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the person's salary: ");
                int salary = int.Parse(Console.ReadLine());
                rest.Post(new Person() { PersonName = name, Age = age, Salary =salary }, "peron");
            }
        }
        static void List(string entity)
        {
            if (entity == "Company")
            {
                List<Company> companies = rest.Get<Company>("company");
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in companies)
                {
                    Console.WriteLine(item.CompanyID + "\t" + item.CompanyName);
                }
            }
            else if (entity == "Game")
            {
                List<Game> games = rest.Get<Game>("game");
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in games)
                {
                    Console.WriteLine(item.GameID + "\t" + item.GameName);
                }
            }
            else if (entity == "Person")
            {
                List<Person> people = rest.Get<Person>("person");
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in people)
                {
                    Console.WriteLine(item.PersonID + "\t" + item.PersonName);
                }
            }
            Console.ReadLine();

        }
        static void Update(string entity)
        {
            if (entity == "Company")
            {
                Console.Write("Enter a Company's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Company one = rest.Get<Company>(id, "company");
                Console.Write($"New name [old: {one.CompanyName}]: ");
                string name = Console.ReadLine();
                one.CompanyName = name;
                rest.Put(one, "company");
            }
            else if (entity == "Game")
            {
                Console.Write("Enter Game's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Game one = rest.Get<Game>(id, "game");
                Console.Write($"New name [old: {one.GameName}]: ");
                string name = Console.ReadLine();
                one.GameName = name;
                rest.Put(one, "game");
            }
            else if (entity == "Person")
            {
                Console.Write("Enter Person's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Person one = rest.Get<Person>(id, "person");
                Console.Write($"New name [old: {one.PersonName}]: ");
                string name = Console.ReadLine();
                one.PersonName = name;
                rest.Put(one, "person");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Company")
            {
                Console.Write("Enter Company's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "company");
            }
            else if (entity == "Game")
            {
                Console.Write("Enter Game's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "game");
            }
            else if (entity == "Person")
            {
                Console.Write("Enter Person's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Person");
            }
        }
        #endregion

        #region Non-CRUD
        static void Top3CompanyWithMostGames()
        {
            var companies = rest.Get<KeyValuePair<string, int>>("stat/Top3CompanyWithMostGames");

            Console.WriteLine("GameCount" + "\t" + "Name");

            foreach (var item in companies)
            {
                Console.WriteLine(item.Value + "\t" + item.Key);
            }

            Console.ReadLine();
        }

        static void CompaniesWithFpsGames()
        {
            var companies = rest.Get<KeyValuePair<string, int>>("stat/CompaniesWithFpsGames");

            Console.WriteLine("ID" + "\t" + "Name");

            foreach (var item in companies)
            {
                Console.WriteLine(item.Value + "\t" + item.Key);
            }
            Console.ReadLine();
        }

        static void CompanyNameLongerThan20()
        {
            var companies = rest.Get<KeyValuePair<string, int>>("stat/CompanyNameLongerThan20");

            Console.WriteLine("Length" + "\t" + "Name");

            foreach (var item in companies)
            {
                Console.WriteLine(item.Value + "\t" + item.Key);
            }
            Console.ReadLine();

        }

        static void ExecutiveSalaryAbove1000Employee()
        {
            var people = rest.Get<KeyValuePair<string, int>>("stat/ExecutiveSalaryAbove1000Employee");

            Console.WriteLine("Name" + "\t\t" + "Salary");

            foreach (var item in people)
            {
                Console.WriteLine(item.Key + "\t\t" + item.Value+ " USD");
            }
            Console.ReadLine();

        }

        static void TOP10MostPlayedGamesExecutiveAge() 
        {
            var people = rest.Get<KeyValuePair<string, int>>("stat/TOP10MostPlayedGamesExecutiveAge");

            Console.WriteLine("Name" + "\t\t" + "Age");

            foreach (var item in people)
            {
                Console.WriteLine(item.Key + "\t\t" + item.Value);
            }
            Console.ReadLine();
        }

        #endregion

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:38231/", "swagger");
            

            var personSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Person"))
                .Add("Create", () => Create("Person"))
                .Add("Delete", () => Delete("Person"))
                .Add("Update", () => Update("Person"))
                .Add("Exit", ConsoleMenu.Close);

            var gameSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Game"))
                .Add("Create", () => Create("Game"))
                .Add("Delete", () => Delete("Game"))
                .Add("Update", () => Update("Game"))
                .Add("Exit", ConsoleMenu.Close);

            var companySubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Company"))
                .Add("Create", () => Create("Company"))
                .Add("Delete", () => Delete("Company"))
                .Add("Update", () => Update("Company"))
                .Add("Exit", ConsoleMenu.Close);

            var statSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Top3CompanyWithMostGames", () => Top3CompanyWithMostGames())
                .Add("CompaniesWithFpsGames", () => CompaniesWithFpsGames())
                .Add("CompanyNameLongerThan20", () => CompanyNameLongerThan20())
                .Add("ExecutiveSalaryAbove1000Employee", () => ExecutiveSalaryAbove1000Employee())
                .Add("TOP10MostPlayedGamesExecutiveAge", () => TOP10MostPlayedGamesExecutiveAge())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("People", () => personSubMenu.Show())
                .Add("Games", () => gameSubMenu.Show())
                .Add("Companies", () => companySubMenu.Show())
                .Add("Stats", () => statSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    }
}
