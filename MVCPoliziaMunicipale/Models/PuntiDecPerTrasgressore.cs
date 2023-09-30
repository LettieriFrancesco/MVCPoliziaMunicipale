using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPoliziaMunicipale.Models
{
    public class PuntiDecPerTrasgressore
    {
        [Display(Name = "Cod.Id Trasgressore")]
        public int Id { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Punti Decurtati")]
        public int TotalePuntiDec {  get; set; }

        public PuntiDecPerTrasgressore() { }
        public PuntiDecPerTrasgressore(int _id, string _cognome, string _nome, int _totalePuntiDec) 
        {
            Id = _id;
            Cognome = _cognome;
            Nome = _nome;
            TotalePuntiDec = _totalePuntiDec;
        }
    }
}