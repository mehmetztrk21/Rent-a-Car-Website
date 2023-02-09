using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class CarDetailsModel
    {
        public Car car { get; set; }
        public General general { get; set; }
    }
}
