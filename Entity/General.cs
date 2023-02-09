using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class General
    {
        //provizyonuz araç kiralama eki sitenin en üstünde olacak.
        public int Id { get; set; }
        [Display(Name="Firma Adı")]
        public string Name { get; set; }
        [Display(Name = "Hakkımızda")]

        public string description { get; set; }

        [Display(Name="Ofis Hakkında")]
        public string aboutOffice { get; set; }

        [Display(Name = "Telefon")]

        public string tel1 { get; set; }
        [Display(Name = "WhatsApp Hattı")]

        public string tel2 { get; set; }
        [Display(Name = "E-mail Adresi")]

        public string email { get; set; }
        [Display(Name = "Adres")]

        public string adress { get; set; }

        [Display(Name="Google Harita Linki")]
        public string Maps { get; set; }

        [Display(Name = "Provizyon Hakkında")]

        public string provizyon_desc { get; set; }
    }
}
