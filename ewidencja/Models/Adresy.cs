using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
/// <summary>
/// Model tabeli adresy
/// </summary>
namespace ewidencja.Models
{
    /// <summary>
    /// deklaracja listy rozwijanej Pobyt
    /// </summary>
    public enum Pobyt
    {
        stały, tymczasowy
    }
    /// <summary>
    /// deklaracja listy rozwijanej Status adresu
    /// </summary>
    public enum Statusadr
    {
        adres_korespondencyjny, adres_zameldowania, adres_główny
    }/// <summary>
    /// klasa tworąca widok tabeli Adresy
    /// </summary>
    public class Adresy
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ObywatelID {get;set;}
        public string Ulica { get; set; }
        public string Miasto { get; set; }
        public string Kod_pocztowy { get; set; }
        public string Poczta { get; set; }
        public string Gmina { get; set; }
        public string Powiat { get; set; }
        public string Wojewodztwo { get; set; }
        public DateTime Data_zam { get; set; }
        public DateTime Data_wym { get; set; }
        public Pobyt? Pobyt { get; set; }
        public Statusadr? Statusadr { get; set; }
        /// <summary>
        /// połączenie z tabelą Obywatel
        /// </summary>
        public virtual Obywatel Obywatel { get; set; }


    }
}