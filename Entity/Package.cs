using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Package:IEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(150)]
        public string PackageName { get; set; }

        public decimal Price { get; set; }

        public virtual List<PackageDetail> PackageDetails { get; set; }

        public virtual List<Customer> Customer { get; set; }

    }
}
