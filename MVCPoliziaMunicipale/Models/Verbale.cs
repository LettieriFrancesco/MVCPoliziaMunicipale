using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPoliziaMunicipale.Models
{
    public class Verbale
    {
        [Display(Name = "Cod.Id Verbale")]
        public int IdVerbale { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Data Violazione")]
        public DateTime DataViolazione { get; set; }
        [Display(Name = "Indirizzo Violazione")]
        public string IndirizzoViolazione { get; set; }
        [Display(Name = "Nominativo Agente")]
        public string NominativoAgente { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Data Trascrizione Verbale")]
        public DateTime DataTrascrizioneVerbale { get; set; }
        [Display(Name = "Importo")]
        public double Importo { get; set; }
        [Display(Name ="Punti Decurtati")]
        public int DecurtamentoPunti {  get; set; }
        [Display(Name = "Cod.Id Trasgressore")]

        public int IdTrasgressore { get; set; }
        [Display(Name = "Cod.Id Violazione")]

        public int IdViolazione { get; set; }

        public Verbale() { }
        public Verbale(int _idVerbale, DateTime _dataViolazione, string _indirizzoViolazione, string _nominativoAgente, DateTime _dataTrascrizioneVerbale, double _importo, int _decurtamentoPunti, int _idTrasgressore, int _idViolazione) 
        {
            IdVerbale = _idVerbale;
            DataViolazione = _dataViolazione;
            IndirizzoViolazione = _indirizzoViolazione;
            NominativoAgente = _nominativoAgente;
            DataTrascrizioneVerbale = _dataTrascrizioneVerbale;
            Importo = _importo;
            DecurtamentoPunti = _decurtamentoPunti;
            IdTrasgressore = _idTrasgressore;
            IdViolazione = _idViolazione;
        }
        public Verbale(int _idVerbale, DateTime _dataViolazione, string _indirizzoViolazione, string _nominativoAgente, DateTime _dataTrascrizioneVerbale, double _importo, int _decurtamentoPunti) 
        {
            IdVerbale = _idVerbale;
            DataViolazione = _dataViolazione;
            IndirizzoViolazione = _indirizzoViolazione;
            NominativoAgente = _nominativoAgente;
            DataTrascrizioneVerbale = _dataTrascrizioneVerbale;
            Importo = _importo;
            DecurtamentoPunti = _decurtamentoPunti;
        }
        public Verbale(DateTime _dataViolazione, string _indirizzoViolazione, string _nominativoAgente, DateTime _dataTrascrizioneVerbale, double _importo, int _decurtamentoPunti)
        {
            DataViolazione = _dataViolazione;
            IndirizzoViolazione = _indirizzoViolazione;
            NominativoAgente = _nominativoAgente;
            DataTrascrizioneVerbale = _dataTrascrizioneVerbale;
            Importo = _importo;
            DecurtamentoPunti = _decurtamentoPunti;
        }
    }
}