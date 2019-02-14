using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public DateTime BlogDate { get; set; }
    }
}
