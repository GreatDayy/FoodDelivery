namespace BackEndLuncher
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DishId { get; set; }

        [StringLength(300)]
        public string OrderDescription { get; set; }

        [Required]
        [StringLength(50)]
        public string ContactMail { get; set; }

        public bool OrderHandled { get; set; }

        public virtual Dishes Dishes { get; set; }
    }
}
