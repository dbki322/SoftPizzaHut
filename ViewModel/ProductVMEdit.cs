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
    internal class ProductVMEdit : DataManageVM
    {
        private string productName = SelectedProduct.NameProduct;
        public string ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                productName = value;
            }
        }
        private string price = SelectedProduct.Price.ToString();
        public string Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
        private string unit = SelectedProduct.Unit;
        public string Unit
        {
            get
            {
                return unit;
            }
            set
            {
                unit = value;
            }
        }
        private bool isChecked1 = DataWorker.IsCategory(1, SelectedProduct);
        public bool IsChecked1
        {
            get
            {
                return isChecked1;
            }
            set
            {
                isChecked1 = value;
            }
        }
        private bool isChecked2 = DataWorker.IsCategory(2, SelectedProduct);
        public bool IsChecked2
        {
            get
            {
                return isChecked2;
            }
            set
            {
                isChecked2 = value;
            }
        }
        private bool isChecked3 = DataWorker.IsCategory(3, SelectedProduct);
        public bool IsChecked3
        {
            get
            {
                return isChecked3;
            }
            set
            {
                isChecked3 = value;
            }
        }
        private bool isChecked4 = DataWorker.IsCategory(4, SelectedProduct);
        public bool IsChecked4
        {
            get
            {
                return isChecked4;
            }
            set
            {
                isChecked4 = value;
            }
        }
        private bool isChecked5 = DataWorker.IsCategory(5, SelectedProduct);
        public bool IsChecked5
        {
            get
            {
                return isChecked5;
            }
            set
            {
                isChecked5 = value;
            }
        }
        private bool isChecked6 = DataWorker.IsCategory(6, SelectedProduct);
        public bool IsChecked6
        {
            get
            {
                return isChecked6;
            }
            set
            {
                isChecked6 = value;
            }
        }
        private bool isChecked7 = DataWorker.IsCategory(7, SelectedProduct);
        public bool IsChecked7
        {
            get
            {
                return isChecked7;
            }
            set
            {
                isChecked7 = value;
            }
        }
        private bool isChecked8 = DataWorker.IsCategory(8, SelectedProduct);
        public bool IsChecked8
        {
            get
            {
                return isChecked8;
            }
            set
            {
                isChecked8 = value;
            }
        }
        private bool isChecked9 = DataWorker.IsCategory(9, SelectedProduct);
        public bool IsChecked9
        {
            get
            {
                return isChecked9;
            }
            set
            {
                isChecked9 = value;
            }
        }
        private bool isChecked10 = DataWorker.IsCategory(10, SelectedProduct);
        public bool IsChecked10
        {
            get
            {
                return isChecked10;
            }
            set
            {
                isChecked10 = value;
            }
        }
        private bool isChecked11 = DataWorker.IsCategory(11, SelectedProduct);
        public bool IsChecked11
        {
            get
            {
                return isChecked11;
            }
            set
            {
                isChecked11 = value;
            }
        }
        private bool isChecked12 = DataWorker.IsCategory(12, SelectedProduct);
        public bool IsChecked12
        {
            get
            {
                return isChecked12;
            }
            set
            {
                isChecked12= value;
            }
        }
        private bool isChecked13 = DataWorker.IsCategory(13, SelectedProduct);
        public bool IsChecked13
        {
            get
            {
                return isChecked13;
            }
            set
            {
                isChecked13 = value;
            }
        }

       
        public Provider SelectedProductProvider { get; set; }


        private RelayCommand editNewProduct;

        public RelayCommand EditNewProduct
        {
            get
            {
                return editNewProduct ?? new RelayCommand(obj =>
                {
                    string resultStr = "";
                    int price;
                    Int32.TryParse(Price, out price);

                    if (ProductName == null) MessageBox.Show("Введите название продукта.");
                    else if (SelectedProductProvider == null || SelectedProductProvider.GetType() != typeof(Provider)) MessageBox.Show("Выберите поставщика продукта.");
                    else if (price < 1) MessageBox.Show("Введите цену.");
                    else if (Unit == null) MessageBox.Show("Введите еденицу измерения продукта.");
                    else
                    {
                        string editProduct = DataWorker.EditProduct(SelectedProduct,ProductName, SelectedProductProvider, price, Unit);
                        DataWorker.ClearCategory(SelectedProduct.IdProduct);
                        if (IsChecked1 == true) DataWorker.AddCategory(1, SelectedProduct);
                        if (IsChecked2 == true) DataWorker.AddCategory(2, SelectedProduct);
                        if (IsChecked3 == true) DataWorker.AddCategory(3, SelectedProduct);
                        if (IsChecked4 == true) DataWorker.AddCategory(4, SelectedProduct);
                        if (IsChecked5 == true) DataWorker.AddCategory(5, SelectedProduct);
                        if (IsChecked6 == true) DataWorker.AddCategory(6, SelectedProduct);
                        if (IsChecked7 == true) DataWorker.AddCategory(7, SelectedProduct);
                        if (IsChecked8 == true) DataWorker.AddCategory(8, SelectedProduct);
                        if (IsChecked9 == true) DataWorker.AddCategory(9, SelectedProduct);
                        if (IsChecked10 == true) DataWorker.AddCategory(10, SelectedProduct);
                        if (IsChecked11 == true) DataWorker.AddCategory(11, SelectedProduct);
                        if (IsChecked12 == true) DataWorker.AddCategory(12, SelectedProduct);
                        if (IsChecked13 == true) DataWorker.AddCategory(13, SelectedProduct);
                        UpdateAllProducts();
                        UpdateAllPurchases();
                        OnShowMessage(editProduct);
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
