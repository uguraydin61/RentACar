using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Car:IEntity
    {

        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string CarModel { get; set; }
        public int numbersCar { get; set; }
        #region Bayii
        [ForeignKey("Vendor")]
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }
        #endregion
        #region Yorum
        public virtual List<Comment> Comments { get; set; }
        #endregion
        #region Rezervasyon
        public virtual List<Rezervation> Rezervations { get; set; }
        #endregion
        [ForeignKey("CarBrand")]
        public int BrandId { get; set; }
        public virtual CarBrand CarBrand { get; set; }

        public virtual CarDetail CarDetail { get; set; }

    }
}
