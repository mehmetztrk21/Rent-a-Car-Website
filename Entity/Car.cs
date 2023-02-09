using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Car
    {
        public int Id { get; set; }
        [Display(Name="Araç")]
        public string name { get; set; }
        [Display(Name = "Model")]

        public string model { get; set; }
        [Display(Name = "Resim")]

        public string image { get; set; }
        [Display(Name = "Kilometre")]

        public double km { get; set; }
        [Display(Name = "Haftalık Ücret")]

        public double weekly_price { get; set; }
        [Display(Name = "Günlük Ücret")]

        public double daily_price { get; set; }
      
        [Display(Name = "Araç Tipi (Otomatik-Manuel)")]

        public string type { get; set; }  //otomatik-manuel (vites)
        [Display(Name = "Araç Hakkında")]
         
        public string description { get; set; }  //ckEditor kullan. Araç ile ilgili her şey burada yazacak.
        public bool Anasayfa { get; set; }
        [Display(Name = "Kategori")]

        public int CategoryId { get; set; }
        public Category category { get; set; }




    }
}
