using H571H2_HFT_2021222.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace H571H2_HFT_2021222.WpfClient.ViewModels
{
    public class PersonViewModel:ObservableRecipient
    {
        public RestCollection<Person> People { get; set; }
        private Person selectedPerson;

        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                if (value != null)
                {
                    selectedPerson = new Person()
                    {
                        PersonName = value.PersonName,
                        PersonID = value.PersonID,
                        Age = value.Age,
                        Salary = value.Salary,
                        companyID = value.companyID
                    };
                    OnPropertyChanged();
                    (CreatePersonCommand as RelayCommand).NotifyCanExecuteChanged();
                    (DeletePersonCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdatePersonCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand ExecutiveSalaryAbove1000EmployeeCommand { get; set; }
        public ICommand CreatePersonCommand { get; set; }
        public ICommand DeletePersonCommand { get; set; }
        public ICommand UpdatePersonCommand { get; set; }

        public ICommand ShowPersonTable { get; set; }

        private Visibility personVisibility;

        public Visibility PersonVisibility
        {
            get { return personVisibility; }
            set { SetProperty(ref personVisibility, value); }
        }


        private Visibility createPersonVisibility;

        public Visibility CreatePersonVisibility
        {
            get { return createPersonVisibility; }
            set { SetProperty(ref createPersonVisibility, value); }
        }

        private Visibility updatePersonVisibility;

        public Visibility UpdatePersonVisibility
        {
            get { return updatePersonVisibility; }
            set { SetProperty(ref updatePersonVisibility, value); }
        }


        public PersonViewModel()
        {
            CreatePersonCommand = new RelayCommand(() =>
            {
                People.Add(new Person()
                {
                    PersonName = SelectedPerson.PersonName,
                    Age = SelectedPerson.Age,
                    Salary = SelectedPerson.Salary,
                    companyID = SelectedPerson.companyID

                });

            });

            UpdatePersonCommand = new RelayCommand(() =>
            {
                People.Update(SelectedPerson);
            });

            DeletePersonCommand = new RelayCommand(() =>
            {
                People.Delete(SelectedPerson.PersonID);
            },
            () =>
            {
                return SelectedPerson != null;
            });

            SelectedPerson = new Person();
        }
    }
}
