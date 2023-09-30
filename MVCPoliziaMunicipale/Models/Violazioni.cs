using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPoliziaMunicipale.Models
{
    public class Violazioni
    {
        [Display(Name = "Cod. Id Violazione")]
        public int IdViolazione { get; set; }
        [Display(Name ="Descrizione Violazione")]
        public string DescrizioneViolazione { get; set; }

        public Violazioni() { }
        public Violazioni(int _idViolazione, string _descrizioneViolazione) 
        {
            IdViolazione = _idViolazione;
            DescrizioneViolazione = _descrizioneViolazione;
        }
        public Violazioni(string _descrizioneViolazione)
        {
            DescrizioneViolazione = _descrizioneViolazione;
        }
    }
}