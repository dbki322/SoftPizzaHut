using System;
using System.Collections.Generic;

namespace SoftPizzaHut
{
    public partial class RelationPc
    {
        public int IdRelationPc { get; set; }
        public int IdProductPc { get; set; }
        public int IdCategoryPc { get; set; }

        public virtual Сategory IdCategoryPcNavigation { get; set; } = null!;
        public virtual Product IdProductPcNavigation { get; set; } = null!;
    }
}
