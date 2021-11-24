using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftPizzaHut
{
    public partial class Product
    {
        public Product()
        {
            Purchases = new HashSet<Purchase>();
            RelationPcs = new HashSet<RelationPc>();
        }

        public int IdProduct { get; set; }
        public string NameProduct { get; set; } = null!;
        public int IdProviderProduct { get; set; }
        public int Price { get; set; }
        public string Unit { get; set; } = null!;
        [NotMapped]
        public virtual Provider Provider { get; set; }
        [NotMapped]
        public Provider ProductProvider
        {
            get
            {
                return DataWorker.GetProviderById(IdProviderProduct);
            }
        }
        [NotMapped]
        public List<Сategory> ProductCategories
        {
            get
            {
                return DataWorker.GetAllСategoriesById(IdProduct);
            }
        }
        [NotMapped]
        public string AllCategoriesString => DataWorker.AllCategoriesString(ProductCategories);


        public virtual Provider IdProviderProductNavigation { get; set; } = null!;
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<RelationPc> RelationPcs { get; set; }
       
    }
}
