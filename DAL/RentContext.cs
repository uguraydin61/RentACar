using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
   public  class RentContext:DbContext
    {
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<CarDetail> CarDetail { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<CarBrand> CarBrand { get; set; }
        public virtual DbSet<Rezervation> Rezervation { get; set; }
        public virtual DbSet<PackageDetail> PackageDetail { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
    }
}
