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
    internal class ProductVM: DataManageVM
    {
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string Unit { get; set; }
        public bool IsChecked1 { get; set; }
        public bool IsChecked2 { get; set; }
        public bool IsChecked3 { get; set; }
        public bool IsChecked4 { get; set; }
        public bool IsChecked5 { get; set; }
        public bool IsChecked6 { get; set; }
        public bool IsChecked7 { get; set; }
        public bool IsChecked8 { get; set; }
        public bool IsChecked9 { get; set; }
        public bool IsChecked10 { get; set; }
        public bool IsChecked11 { get; set; }
        public bool IsChecked12 { get; set; }

        public bool IsChecked13 { get; set; }

        public Provider SelectedProductProvider { get; set; }

        private RelayCommand addNewProduct;

        public RelayCommand AddNewProduct
        {
            get
            {
                return addNewProduct ?? new RelayCommand(obj =>
                {
                    string resultStr = "";
                    int price;
                    Int32.TryParse(Price, out price);

                    if (ProductName == null) MessageBox.Show("Введите название продукта.");
                    else if(SelectedProductProvider == null || SelectedProductProvider.GetType() != typeof(Provider)) MessageBox.Show("Выберите поставщика продукта.");
                    else if (price < 1) MessageBox.Show("Введите цену.");
                    else if (Unit == null) MessageBox.Show("Введите еденицу измерения продукта.");
                    else
                    {
                        Product newProduct = DataWorker.CreateProduct(ProductName, SelectedProductProvider, price, Unit);
                        if(IsChecked1==true) DataWorker.AddCategory(1,newProduct);
                        if (IsChecked2 == true) DataWorker.AddCategory(2, newProduct);
                        if (IsChecked3 == true) DataWorker.AddCategory(3, newProduct);
                        if (IsChecked4 == true) DataWorker.AddCategory(4, newProduct);
                        if (IsChecked5 == true) DataWorker.AddCategory(5, newProduct);
                        if (IsChecked6 == true) DataWorker.AddCategory(6, newProduct);
                        if (IsChecked7 == true) DataWorker.AddCategory(7, newProduct);
                        if (IsChecked8 == true) DataWorker.AddCategory(8, newProduct);
                        if (IsChecked9 == true) DataWorker.AddCategory(9, newProduct);
                        if (IsChecked10 == true) DataWorker.AddCategory(10, newProduct);
                        if (IsChecked11 == true) DataWorker.AddCategory(11, newProduct);
                        if (IsChecked12 == true) DataWorker.AddCategory(12, newProduct);
                        if (IsChecked13 == true) DataWorker.AddCategory(13, newProduct);
                        UpdateAllProducts();
                        UpdateAllPurchases();
                        resultStr = "Продукт " + ProductName + " был добавлен.";
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
