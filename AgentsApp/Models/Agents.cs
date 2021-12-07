namespace AgentsApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Agents
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Type_Of_Agent { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Logo { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Priority { get; set; }

        [StringLength(50)]
        public string Director { get; set; }

        [StringLength(50)]
        public string INN { get; set; }

        [StringLength(50)]
        public string KPP { get; set; }
    }
}
