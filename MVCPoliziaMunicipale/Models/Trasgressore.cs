using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPoliziaMunicipale.Models
{
    public class Trasgressore
    {
        [Display(Name = "Cod.Id Trasgressore")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        [Display(Name = "Città")]
        public string Citta { get; set; }
        public int Cap {  get; set; }
        [Display(Name = "Codice Fiscale")]
        public string CodiceFiscale { get; set; }

        public Trasgressore() { }
        public Trasgressore(int _id, string _nome, string _cognome, string _indirizzo, string _citta,int _cap, string _codiceFiscale) 
        {
            Id = _id;
            Nome = _nome;
            Cognome = _cognome;
            Indirizzo = _indirizzo;
            Citta = _citta;
            Cap = _cap;
            CodiceFiscale = _codiceFiscale;
        }
        public Trasgressore(string _nome, string _cognome, string _indirizzo, string _citta, int _cap, string _codiceFiscale) 
        {
            Nome = _nome;
            Cognome = _cognome;
            Indirizzo = _indirizzo;
            Citta = _citta;
            Cap = _cap;
            CodiceFiscale = _codiceFiscale;
        }
    }
}