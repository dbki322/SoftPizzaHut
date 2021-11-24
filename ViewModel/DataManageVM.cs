using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MaterialDesignThemes.Wpf;
using System.Windows.Input;
using SoftPizzaHut.ViewModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using SoftPizzaHut.Model;
using System.Windows.Data;

namespace SoftPizzaHut
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }
    }
    
    internal class DataManageVM : INotifyPropertyChanged
    {
        public string Login { get;set;}
        private Visibility loginScreen;
        public Visibility LoginScreen
        {
            get
            {
                return loginScreen;
            }
            set
            {
                loginScreen = value; NotifyPropertyChanged("LoginScreen");
            }
        }
        private ICommand loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                return loginCommand ?? new RelayCommand(obj =>
                {
                    var passwordBox = obj as PasswordBox;
                    if (passwordBox.Password != null && passwordBox.Password == "111" && Login == "111") LoginScreen = Visibility.Hidden;
                    else MessageBox.Show("Введите правильные данные. (Логин 111; Пароль 111)");
                }
                    );
            }

        }
        public Provider ReportProvider { get; set; }
        public Product ReportProduct { get; set; }
        public const string DialogIdentifier = "RootDialogHost";
        public int SelectedTab { get; set; }
        public string SearchText { get; set; }
        private ICommand search;
        public ICommand Search
        {
            get
            {
                return search ?? new RelayCommand(obj =>
                {
                    Binding bind = new Binding("AllPurchases");
                    bind.Mode = BindingMode.TwoWay;
                    MainWindow.DataPurchase.ItemsSource = null;
                    MainWindow.DataPurchase.Items.Clear();
                    MainWindow.DataPurchase.SetBinding(DataGrid.ItemsSourceProperty, bind);
                    MainWindow.DataPurchase.Items.Refresh();

                    bind = new Binding("AllProviders");
                    bind.Mode = BindingMode.TwoWay;

                    MainWindow.DataProvider.ItemsSource = null;
                    MainWindow.DataProvider.Items.Clear();
                    MainWindow.DataProvider.SetBinding(DataGrid.ItemsSourceProperty, bind);
                    MainWindow.DataProvider.Items.Refresh();

                    bind = new Binding("AllProducts");
                    bind.Mode = BindingMode.TwoWay;

                    MainWindow.DataProduct.ItemsSource = null;
                    MainWindow.DataProduct.Items.Clear();
                    MainWindow.DataProduct.SetBinding(DataGrid.ItemsSourceProperty, bind);
                    MainWindow.DataProduct.Items.Refresh();
                    AllPurchases = DataWorker.GetAllPurchases();
                    AllPurchases = DataWorker.GetAllPurchases();
                    AllPurchases = DataWorker.GetAllPurchases();
                    if (SelectedTab == 0)
                        AllPurchases = DataWorker.SearchPurchase(SearchText);
                    else if (SelectedTab == 1) 
                        AllProviders = DataWorker.SearchProvider(SearchText);
                    else if(SelectedTab==2) 
                        AllProducts = DataWorker.SearchProduct(SearchText);
                }
                    );
            }

        }


        private ICommand createDocx;
        public ICommand CreateDocx
        {
            get
            {
                return createDocx ?? new RelayCommand(obj =>
                {
                    
                    if (SelectedReport == 1 && ReportProduct !=null  && ReportProduct.GetType() == typeof(Product)) DataWorker.CreateWord(1,ReportProduct.NameProduct); 
                    if (SelectedReport == 0 && ReportProvider != null && ReportProvider.GetType() == typeof(Provider)) DataWorker.CreateWord(0, ReportProvider.NameProvider);
                   
                }
                    );
            }

        }
        private ICommand downloadTest;
        public ICommand DownloadTest
        {
            get
            {
                return downloadTest ?? new RelayCommand(obj =>
                {
                    TestData.DownloadTest();
                    UpdateAllProviders();
                    UpdateAllProducts();
                    UpdateAllPurchases();

                }
                    );
            }

        }
        private ICommand changeTheme;
        public bool isLight = true;
        public ICommand ChangeTheme
        {
            get
            {
                return changeTheme ?? new RelayCommand(obj =>
                {

                    isLight = DataWorker.ToggleBaseColour(isLight);
                }
                    );
            }

        }
        private Visibility visibilityProvider;
        public Visibility VisibilityProvider
        {
            get
            {
                return visibilityProvider;
            }
            set
            {
                visibilityProvider = value; NotifyPropertyChanged("VisibilityProvider");
            }
        }
        private Visibility visibilityProduct=Visibility.Hidden;
        public Visibility VisibilityProduct {
            get 
            { 
                return visibilityProduct; 
            }
            set 
            { 
                visibilityProduct = value; NotifyPropertyChanged("VisibilityProduct");
            }
        }
        private int selectedReport;
        public int SelectedReport
        {
            get
            {
                return selectedReport;
            }
            set
            {
                selectedReport=value;
                if (value == 0) 
                { 
                    VisibilityProvider = Visibility.Visible; VisibilityProduct = Visibility.Hidden; 
                }
                if (value == 1)
                {
                    VisibilityProduct = Visibility.Visible; VisibilityProvider = Visibility.Hidden;
                }
            NotifyPropertyChanged("SelectReport");
            }
        }
        public static Purchase SelectedPurchase { get; set; }
        public static Provider SelectedProvider { get; set; }
        public static Product SelectedProduct { get; set; }

        private ICommand changePurshaseStatus;

        public ICommand ChangePurshaseStatus
        {
            get
            {
                return changePurshaseStatus ?? new RelayCommand(obj =>
                {
                    if (SelectedPurchase != null)
                        DataWorker.EditStatusPurchase(SelectedPurchase.IdPurchase, SelectedPurchase.Status);
                    UpdateAllPurchases();
                    // ShowMessageToUser(resultStr);
                }
                    );
            }

        }
        private ICommand deleteProduct;
        public ICommand DeleteProduct
        {
            get
            {
                return deleteProduct ?? new RelayCommand(obj =>
                {
                    if (SelectedProduct != null)
                        DataWorker.DeleteProduct(SelectedProduct);
                    UpdateAllProducts();
                    UpdateAllPurchases();
                    // ShowMessageToUser(resultStr);
                }
                    );
            }

        }
        private ICommand deletePurchase;
        public ICommand DeletePurchase
        {
            get
            {
                return deletePurchase ?? new RelayCommand(obj =>
                {
                    if (SelectedPurchase != null)
                        DataWorker.DeletePurchase(SelectedPurchase);
                        UpdateAllPurchases();   
                       // ShowMessageToUser(resultStr);
                }
                    );
            }

        }
        private ICommand deleteProvider;
        public ICommand DeleteProvider
        {
            get
            {
                return deleteProvider ?? new RelayCommand(obj =>
                {
                    if(SelectedProvider != null)
                    DataWorker.DeleteProvider(SelectedProvider);
                    UpdateAllProviders();
                    UpdateAllProducts();
                    UpdateAllPurchases();
                    // ShowMessageToUser(resultStr);
                }
                    );
            }

        }

        private ICommand showAddPurchaseDialog;
        public ICommand ShowAddPurchaseDialog
        {   
            get { 
            return showAddPurchaseDialog ?? new RelayCommand(OnShowAddPurchase);
            }

        }

        private ICommand showAddProviderDialog;
        public ICommand ShowAddProviderDialog
        {
            get
            {
                return showAddProviderDialog ?? new RelayCommand(OnShowAddProvider);
            }

        }
        private ICommand changeProvider;
        public ICommand ChangeProvider
        {
            get
            {   
                return changeProvider ?? new RelayCommand(OnShowEditProvider);

            }

        }
        private ICommand changeProduct;
        public ICommand ChangeProduct
        {
            get
            {
                return changeProduct ?? new RelayCommand(OnShowEditProduct);

            }

        }
        private ICommand showAddProductDialog;
        public ICommand ShowAddProductDialog
        {
            get
            {
                return showAddProductDialog ?? new RelayCommand(OnShowAddProduct);
            }

        }
        private async void OnShowAddProduct(object _)
        {
                var viewModel = new ProductVM();

                await MaterialDesignThemes.Wpf.DialogHost.Show(viewModel, DialogIdentifier, new DialogOpenedEventHandler((sender, args) =>
                {
                    viewModel.DialogSession = args.Session;
                }));
        }
        private async void OnShowEditProduct(object _)
        {
            if (SelectedProduct != null)
            {
                var viewModel = new ProductVMEdit();

                await MaterialDesignThemes.Wpf.DialogHost.Show(viewModel, DialogIdentifier, new DialogOpenedEventHandler((sender, args) =>
                {
                    viewModel.SelectedProductProvider = SelectedProduct.ProductProvider;
                    viewModel.DialogSession = args.Session;
                }));
            }
        }
        private async void OnShowEditProvider(object _)
        {
            if (SelectedProvider != null)
            {
                var viewModel = new ProviderVMEdit();

                await MaterialDesignThemes.Wpf.DialogHost.Show(viewModel, DialogIdentifier, new DialogOpenedEventHandler((sender, args) =>
                {
                    viewModel.DialogSession = args.Session;
                }));
            }
        }
        private async void OnShowAddPurchase(object _)
        {
            var viewModel = new PurchaseVM();
            await MaterialDesignThemes.Wpf.DialogHost.Show(viewModel, DialogIdentifier, new DialogOpenedEventHandler((sender, args) =>
            {
                viewModel.DialogSession = args.Session;
            }));
        }
        private async void OnShowAddProvider(object _)
        {
            var viewModel = new ProviderVM();
            await MaterialDesignThemes.Wpf.DialogHost.Show(viewModel, DialogIdentifier, new DialogOpenedEventHandler((sender, args) =>
            {
                viewModel.DialogSession = args.Session;
            }));
        }

        /*        private List<Product> allProductsByProvider;
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
        */
        public List<Product> allProducts = DataWorker.GetAllProducts();
        public List<Product> AllProducts
        {
            get { return allProducts; NotifyPropertyChanged("AllProducts"); }
            set
            {
                allProducts = value;
                NotifyPropertyChanged("AllProducts");
            }
        }

        //все закупки
        public List<Purchase> allPurchases =DataWorker.GetAllPurchases();
        public List<Purchase> AllPurchases
        { 
            get {  return allPurchases;} 
            set 
            {  
                allPurchases = value;
                NotifyPropertyChanged("AllPurchases");
            }
        }
       // private List<Test> allTest = DataWorker.GetAllTest();
    
        private List<Provider> allProviders = DataWorker.GetAllProviders();
        public List<Provider> AllProviders
        {
            get { return allProviders; }
            set
            {
                allProviders = value;
                NotifyPropertyChanged("AllProviders");
            }
        }
        public static Product Product { get; set; }
        public static Product PurchaseProduct { get; set; }

        public void UpdateAllPurchases()
        {
            
            //    allPurchases = DataWorker.GetAllPurchases();
            AllPurchases = DataWorker.GetAllPurchases();
            MainWindow.DataPurchase.ItemsSource = null;
            MainWindow.DataPurchase.Items.Clear();
            MainWindow.DataPurchase.ItemsSource = AllPurchases;
            MainWindow.DataPurchase.Items.Refresh();


        }
        public void UpdateAllProviders()
        {

            AllProviders = DataWorker.GetAllProviders();
            MainWindow.DataProvider.ItemsSource = null;
            MainWindow.DataProvider.Items.Clear();
            MainWindow.DataProvider.ItemsSource = AllProviders;
            MainWindow.DataProvider.Items.Refresh();
            //   allPurchases = DataWorker.GetAllPurchases();
        }
        public void UpdateAllProducts()
        {

            AllProducts = DataWorker.GetAllProducts();
            MainWindow.DataProduct.ItemsSource = null;
            MainWindow.DataProduct.Items.Clear();
            MainWindow.DataProduct.ItemsSource = AllProducts;
            MainWindow.DataProduct.Items.Refresh();
            // allPurchases = DataWorker.GetAllPurchases();
        }



























        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
