using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPoliziaMunicipale.Models
{
    public class ViolazioneOver10Punti
    {
        public string Nome {  get; set; }
        public string Cognome { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name ="Data Violazione")]
        public DateTime DataViolazione { get; set; }
        [Display(Name = "Importo")]
        public double Importo { get; set; }
        [Display(Name = "Punti Decurtati")]
        public int PuntiDec {  get; set; }

        public ViolazioneOver10Punti() { }
        public ViolazioneOver10Punti(string _nome, string _cognome, DateTime _dataViolazione, double _importo, int _puntiDec) 
        {
            Nome = _nome;
            Cognome = _cognome;
            DataViolazione = _dataViolazione;
            Importo = _importo;
            PuntiDec = _puntiDec;
        }
    }
}