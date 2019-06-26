using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
/// <summary>
/// model tabeli Uwagi
/// </summary>
namespace ewidencja.Models
{/// <summary>
/// deklaracja klasy tworzącej tabelę z danymi
/// </summary>
    public class Uwagi
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ObywatelID { get; set; }
        public string Opis { get; set; }
        /// <summary>
        /// połączenie z tabelą Obywatel
        /// </summary>
        public virtual Obywatel Obywatel { get; set; }
    }
}