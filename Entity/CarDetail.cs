using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CarDetail:IEntity
    {
        [ForeignKey("Car")]
        public int Id { get; set; }
        //Otomatik  Manuel
        public string CarClass { get; set; }
        public string CarFuel { get; set; }
        public int Doors { get; set; }
        public int Seats { get; set; }
        public string Properties { get; set; }
        public DateTime? CarDate { get; set; }
        public string CarAbout { get; set; }


        public virtual Car Car { get; set; }

    }
}
