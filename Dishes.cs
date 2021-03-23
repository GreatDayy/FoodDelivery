namespace BackEndLuncher
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dishes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dishes()
        {
            MenuDishes = new HashSet<MenuDishes>();
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DishName { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }

        public int Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        [StringLength(100)]
        public string AllergyInformation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MenuDishes> MenuDishes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
