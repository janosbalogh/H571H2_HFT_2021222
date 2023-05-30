using H571H2_HFT_2021222.Models;
using H571H2_HFT_2021222.WpfClient.ViewModels;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace H571H2_HFT_2021222.WpfClient
{
    public class MainWindowViewModel:ObservableRecipient
    {

        public CompanyViewModel companyView { get; set; }
        public GameViewModel gameView { get; set; }
        public PersonViewModel personView { get; set; }

        static RestService restService;
        
        void Visibilityhiding()
        {
            companyView.CreateCompanyVisibility = Visibility.Hidden;
            companyView.UpdateCompanyVisibility = Visibility.Hidden;
            
            gameView.CreateGameVisibility = Visibility.Hidden;
            gameView.UpdateGameVisibility = Visibility.Hidden;

            personView.CreatePersonVisibility = Visibility.Hidden;
            personView.UpdatePersonVisibility = Visibility.Hidden;

            companyView.CompanyVisibility = Visibility.Hidden;
            gameView.GameVisibility = Visibility.Hidden;
            personView.PersonVisibility = Visibility.Hidden;

        }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
        {
            companyView = new CompanyViewModel();
            gameView = new GameViewModel();
            personView = new PersonViewModel();

            Visibilityhiding();

            if (!IsInDesignMode)
            {
                companyView.Companies = new RestCollection<Company>("http://localhost:38231/", "company", "hub");
                gameView.Games = new RestCollection<Game>("http://localhost:38231/", "game", "hub");
                personView.People = new RestCollection<Person>("http://localhost:38231/", "person", "hub");

                restService = new RestService("http://localhost:38231/", "game");


                companyView.ShowCompanyTable = new RelayCommand(() =>
                {
                    Visibilityhiding();
                    companyView.CompanyVisibility = Visibility.Visible;
                });

                gameView.ShowGameTable = new RelayCommand(() =>
                {
                    Visibilityhiding();
                    gameView.GameVisibility = Visibility.Visible;
                });

                personView.ShowPersonTable = new RelayCommand(() =>
                {
                    Visibilityhiding();
                    personView.PersonVisibility = Visibility.Visible;
                });

                gameView.CompaniesWithFpsGamesCommand = new RelayCommand(() =>
                {
                    IEnumerable<KeyValuePair<string, int>> q = restService.Get<KeyValuePair<string, int>>("Stat/CompaniesWithFpsGames");
                    string l1 = null;
                    foreach (var item in q)
                    {
                        l1 += item.Key.ToString() + "\n";
                    }
                    MessageBox.Show(l1.ToString(), "CompaniesWithFpsGame");
                });

                gameView.CompanyNameLongerThan20Command = new RelayCommand(() =>
                {
                    IEnumerable<KeyValuePair<string, int>> q = restService.Get<KeyValuePair<string, int>>("Stat/CompanyNameLongerThan20");
                    string l1 = null;
                    foreach (var item in q)
                    {                        
                        l1 += item.Key.ToString() + "\n";
                    }
                    MessageBox.Show(l1.ToString(), "CompanyNameLongerThan20");
                });

                gameView.Top3CompanyWithMostGamesCommand = new RelayCommand(() =>
                {
                    IEnumerable<KeyValuePair<string, int>> q = restService.Get<KeyValuePair<string, int>>("Stat/Top3CompanyWithMostGames");
                    string l1 = null;
                    foreach (var item in q)
                    {                        
                        l1 += item.Key.ToString() + ":  " + item.Value.ToString() + "\n";
                    }
                    MessageBox.Show(l1.ToString(), "Top3CompanyWithMostGames");
                });

                gameView.TOP10MostPlayedGamesExecutiveAgeCommand = new RelayCommand(() =>
                {
                    IEnumerable<KeyValuePair<string, int>> q = restService.Get<KeyValuePair<string, int>>("Stat/TOP10MostPlayedGamesExecutiveAge");
                    string l1 = null;
                    foreach (var item in q)
                    {                        
                        l1 += item.Key.ToString() +":  " + item.Value.ToString() + "\n";
                    }
                    MessageBox.Show(l1.ToString(), "TOP10MostPlayedGamesExecutiveAge");
                });

                personView.ExecutiveSalaryAbove1000EmployeeCommand = new RelayCommand(() =>
                {
                    IEnumerable<KeyValuePair<string, int>> q = restService.Get<KeyValuePair<string, int>>("Stat/ExecutiveSalaryAbove1000Employee");
                    string l1 = null;
                    foreach (var item in q)
                    {                        
                        l1 += item.Key.ToString() + ":  " + item.Value.ToString() + "\n";
                    }
                    MessageBox.Show(l1.ToString(), "ExecutiveSalaryAbove1000Employee");
                });
                
            }

        }

    }
}
