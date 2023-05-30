using H571H2_HFT_2021222.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace H571H2_HFT_2021222.WpfClient.ViewModels
{
    public class GameViewModel:ObservableRecipient
    {
        public RestCollection<Game> Games { get; set; }

        private Game selectedGame;
        
        public Game SelectedGame
        {
            get { return selectedGame; }
            set
            {
                if (value != null)
                {
                    selectedGame = new Game()
                    {
                        Name = value.Name,
                        GameID = value.GameID,
                        Genre = value.Genre,
                        RecentConcurrentPeak = value.RecentConcurrentPeak,
                        companyID = value.companyID
                    };
                    OnPropertyChanged();
                    (CreateGameCommand as RelayCommand).NotifyCanExecuteChanged();
                    (DeleteGameCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateGameCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand Top3CompanyWithMostGamesCommand { get; set; }
        public ICommand CompaniesWithFpsGamesCommand { get; set; }
        public ICommand CompanyNameLongerThan20Command { get; set; }
        public ICommand TOP10MostPlayedGamesExecutiveAgeCommand { get; set; }


        public ICommand CreateGameCommand { get; set; }
        public ICommand DeleteGameCommand { get; set; }
        public ICommand UpdateGameCommand { get; set; }

        public ICommand ShowGameTable { get; set; }

        private Visibility gameVisibility;
        
        public Visibility GameVisibility
        {
            get { return gameVisibility; }
            set { SetProperty(ref gameVisibility, value); }
        }

        private Visibility createGameVisibility;
        public Visibility CreateGameVisibility
        {
            get { return createGameVisibility; }
            set { SetProperty(ref createGameVisibility, value); }
        }

        private Visibility updateGameVisibility;

        public Visibility UpdateGameVisibility
        {
            get { return updateGameVisibility; }
            set { SetProperty(ref updateGameVisibility, value); }
        }

        public GameViewModel()
        {
            CreateGameCommand = new RelayCommand(() =>
            {
                Games.Add(new Game()
                {
                    Name = SelectedGame.Name,

                });

            });

            UpdateGameCommand = new RelayCommand(() =>
            {
                Games.Update(SelectedGame);
            });

            DeleteGameCommand = new RelayCommand(() =>
            {
                Games.Delete(SelectedGame.GameID);
            },
            () =>
            {
                return SelectedGame != null;
            });

            SelectedGame = new Game();
        }
    }
}
