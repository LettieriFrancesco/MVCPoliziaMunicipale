using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace MVCPoliziaMunicipale.Models
{
    public class VerbaliOver400
    {
        public string Cognome { get; set; }
        public string Nome { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Data Violazione")]
        public DateTime DataViolazione { get; set; }
        public double Importo { get; set; }
        [Display(Name = "Punti Decurtati")]
        public int PuntiDecurtati { get; set; }

        public VerbaliOver400() { }
        public VerbaliOver400(string _cognome,  string _nome, DateTime _dataViolazione, double _importo, int _puntiDecurtati)
        {
            Cognome = _cognome;
            Nome = _nome;
            DataViolazione = _dataViolazione;
            Importo = _importo;
            PuntiDecurtati = _puntiDecurtati;
        }
    }
}