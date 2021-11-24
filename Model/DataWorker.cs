using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialDesignThemes;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
//using Microsoft.Win32;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Data;

namespace SoftPizzaHut
{
  
    public static class DataWorker
    {
        public static List<Purchase> SearchPurchase(string text)
        {
            List<Purchase> purchase = (from Purchase in GetAllPurchases()
                                       where
             Purchase.PurchaseProduct.NameProduct.Contains(text, StringComparison.InvariantCultureIgnoreCase) ||
             Purchase.PurchaseProduct.ProductProvider.NameProvider.Contains(text, StringComparison.InvariantCultureIgnoreCase) ||
             Purchase.PurchaseProduct.AllCategoriesString.Contains(text, StringComparison.InvariantCultureIgnoreCase)
                                       select Purchase).ToList();
            return purchase;
        }
        public static List<Provider> SearchProvider(string text)
        {
            List<Provider> provider = (from Provider in GetAllProviders()
                                       where
             Provider.NameProvider.Contains(text, StringComparison.InvariantCultureIgnoreCase) 
                                       select Provider).ToList();
            return provider;
        }

        public static List<Product> SearchProduct(string text)
        {
            List<Product> product = (from Product in GetAllProducts()
                                       where
             Product.NameProduct.Contains(text, StringComparison.InvariantCultureIgnoreCase) ||
             Product.ProductProvider.NameProvider.Contains(text, StringComparison.InvariantCultureIgnoreCase) ||
             Product.AllCategoriesString.Contains(text, StringComparison.InvariantCultureIgnoreCase)
                                       select Product).ToList();
            return product;
        }



