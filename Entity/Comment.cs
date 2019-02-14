using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Comment:IEntity
    {
        [Key]
        public int Id { get; set; }

        public int Stars { get; set; }
        public string comment { get; set; }
        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }

        //public int CustomerId { get; set; }
        //public Customer Customer { get; set; }
    }
}

