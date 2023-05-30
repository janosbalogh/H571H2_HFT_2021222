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
    public class CompanyViewModel:ObservableRecipient
    {
        public RestCollection<Company> Companies { get; set; }
		private Company selectedCompany;

		public Company SelectedCompany
		{
            get { return selectedCompany; }
            set
            {
                if (value != null)
                {
                    selectedCompany = new Company()
                    {
                        Name = value.Name,
                        CompanyID = value.CompanyID,
                        Country = value.Country,
                        executiveID = value.executiveID,
                        EmployeeCount = value.EmployeeCount
                    };
                    OnPropertyChanged();
                    (CreateCompanyCommand as RelayCommand).NotifyCanExecuteChanged();
                    (DeleteCompanyCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateCompanyCommand as RelayCommand).NotifyCanExecuteChanged();                    
                }                
            }
        }

        public ICommand CreateCompanyCommand { get; set; }
        public ICommand DeleteCompanyCommand { get; set; }
        public ICommand UpdateCompanyCommand { get; set; }
        
        public ICommand ShowCompanyTable { get; set; }

        private Visibility companyVisibility;

        public Visibility CompanyVisibility
        {
            get { return companyVisibility; }
            set { SetProperty(ref companyVisibility, value); }
        }

        private Visibility createCompanyVisibility;

        public Visibility CreateCompanyVisibility
        {
            get { return createCompanyVisibility; }
            set { SetProperty(ref createCompanyVisibility, value); }
        }

        private Visibility updateCompanyVisibility;

        public Visibility UpdateCompanyVisibility
        {
            get { return updateCompanyVisibility; }
            set { SetProperty(ref updateCompanyVisibility, value); }
        }

        //private int lastActorId;

        //public int LastActorId
        //{
        //    get { return lastActorId; }
        //    set { SetProperty(ref lastActorId, value); }
        //}

        public CompanyViewModel()
        {
            //CreateCompanyCommand = new RelayCommand(
            //    () => Companies.Add(new Company()
            //    {
            //        Name = SelectedCompany.Name,
            //        executiveID = SelectedCompany.executiveID
            //        //TODO: Add the rest of the properties
            //    }));

            //DeleteCompanyCommand = new RelayCommand(() =>
            //{
            //    Companies.Delete(SelectedCompany.CompanyID);
            //    //TODO ????
            //},
            //() =>
            //{
            //    return SelectedCompany != null;
            //});


            //UpdateCompanyCommand = new RelayCommand(
            //() => {

            //},
            //() => SelectedCompany.CompanyID!= 0);            

            //SelectedCompany = new Company();


            CreateCompanyCommand = new RelayCommand(() =>
            {
                Companies.Add(new Company()
                {
                    Name = SelectedCompany.Name,

                });

            });

            UpdateCompanyCommand = new RelayCommand(() =>
            {               
               Companies.Update(SelectedCompany);
            });

            DeleteCompanyCommand = new RelayCommand(() =>
            {
                Companies.Delete(SelectedCompany.CompanyID);
            },
            () =>
            {
                return SelectedCompany != null;
            });

            SelectedCompany = new Company();

        }

    }
}
