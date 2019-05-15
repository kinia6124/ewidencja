using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ewidencja.Models
{
    public class Obywatel
    {
        [Key]
        public int Idobywatel { get; set; }
        public char Imie { get; set; }
        public char Nazwisko { get; set; }
        public string PESEL { get; set; }
    }
}