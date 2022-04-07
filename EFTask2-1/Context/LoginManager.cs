using EFTask2.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTask2.context
{
    public class LoginManager : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                  => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=HotelMgrLogin;Integrated Security=true;");
        public virtual DbSet<Frontend> Frontends { get; set; }  //To have a table in db when update
        public virtual DbSet<Kitchen>  Kitchens { get; set; }  //To have a table in db when update


        #region Fluent
        //Fluent API configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Frontend>()
                .HasKey(F => F.UserName);

            //Ignored() => Donoot map
            modelBuilder.Entity<Frontend>().Property(P => P.UserName)
                 .IsRequired()
                 .HasMaxLength(50);

            modelBuilder.Entity<Frontend>().Property(P => P.PassWord)
             .IsRequired()
             .HasMaxLength(50);


            /********************************/

            modelBuilder.Entity<Kitchen>()
               .HasKey(F => F.UserName);

            modelBuilder.Entity<Kitchen>().Property(P => P.UserName)
                 .IsRequired()
                 .HasMaxLength(50);

            modelBuilder.Entity<Kitchen>().Property(P => P.PassWord)
                 .IsRequired()
                 .HasMaxLength(50);

        }
    }
}
#endregion