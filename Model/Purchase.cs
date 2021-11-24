using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftPizzaHut
{
    public partial class Purchase
    {
        public int IdPurchase { get; set; }
        public int IdProductPurchases { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        [NotMapped]
        public virtual Product Product { get; set; }
        [NotMapped]
        public Product PurchaseProduct
        {
            get
            {
                return DataWorker.GetProductById(IdProductPurchases);
            }
        }
        [NotMapped]
        public int PurchaseSum
        {
            get
            {
                return DataWorker.GetSum(Amount, PurchaseProduct.Price);
            }
        }
        public virtual Product IdProductPurchasesNavigation { get; set; } = null!;

    }
}
