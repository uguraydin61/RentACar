using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CarBrand:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ImageURL { get; set; }
        public virtual List<Car> Cars { get; set; }
    }
}
