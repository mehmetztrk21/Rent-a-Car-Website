using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Message
    {
        public int Id { get; set; }
        [Display(Name="Ad")]
        public string name { get; set; }
        [Display(Name = "Mail")]

        public string mail { get; set; }
        [Display(Name = "Telefon")]

        public string phone { get; set; }
        [Display(Name = "Başlık")]

        public string title { get; set; }
        [Display(Name = "Mesaj")]

        public string content { get; set; }
        [Display(Name ="Tarih")]
        public DateTime date { get; set; }
    }
}
