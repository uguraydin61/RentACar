using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
     public class CarDetailRepository:BaseRepository<CarDetail>
    {
        RentContext _db;
        public CarDetailRepository(RentContext db) : base(db)
        {
            _db = db;  
        }



        public virtual void ArabaylaEkle(CarDetail yenidetay,int id)
       
        {
            yenidetay.Id = id;
                 _db.CarDetail.Add(yenidetay);
            _db.SaveChanges();


        }


        public override void Sil(int Id)
        {
            //çoka çok ilişkiden dolayı ürünü silmeden önce ürün gruplarıyla ilgili kayıtlarını silmeliyiz
            var car = BirTaneGetir(Id);

            base.Sil(Id); // Ürünü Sil
        }
        public override void Guncelle(IEntity yeni)
        {

            var eski = _db.CarDetail.Find(yeni.Id);



            _db.Entry(eski).CurrentValues.SetValues(yeni);
            _db.Entry(eski).State = EntityState.Modified;
            _db.SaveChanges();
        }


    }
}

