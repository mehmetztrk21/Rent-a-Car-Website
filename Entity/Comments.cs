using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Comments
    {
        public int Id { get; set; }
        [Display(Name="Ad")]
        public string Name { get; set; }
        [Display(Name="Yorum")]
        public string Comment { get; set; }
    }
}
