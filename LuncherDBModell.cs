using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BackEndLuncher
{
    public partial class LuncherDBModell : DbContext, ILuncherAppContext
    {
        public LuncherDBModell()
            : base("LuncherDBModell")
        {
        }

        public virtual DbSet<Dishes> Dishes { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuDishes> MenuDishes { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        //1
        public void MarkAsModified(Dishes item)
        {
            Entry(item).State = EntityState.Modified;
        }
        //2
        public void MarkAsModified(Menu item)
        {
            Entry(item).State = EntityState.Modified;
        }


        public void MarkAsModified(Orders item)
        {
            Entry(item).State = EntityState.Modified;
        }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dishes>()
                .Property(e => e.DishName)
                .IsUnicode(false);

            modelBuilder.Entity<Dishes>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Dishes>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<Dishes>()
                .Property(e => e.AllergyInformation)
                .IsUnicode(false);

            modelBuilder.Entity<Dishes>()
                .HasMany(e => e.MenuDishes)
                .WithRequired(e => e.Dishes)
                .HasForeignKey(e => e.DishId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dishes>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Dishes)
                .HasForeignKey(e => e.DishId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.MenuDishes)
                .WithRequired(e => e.Menu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.OrderDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.ContactMail)
                .IsUnicode(false);
        }
    }
}
