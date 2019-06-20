using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ewidencja.Models
{
    public class Uwagi
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ObywatelID { get; set; }
        public string Opis { get; set; }

        public virtual Obywatel Obywatel { get; set; }
    }
}