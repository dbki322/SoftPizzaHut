using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftPizzaHut;
using System.ComponentModel;
using MaterialDesignThemes.Wpf;
using System.Windows.Input;
using SoftPizzaHut.ViewModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SoftPizzaHut.ViewModel
{
    internal class ProviderVMEdit : DataManageVM
    {
        private string providerName = SelectedProvider.NameProvider;
        public string ProviderName
        {         
            get {
                    return providerName;
                }
            set {
                    providerName = value;
                }
            }
        private string providerKpp = SelectedProvider.Kpp;
        public string ProviderKpp
        {
            get
            {
                return providerKpp;
            }
            set
            {
                providerKpp = value;
            }
        }
        private string providerInn = SelectedProvider.Inn;
        public string ProviderInn
        {
            get
            {
                return providerInn;
            }
            set
            {
                providerInn = value;
            }
        }
        private string providerOgrn = SelectedProvider.Ogrn;
        public string ProviderOgrn
        {
            get
            {
                return providerOgrn;
            }
            set
            {
                providerOgrn = value;
            }
        }
        private string providerAdress = SelectedProvider.Address;
        public string ProviderAdress
        {
            get
            {
                return providerAdress;
            }
            set
            {
                providerAdress = value;
            }
        }
        private string providerRegistration = SelectedProvider.Registration;
        public string ProviderRegistration
        {
            get
            {
                return providerRegistration;
            }
            set
            {
                providerRegistration = value;
            }
        }

        private RelayCommand editProvider;

        public RelayCommand EditProvider
        {
            get
            {
                return editProvider ?? new RelayCommand(obj =>
                {
                    string resultStr = "";
                    if (ProviderName == null) MessageBox.Show("Введите название поставщика.");
                    else
                    {
                        resultStr = DataWorker.EditProvider(SelectedProvider,ProviderName, ProviderInn, ProviderKpp, ProviderOgrn, ProviderAdress, ProviderRegistration);
                        UpdateAllProviders();
                        UpdateAllPurchases();
                        OnShowMessage(resultStr);
                        //   DialogHost.CloseD ialogCommand.Execute(null, null);
                    }



                });


            }
        }
        async void OnShowMessage(string message)
        {
            //  await MaterialDesignThemes.Wpf.DialogHost.Show(person, "MyDialogHost");
            DialogSession?.UpdateContent(new MessageViewModel(message)
            { });
            // var vm = new MessageViewModel(message);
            // await MaterialDesignThemes.Wpf.DialogHost.Show(vm, "DialogShowMessageIdentifier");
        }




        public DialogSession DialogSession { get; set; }
    }

}
