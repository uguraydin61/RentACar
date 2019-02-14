using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entity
{
    public class Customer:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [MaxLength(11)]
        public string TCNo { get; set; }
        public string Adress { get; set; }
        public string TelNo { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [ForeignKey("Package")]
        public int PackageId { get; set; }
        public virtual Package Package { get; set; }


        public virtual List<Rezervation> Rezervations { get; set; }

    }
}
