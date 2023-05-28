using H571H2_HFT_2021222.Models;
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
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
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
                        CompanyID = value.CompanyID
                    };
                    OnPropertyChanged();
                    (DeleteCompanyCommand as RelayCommand).NotifyCanExecuteChanged();
                    
                }
                
            }
        }


        public ICommand CreateCompanyCommand { get; set; }
        public ICommand DeleteCompanyCommand { get; set; }
        public ICommand UpdateCompanyCommand { get; set; }
        
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
            if (!IsInDesignMode)
            {
                Companies = new RestCollection<Company>("http://localhost:38231/", "company", "hub");

                CreateCompanyCommand = new RelayCommand(() =>
                {
                    Companies.Add(new Company()
                    {
                        Name = SelectedCompany.Name,
                        
                    });

                });

                UpdateCompanyCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Companies.Update(SelectedCompany);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

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
}
