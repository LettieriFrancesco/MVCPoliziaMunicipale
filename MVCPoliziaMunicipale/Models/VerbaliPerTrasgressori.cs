using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPoliziaMunicipale.Models
{
    public class VerbaliPerTrasgressori
    {
        [Display(Name = "Cod.Id Trasgressore")]
        public int IdTrasgressore { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Totale Verbali")]
        public int TotaleVerbali { get; set; }

        public VerbaliPerTrasgressori() { }
        public VerbaliPerTrasgressori(int _id, string _cognome, string _nome, int _totaleV) 
        {
            IdTrasgressore = _id;
            Cognome = _cognome;
            Nome = _nome;
            TotaleVerbali = _totaleV;
        }
    }
}