using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY_FRAMEWORK_CORE
{
    public class AplicationDbContex : DbContext
    {
        public AplicationDbContex(DbContextOptions<AplicationDbContex> options) : base(options)
        {
      
        }

        public virtual DbSet<Product> Productos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>();


            base.OnModelCreating(modelBuilder);
        }


    }
}
