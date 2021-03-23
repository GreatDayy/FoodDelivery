using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BackEndLuncher
{
    public interface ILuncherAppContext : IDisposable
    {
        //Break the Dependency of the class LuncherDbModell
        //1
        DbSet<Dishes> Dishes { get; }

        //2
        DbSet<Menu> Menu { get; set; }

        DbSet<Orders> Orders { get; set; }

        //4
        int SaveChanges();

        //1
        void MarkAsModified(Dishes item);

        //2
        void MarkAsModified(Menu item);
        void MarkAsModified(Orders item);
    }
}