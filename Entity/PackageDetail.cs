using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class PackageDetail:IEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(600)]
        public string PackageContent { get; set; }

        [ForeignKey("Package")]
        public int PackageID { get; set; }
        public virtual Package Package { get; set; }

    }
}
