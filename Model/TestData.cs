using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftPizzaHut.Model
{
    internal class TestData
    {

        public static void DownloadTest()
        {
            using (PizzaSoftContext db = new PizzaSoftContext())
            {
                Provider prov1 = new Provider {  NameProvider = "Московский молочный завод", Inn = "3361832549", Kpp = "013345136", Ogrn = "29188752131", Address = "г.Москва, ул.Трубецкая, д.3", Registration = "07.09.2015 - Действует 10 лет." };
                db.Providers.Add(prov1);
                Provider prov2 = new Provider { NameProvider = "ProdArt", Inn = "0185630387", Kpp = "146745338", Ogrn = "61574836010", Address = "г. Красногвардейск, ул. Пограничная", Registration = "11.03.2015 - Действует 7 лет." };
                db.Providers.Add(prov2);
                Provider prov3 = new Provider { NameProvider = "Экомаркет", Inn = "6486539140", Kpp = "857544244", Ogrn = "6013288814270", Address = "г.Москва, ул.3-я Музейная, д.87", Registration = "17.09.2009 - Действует 13 лет." };
                db.Providers.Add(prov3);
                Provider prov4 = new Provider { NameProvider = "Вкусторг", Inn = "4356158750", Kpp = "01408322300", Ogrn = "3125388854632", Address = "г.Москва, ул.Юровская, д.87, кв.36", Registration = "07.03.2017 - Действует 6 лет." };
                db.Providers.Add(prov4);
                Provider prov5 = new Provider { NameProvider = "Азбука вкуса", Inn = "057927147449", Kpp = "7451008990", Ogrn = "3021628567276", Address = "г.Москва, ул.Самотечная, д.54", Registration = "12.12.2012 - Действует 12 лет." };
                db.Providers.Add(prov5);
                db.SaveChanges();
                Product prod1 = new Product { NameProduct="Тесто", IdProviderProduct= 3, Price=50, Unit="Кг" };
                Product prod2 = new Product { NameProduct = "Яйцо", IdProviderProduct = 2, Price = 3, Unit = "шт" };
                Product prod3 = new Product { NameProduct = "Молоко", IdProviderProduct = 1, Price = 30, Unit = "Л" };
                Product prod4 = new Product { NameProduct = "Сыр", IdProviderProduct = 1, Price = 10, Unit = "Кг" };
                Product prod5 = new Product { NameProduct = "Помидоры", IdProviderProduct = 4, Price = 51, Unit = "Кг" };
                Product prod6 = new Product { NameProduct = "Огурцы", IdProviderProduct = 5, Price = 20, Unit = "Кг" };
                Product prod7 = new Product { NameProduct = "Креветки", IdProviderProduct = 2, Price = 120, Unit = "Кг" };
                Product prod8 = new Product { NameProduct = "Говядина", IdProviderProduct = 3, Price = 220, Unit = "Кг" };
                Product prod9 = new Product { NameProduct = "Спрайт", IdProviderProduct = 4, Price = 70, Unit = "Л" };
                Product prod10 = new Product { NameProduct = "Хлеб", IdProviderProduct = 5, Price = 52, Unit = "Кг" };
                Product prod11 = new Product { NameProduct = "Мука", IdProviderProduct = 3, Price = 50, Unit = "Кг" };
                Product prod12 = new Product { NameProduct = "Соль", IdProviderProduct = 3, Price = 20, Unit = "Кг" };
                Product prod13 = new Product { NameProduct = "Малина", IdProviderProduct = 3, Price = 55, Unit = "Кг" };
                Product prod14 = new Product { NameProduct = "Халапеньо", IdProviderProduct = 3, Price = 50, Unit = "Кг" };
                db.Products.Add(prod1); db.Products.Add(prod3); db.Products.Add(prod2); db.Products.Add(prod4); db.Products.Add(prod5); db.Products.Add(prod6);
                db.Products.Add(prod7); db.Products.Add(prod8); db.Products.Add(prod9); db.Products.Add(prod10); db.Products.Add(prod11); db.Products.Add(prod12);
                db.Products.Add(prod13); db.Products.Add(prod14); db.SaveChanges();
                db.RelationPcs.Add(new RelationPc { IdCategoryPc = 5, IdProductPc = 1 });
                db.RelationPcs.Add(new RelationPc { IdCategoryPc =11, IdProductPc = 1 });
                db.RelationPcs.Add(new RelationPc { IdCategoryPc = 13, IdProductPc = 1 });
                db.RelationPcs.Add(new RelationPc { IdCategoryPc = 12, IdProductPc = 2 }); db.RelationPcs.Add(new RelationPc { IdCategoryPc = 5, IdProductPc = 2 });
                db.RelationPcs.Add(new RelationPc { IdCategoryPc = 3, IdProductPc = 3 }); db.RelationPcs.Add(new RelationPc { IdCategoryPc = 1, IdProductPc = 3 }); db.RelationPcs.Add(new RelationPc { IdCategoryPc = 12, IdProductPc = 3 });
                db.RelationPcs.Add(new RelationPc { IdCategoryPc = 3, IdProductPc = 4 }); db.RelationPcs.Add(new RelationPc { IdCategoryPc = 12, IdProductPc = 4 });
                db.RelationPcs.Add(new RelationPc { IdCategoryPc = 7, IdProductPc = 5}); db.RelationPcs.Add(new RelationPc { IdCategoryPc = 12, IdProductPc = 5 });
                db.RelationPcs.Add(new RelationPc { IdCategoryPc = 7, IdProductPc = 6}); db.RelationPcs.Add(new RelationPc { IdCategoryPc = 12, IdProductPc = 6});
                db.RelationPcs.Add(new RelationPc { IdCategoryPc = 4, IdProductPc = 7}); db.RelationPcs.Add(new RelationPc { IdCategoryPc = 2, IdProductPc = 7 });
                db.RelationPcs.Add(new RelationPc { IdCategoryPc = 2, IdProductPc = 8});
                db.RelationPcs.Add(new RelationPc { IdCategoryPc = 1, IdProductPc = 9}); db.RelationPcs.Add(new RelationPc { IdCategoryPc = 7, IdProductPc = prod9.IdProduct });
                db.RelationPcs.Add(new RelationPc { IdCategoryPc = 6, IdProductPc = 10}); db.RelationPcs.Add(new RelationPc { IdCategoryPc = 12, IdProductPc = 10 }); db.RelationPcs.Add(new RelationPc { IdCategoryPc = 11, IdProductPc = 10 });
                db.RelationPcs.Add(new RelationPc { IdCategoryPc = 11, IdProductPc = 11});
                db.RelationPcs.Add(new RelationPc { IdCategoryPc = 9, IdProductPc = 12}); db.RelationPcs.Add(new RelationPc { IdCategoryPc = 12, IdProductPc = 12 });
                db.RelationPcs.Add(new RelationPc { IdCategoryPc = 7, IdProductPc = 13});
                db.RelationPcs.Add(new RelationPc { IdCategoryPc = 10, IdProductPc = 14}); db.RelationPcs.Add(new RelationPc { IdCategoryPc = 8, IdProductPc = 14 });
                db.SaveChanges();
                db.Purchases.Add(new Purchase { IdProductPurchases = 1, Amount = 33, Date = new DateTime(2015, 7, 20), Status = true });
                db.Purchases.Add(new Purchase { IdProductPurchases = 2, Amount = 13, Date = new DateTime(2021, 10, 28), Status = false });
                db.Purchases.Add(new Purchase { IdProductPurchases = 2, Amount = 3, Date = new DateTime(2021, 10, 28), Status = false });
                db.Purchases.Add(new Purchase { IdProductPurchases = 3, Amount = 20, Date = new DateTime(2021, 10, 28), Status = true });
                db.Purchases.Add(new Purchase { IdProductPurchases = 4, Amount = 30, Date = new DateTime(2021, 10, 28), Status = false });
                db.Purchases.Add(new Purchase { IdProductPurchases = 9, Amount = 50, Date = new DateTime(2021, 10, 28), Status = true });
                db.Purchases.Add(new Purchase { IdProductPurchases = 10, Amount = 60, Date = new DateTime(2021, 10, 28), Status = true });
                db.Purchases.Add(new Purchase { IdProductPurchases = 11, Amount = 11, Date = new DateTime(2021, 10, 28), Status = false });
                db.Purchases.Add(new Purchase { IdProductPurchases = 12, Amount = 7, Date = new DateTime(2021, 10, 28), Status = true });
                db.SaveChanges();
            }

        }
     
    }
}
