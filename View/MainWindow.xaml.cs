using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using MaterialDesignThemes;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;

namespace SoftPizzaHut
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        public static DataGrid DataPurchase;
        public static DataGrid DataProvider;
        public static DataGrid DataProduct;

        public static PaletteHelper _paletteHelper = new PaletteHelper();
        public MainWindow()
        {

            InitializeComponent();
            PizzaSoftContext db = new PizzaSoftContext();
            //   db.Purchases.Load();
            //List<Product> dbsad  =  DataWorker.GetAllProductsByProvider(2);
            ////DataGridPurchase.ItemsSource = db.Purchases.Local.ToBindingList();
            DataContext = new DataManageVM();
            DataPurchase = DataGridPurchase;
            DataProvider = DataGridProvider;
            DataProduct = DataGridProduct;

        }


    }

    
}
