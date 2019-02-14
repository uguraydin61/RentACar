using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL
{
    public class UnitOfWork
    {
        public RentContext db = new RentContext();

        public BaseRepository<Blog> BlogRep;
        public BaseRepository<Car> CarRep;
        public BaseRepository<CarBrand> CarBrandRep;
        public BaseRepository<CarDetail> CarDetailRep;
        public BaseRepository<Comment> CommentRep;
        public BaseRepository<Customer> CustomerRep;
        public BaseRepository<Package> PackageRep;
        public BaseRepository<PackageDetail> PackageDetailRep;
        public BaseRepository<Rezervation> RezervationRep;
        public BaseRepository<Vendor> VendorRep;

        public UnitOfWork()
        {
            BlogRep = new BaseRepository<Blog>(db);
            CarRep = new BaseRepository<Car>(db);
            CarBrandRep = new BaseRepository<CarBrand>(db);
            CarDetailRep = new BaseRepository<CarDetail>(db);
            CommentRep = new BaseRepository<Comment>(db);
            CustomerRep = new BaseRepository<Customer>(db);
            PackageRep = new BaseRepository<Package>(db);
            PackageDetailRep = new BaseRepository<PackageDetail>(db);
            RezervationRep = new BaseRepository<Rezervation>(db);
            VendorRep = new BaseRepository<Vendor>(db);
        }
    }
}
