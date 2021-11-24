using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace SoftPizzaHut
{
    public partial class Provider
    {
        public Provider()
        {
            Products = new HashSet<Product>();
        }

        public int IdProvider { get; set; }
        public string NameProvider { get; set; } = null!;
        public string? Inn { get; set; }
        public string? Kpp { get; set; }
        public string? Ogrn { get; set; }
        public string? Address { get; set; }
        public string? Registration { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
