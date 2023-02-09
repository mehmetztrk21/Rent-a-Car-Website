using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name="Ad")]
        public string name { get; set; }
        [Display(Name ="Hakkında")]
        public string description { get; set; }
        public List<Car> cars { get; set; }
    }
}
