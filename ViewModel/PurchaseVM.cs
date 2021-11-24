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
using System.Windows.Data;

namespace SoftPizzaHut.ViewModel 
{

    internal class PurchaseVM :DataManageVM
    {
        private Product selectedProduct;
        public Product SelectedProduct
        {
            get
            {
                return selectedProduct;
            }
            set
            {
                selectedProduct=value;
            }
        }   
        private Provider selectedProductProvider;
        public string PurchaseCount { get; set; }
        public DateTime PurchaseDate
        {
            get
            {
                return purchaseDate;
            }
            set
            {
                purchaseDate = value;
            }
        }
        private DateTime purchaseDate = DateTime.Now;
        private int purchaseCount;




        public Provider SelectedProductProvider
        {
            get
            {
                return selectedProductProvider;
            }
            set
            {
                AllProductsByProvider = DataWorker.GetAllProductsByProvider(value.IdProvider); NotifyPropertyChanged("SelectedProductProvider");
            }
        }
        private List<Product> allProductsByProvider;
        //    = DataWorker.GetAllProducts();
        public List<Product> AllProductsByProvider
        {
            get
            {
                return allProductsByProvider;
            }
            set
            {
                allProductsByProvider = value;
                OnPropertyChanged("AllProductsByProvider");
            }
        }
        private RelayCommand addNewPurchase;

        public RelayCommand AddNewPurchase
        {
            get
            {
                return addNewPurchase ?? new RelayCommand(obj =>
                {
                    string resultStr = "";
                    int purchaseCount;
                    Int32.TryParse(PurchaseCount,out purchaseCount);

                    /* if (UserName == null || UserName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "NameBlock");
                    }
                    if (UserSurName == null || UserSurName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "SurNameBlock");
                    }
                    //if (UserPhone == null || UserPhone.Replace(" ", "").Length == 0)
                    //{
                    //    SetRedBlockControll(wnd, "SurNameBlock");
                    //}
                    if (UserPosition == null)
                    {
                        MessageBox.Show("Укажите позицию");
                    }
                    else
                    {*/
                    if (SelectedProduct == null || SelectedProduct.GetType() != typeof(Product)) MessageBox.Show("Такого продукта не существует.");
                    else if (purchaseCount<1) MessageBox.Show("Введите количество.");
                    else if (PurchaseDate == null || PurchaseDate.GetType() != typeof(DateTime)) MessageBox.Show("Введите дату.");
                    else
                {
                    resultStr = DataWorker.CreatePurchase(SelectedProduct, purchaseCount, PurchaseDate, false);
                    UpdateAllPurchases();
                    OnShowMessage(resultStr);
                    //   DialogHost.CloseDialogCommand.Execute(null, null);
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
        // }
        public DialogSession DialogSession { get; set; }
    }
       



}