        //создание отчета
        public static void CreateWord(int id,string report)
        {   //пользователь вводит путь сохранения файла
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Microsoft Word (*.docx;*.docx;)|*.docx;*.docx)";
            string sfdname = saveDialog.FileName;
            if (saveDialog.ShowDialog() == DialogResult.OK && Path.GetFullPath(saveDialog.FileName)!=null)
            {
                if (File.Exists(saveDialog.FileName)) {
                    try { File.Delete(saveDialog.FileName); }
                    catch { MessageBox.Show("Закройте документ в который вы пытаетесь сохранить."); return; }
                    }
                using (WordprocessingDocument wordDocument =
                WordprocessingDocument.Create(saveDialog.FileName, WordprocessingDocumentType.Document))
                { 
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());
                    Paragraph para = body.AppendChild(new Paragraph());
                    Run run = para.AppendChild(new Run());
                    run.AppendChild(new Text("Отчёт по закупкам."));
                    Run run2 = para.AppendChild(new Run());
                    run2.AppendChild(new Text("Дата отчета: " + DateTime.Now+". "));

                    if (id == 1) { 
                    Run run3 = para.AppendChild(new Run());
                    run3.AppendChild(new Text("По продукту: " + report));}
                    if (id == 0)
                    {
                        Run run3 = para.AppendChild(new Run());
                        run3.AppendChild(new Text("По поставщику: " + report));
                    }
                    Table table = new Table();
                    TableProperties tblProp = new TableProperties(
                        new TableBorders(
                            new TopBorder()
                            {
                                Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                                Size = 6
                            },
                            new BottomBorder()
                            {
                                Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                                Size = 6
                            },
                            new LeftBorder()
                            {
                                Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                                Size = 6
                            },
                            new RightBorder()
                            {
                                Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                                Size = 6
                            },
                            new InsideHorizontalBorder()
                            {
                                Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                                Size = 6
                            },
                            new InsideVerticalBorder()
                            {
                                Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                                Size = 6
                            }
                        )
                    );
                    table.AppendChild<TableProperties>(tblProp);
                    TableRow tr = new TableRow();
                    TableCell tc1 = new TableCell();
                    RunProperties run1Properties = new RunProperties();
                    run1Properties.Append(new Bold());
                    RunProperties run2Properties = new RunProperties();
                    run2Properties.Append(new Bold());
                    RunProperties run3Properties = new RunProperties();
                    run3Properties.Append(new Bold());
                    RunProperties run4Properties = new RunProperties();
                    run4Properties.Append(new Bold());
                    RunProperties run5Properties = new RunProperties();
                    run5Properties.Append(new Bold());
                    RunProperties run6Properties = new RunProperties();
                    run6Properties.Append(new Bold());
                    RunProperties run7Properties = new RunProperties();
                    run7Properties.Append(new Bold());
                    RunProperties run8Properties = new RunProperties();
                    run8Properties.Append(new Bold());


                    tc1.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa }));                
                    tc1.Append(new Paragraph(new Run(run1Properties, new Text("ID закупки"))));
                    TableCell tc2 = new TableCell();
                    tc2.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    tc2.Append(new Paragraph(new Run(run2Properties, new Text("Товар"))));
                    TableCell tc3 = new TableCell();
                    tc3.Append(new TableCellProperties(
                       new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    tc3.Append(new Paragraph(new Run(run3Properties, new Text("Поставщик"))));
                    TableCell tc4 = new TableCell();
                    tc4.Append(new TableCellProperties(
                       new TableCellWidth() { Type = TableWidthUnitValues.Dxa }));
                    tc4.Append(new Paragraph(new Run(run4Properties, new Text("Заказано единиц"))));
                    TableCell tc5 = new TableCell();
                    tc5.Append(new TableCellProperties(
                       new TableCellWidth() { Type = TableWidthUnitValues.Dxa }));
                    tc5.Append(new Paragraph(new Run(run5Properties, new Text("Единица измерения"))));
                    TableCell tc6 = new TableCell();
                    tc6.Append(new TableCellProperties(
                       new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    tc6.Append(new Paragraph(new Run(run6Properties, new Text("Дата заказа"))));
                    TableCell tc7 = new TableCell();
                    tc7.Append(new TableCellProperties(
                       new TableCellWidth() { Type = TableWidthUnitValues.Dxa }));
                    tc7.Append(new Paragraph(new Run(run7Properties, new Text("Статус доставки"))));
                    TableCell tc8 = new TableCell();
                    tc8.Append(new TableCellProperties(
                       new TableCellWidth() { Type = TableWidthUnitValues.Dxa }));
                    tc8.Append(new Paragraph(new Run(run8Properties, new Text("Общая сумма заказа"))));
                    tr.Append(tc1, tc2, tc3, tc4, tc5, tc6, tc7,tc8);
                    table.Append(tr);
                    TableRow tr2 = new TableRow();
                    TableCell tc = new TableCell();
                    string status = "";
                    List<Purchase> allPurchases= GetAllPurchases();
                    if (id == 1) allPurchases = (from Purchase in GetAllPurchases() where Purchase.PurchaseProduct.NameProduct == report select Purchase).ToList();
                    if (id == 0) allPurchases = (from Purchase in GetAllPurchases() where Purchase.PurchaseProduct.ProductProvider.NameProvider == report select Purchase).ToList();
                    for (int i = 0; i < allPurchases.Count; i++)
                    {
                        if (allPurchases[i].Status)
                            status = "Доставлен.";
                        else
                            status = "Не доставлен.";
                        table.Append(new TableRow(new TableCell(new Paragraph(new Run(new Text(allPurchases[i].IdPurchase.ToString())))),
                                    new TableCell(new Paragraph(new Run(new Text(allPurchases[i].PurchaseProduct.NameProduct.ToString())))),
                                    new TableCell(new Paragraph(new Run(new Text(allPurchases[i].PurchaseProduct.ProductProvider.NameProvider.ToString())))),
                                    new TableCell(new Paragraph(new Run(new Text(allPurchases[i].Amount.ToString())))),
                                    new TableCell(new Paragraph(new Run(new Text(allPurchases[i].PurchaseProduct.Unit.ToString())))),
                                    new TableCell(new Paragraph(new Run(new Text(allPurchases[i].Date.ToString("dd/MM/yyyy"))))),
                                    new TableCell(new Paragraph(new Run(new Text(status)))),
                                    new TableCell(new Paragraph(new Run(new Text(allPurchases[i].PurchaseSum.ToString()))))
                                    ));
                    } 
                wordDocument.MainDocumentPart.Document.Body.Append(table);
            }
                //Запускаем созданный файл
                string commandText = saveDialog.FileName;
                var proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = commandText;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
                }
            }
        


        //Получить строку из всех категорий продукта через запятую
        public static string AllCategoriesString(List<Сategory> сategories)
        {
            string joined = string.Join(", ", сategories.Select(t => t.NameCategory));
            return joined;
        }


        //общая сумма закупки
        public static int GetSum(int price, int amount)
        {
            return price * amount;
        }



        //получение списка категорий по id
        public static List<Сategory> GetAllСategoriesById(int id)
        {
            using (PizzaSoftContext db = new PizzaSoftContext())
            {
                List<Сategory> categories = (from category in db.Сategories join pk in db.RelationPcs on category.IdCategory equals pk.IdCategoryPc where id == pk.IdProductPc select category).ToList();
                return categories;
            }
        }

        //получение продукта по id
        public static Product GetProductById(int id)
        {
            using (PizzaSoftContext db = new PizzaSoftContext())
            {
                Product pos = db.Products.FirstOrDefault(p => p.IdProduct == id);
                return pos;
            }
        }
        //получение поставщика по id
        public static Provider GetProviderById(int id)
        {
            using (PizzaSoftContext db = new PizzaSoftContext())
            {
                Provider pos = db.Providers.FirstOrDefault(p => p.IdProvider == id);
                return pos;
            }
        }

        
        //Создать поставщика
        public static string CreateProvider(string name, string inn, string kpp, string ogrn, string adress, string registration)
        {
            string result = "Поставщик с таким именем уже существует";
            using (PizzaSoftContext db = new PizzaSoftContext())
            {
                //проверяем существует ли поставщик с таким же именем, если не существует возвращаем ошибку
                bool checkIsExist = db.Providers.Any(el => el.NameProvider == name);
                if (!checkIsExist)
                {
                    Provider newProvider = new Provider
                    {
                        NameProvider = name,
                        Inn = inn,
                        Kpp = kpp,
                        Ogrn = ogrn,
                        Address = adress,
                        Registration = registration,
                    };
                    db.Providers.Add(newProvider);
                    db.SaveChanges();
                    result = "Добавлен новый поставщик: "+ name+".";
                }
                return result;
            }
        }

        //создать продукт
        public static Product CreateProduct(string name, Provider provider, int price, string unit)
        {
            using (PizzaSoftContext db = new PizzaSoftContext())
            {
                Product newProduct = new Product
                {
                    NameProduct = name,
                    IdProviderProduct = provider.IdProvider,
                    Price = price,
                    Unit = unit,
                };
                db.Products.Add(newProduct);
                db.SaveChanges();
                return newProduct;
            }
        }
        //создать закупку
        public static string CreatePurchase(Product product, int amount, DateTime date, bool status)
        {
            using (PizzaSoftContext db = new PizzaSoftContext())
            {
                Purchase newPurchase = new Purchase
                {
                    IdProductPurchases = product.IdProduct,
                    Amount = amount,
                    Date = date,
                    Status = status
                };
                db.Purchases.Add(newPurchase);
                db.SaveChanges();
                string result = "Закупка товара " + product.NameProduct + " в количестве " + amount + " " + product.Unit + " была добавлена. Общая цена закупки "+ product.Price* amount+" руб.";
                return result;
            }
        }
        //Удалить продукт
        public static string DeleteProduct(Product product)
        {
            string result = "Ошибка удаления";
            using (PizzaSoftContext db = new PizzaSoftContext())
            {
                db.Products.Remove(product); 
                db.SaveChanges();
                result = "Продукт " + product.NameProduct + " удалён";
            }
            return result;
        }
        //Удалить поставщика
        public static string DeleteProvider(Provider provider)
        {
            string result = "Ошибка удаления";
            using (PizzaSoftContext db = new PizzaSoftContext())
            {
                db.Providers.Remove(provider);
                db.SaveChanges();
                result = "Поставщик " + provider.NameProvider + " удалён";
            }
            return result;
        }
        //удалить закупку
        public static string DeletePurchase(Purchase purchase)
        {
            string result = "Ошибка удаления";
            using (PizzaSoftContext db = new PizzaSoftContext())
            {
                db.Purchases.Remove(purchase);
                db.SaveChanges();
                result = "Закупка удалёна";
            }
            return result;
        }
        public static string EditProvider(Provider oldProvider, string newName, string inn, string kpp, string ogrn, string adress, string registration)
        {
            string result = "Такого сотрудника не существует";
            using (PizzaSoftContext db = new PizzaSoftContext())
            {
                Provider provider = db.Providers.FirstOrDefault(p => p.IdProvider == oldProvider.IdProvider);
                if (provider != null)
                {
                    provider.NameProvider = newName;
                    provider.Inn = inn;
                    provider.Kpp = kpp;
                    provider.Ogrn = ogrn;
                    provider.Address = adress;
                    provider.Registration = registration;
                    db.SaveChanges();
                    result = "Поставщик " + oldProvider.NameProvider + " был изменен.";
                }
            }
            return result;
        }

        //редактировать продукт
        public static string EditProduct(Product product, string newName, Provider newProvider, int newPrice, string newUnit)
        {
            string result = "Ошибка редактирования";
            using (PizzaSoftContext db = new PizzaSoftContext())
            {
                Product newProduct = db.Products.FirstOrDefault(d => d.IdProduct == product.IdProduct);
                newProduct.NameProduct = newName;
                newProduct.IdProviderProduct = newProvider.IdProvider;
                newProduct.Price = newPrice;
                newProduct.Unit = newUnit;
                db.SaveChanges();
                result = "Информация о продукте "+product.NameProduct+ " изменена.";
            }
            return result;
        }
        //получить все продукты у поставщика
        public static List<Product> GetAllProductsByProvider(int id)
        {
            using (PizzaSoftContext db = new PizzaSoftContext())
            {   
                List<Product> products = (from product in GetAllProducts() where product.IdProviderProduct == id select product).ToList();
                return products;
            }
        }
        //получить все продукты
        public static List<Product> GetAllProducts()
        {
            using (PizzaSoftContext db = new PizzaSoftContext())
            {
                var result = db.Products.ToList();
                return result;
            }
        }
        //получить всех поставщиков
        public static List<Provider> GetAllProviders()
        {
            using (PizzaSoftContext db = new PizzaSoftContext())
            {
                var result = db.Providers.ToList();
                return result;
            }
        }
        //получить все закупки
        public static List<Purchase> GetAllPurchases()
        {
            using (PizzaSoftContext db = new PizzaSoftContext())
            {
                var result = db.Purchases.ToList();
                return result;
            }
        }

        public static string EditStatusPurchase(int id, bool status)
        { string result = "Сделано";
            using (PizzaSoftContext db = new PizzaSoftContext())
            {
                //check user is exist
                Purchase purchase = db.Purchases.FirstOrDefault(p => p.IdPurchase == id);
                purchase.Status= !status;
                db.SaveChanges();
            }
            return result;
        }
        public static void ClearCategory(int id)
        {
            using (PizzaSoftContext db = new PizzaSoftContext())
            {
                db.RelationPcs.RemoveRange(db.RelationPcs.Where(x => x.IdProductPc == id));
                db.SaveChanges();
            }

        }
        public static void AddCategory(int id,Product product)
        {
            using (PizzaSoftContext db = new PizzaSoftContext())
            {
                RelationPc newRelationPc = new RelationPc
                { 
                    IdProductPc = product.IdProduct,
                    IdCategoryPc = id};
                db.RelationPcs.Add(newRelationPc);
                db.SaveChanges();
            }

        }
        public static bool IsCategory(int id, Product product)
        {
            bool checkIsExist;
            using (PizzaSoftContext db = new PizzaSoftContext())
            {
                checkIsExist = db.RelationPcs.Any(el => el.IdCategoryPc == id && el.IdProductPc== product.IdProduct);
            }
            return checkIsExist;

        }
        public static bool ToggleBaseColour(bool isDark)
        {
            ITheme theme = MainWindow._paletteHelper.GetTheme();
            IBaseTheme baseTheme;
            if (isDark == false) { baseTheme = isDark ? new MaterialDesignLightTheme() : (IBaseTheme)new MaterialDesignLightTheme(); }
            else {  baseTheme = isDark ? new MaterialDesignDarkTheme() : (IBaseTheme)new MaterialDesignDarkTheme(); }
            theme.SetBaseTheme(baseTheme);
            MainWindow._paletteHelper.SetTheme(theme);
            return !isDark;
        }
    }
    
}
