using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
   
    public class IndexModel
    {

        public List<Car> Cars { get; set; }
        public List<Category> Categories { get; set; }
        public List<Comments> Comments { get; set; }
        public General general { get; set; }
        public int category_control { get; set; }
    }
}
