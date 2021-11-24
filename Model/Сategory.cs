using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace SoftPizzaHut
{
    public partial class Сategory
    {
        public Сategory()
        {
            RelationPcs = new HashSet<RelationPc>();
        }

        public int IdCategory { get; set; }
        public string NameCategory { get; set; } = null!;

        public virtual ICollection<RelationPc> RelationPcs { get; set; }
    }
}
