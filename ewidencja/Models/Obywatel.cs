using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
/// <summary>
/// model tabeli Obywatel
/// </summary>
namespace ewidencja.Models
{
    /// <summary>
    /// deklaracja listy rozwijanej Status jako element widoku
    /// </summary>
    public enum Status
    {
        bez_stałego_pobytu, bez_stałego_zameldowania, osoba_zmarła, zameldowany_zagranicą
    }/// <summary>
    /// utworzenie modelu tabeli Obywatel
    /// </summary>
    public class Obywatel
    {
        
        public int ID { get; set; }
        public string PESEL { get; set; }
        public string Imie { get; set; }
        public string Drugie_imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime Data_urodzenia { get; set; }
        public DateTime Data_zgonu { get; set; }
        public Status? Status { get; set; }
        /// <summary>
        /// połączenie z tabelą Adresy
        /// </summary>
        public virtual ICollection<Adresy> Adresies { get; set; }
        /// <summary>
        /// połączenie z tabelą Uwagi
        /// </summary>
        public virtual ICollection<Uwagi> Uwagis { get; set; }

    }
}