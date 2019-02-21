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
            _db = db;  //db: Unity of Works den geliyor
        }



        public virtual void ArabaylaEkle(CarDetail yenidetay,int id)
        //doğrusu
        //db den markayı seçtiğimiz için,mevcut bir kayıt olduğunu biliyor
        {
            yenidetay.Id = id;

            // yanlış
            /*
             * urun.Marka=new Marka() {Id=MarkaId,MarkAdi="adi"};
             * Aynı biligiler olsa bile yeni marka
             * 
             
    */




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

            var eski = _db.Car.Find(yeni.Id);



            _db.Entry(eski).CurrentValues.SetValues(yeni);
            _db.Entry(eski).State = EntityState.Modified;
            _db.SaveChanges();
        }


    }
}

