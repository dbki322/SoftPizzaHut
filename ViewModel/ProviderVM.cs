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
    internal class ProviderVM : DataManageVM
    {
        public string ProviderName { get; set; }
        public string ProviderKpp { get; set; }
        public string ProviderInn { get; set; }
        public string ProviderOgrn { get; set; }
        public string ProviderAdress { get; set; }
        public string ProviderRegistration { get; set; }

        private RelayCommand addNewProvider;

        public RelayCommand AddNewProvider
        {
            get
            {
                return addNewProvider ?? new RelayCommand(obj =>
                {
                    string resultStr = "";
                    int purchaseCount;

                    if (ProviderName == null) MessageBox.Show("Введите название поставщика.");
                    else
                    {
                        resultStr = DataWorker.CreateProvider(ProviderName, ProviderInn, ProviderKpp, ProviderOgrn, ProviderAdress, ProviderRegistration);
                        UpdateAllProviders();
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
