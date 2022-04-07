using EFTask2.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTask2.context
{
    internal class HotelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                    => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=HotelDb; Integrated Security=true;");
    
      public virtual DbSet<Reservation> Reservations { get; set; }  //To have a table in db when update
    }
}
