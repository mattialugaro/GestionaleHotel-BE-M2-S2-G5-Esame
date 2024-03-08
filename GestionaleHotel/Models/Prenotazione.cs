using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GestionaleHotel.Models
{
    public class Prenotazione
    {
        [ScaffoldColumn(false)]
        public int IDPrenotazione { get; set; }

        [Required(ErrorMessage = "La Data Prenotazione è un campo obbligatorio")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.DateTime)]
        [DisplayName("Data Prenotazione")]
        public DateTime DataPrenotazione { get; set; }

        [Required(ErrorMessage = "L'anno della Prenotazione è un campo obbligatorio")]
        [Range(2024, int.MaxValue, ErrorMessage = "L'anno della Prenotazione deve essere maggiore di 2023")]
        [DisplayName("L'anno della Prenotazione")]
        public int AnnoPrenotazione { get; set; }

        [Required(ErrorMessage = "L'Inizio del Soggiorno è un campo obbligatorio")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.DateTime)]
        [DisplayName("L'Inizio del Soggiorno")]
        public DateTime InizioSoggiorno { get; set; }

        [Required(ErrorMessage = "La Fine del Soggiorno è un campo obbligatorio")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.DateTime)]
        [DisplayName("La Fine del Soggiorno")]
        public DateTime FineSoggiorno { get; set; }

        [Required(ErrorMessage = "La Caparra è un campo obbligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "La Caparra deve essere maggiore di 0")]
        public decimal Caparra { get; set; }

        [Required(ErrorMessage = "La Tariffa del Soggiorno è un campo obbligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "La Tariffa del Soggiorno deve essere maggiore di 0")]
        [DisplayName("La Tariffa del Soggiorno")]
        public decimal TariffaSoggiorno { get; set; }

        [Required(ErrorMessage = "La Tipologia della Prenotazione è un campo obbligatorio")]
        [StringLength(2, ErrorMessage = "La Tipologia della Prenotazione non può avere più di 2 caratteri")]
        [checkTipologiaPrenotazione(Type = "BB,HB,FB", ErrorMessage = "La Tipologia della Prenotazione può essere solo BB, HB o FB.")]
        [DisplayName("La Tipologia della Prenotazione")]
        public string TipologiaPrenotazione { get; set; }

        [Required(ErrorMessage = "L' IDCliente è un campo obbligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "L' IDCliente deve essere maggiore di 0")]
        public int IDCliente { get; set; }

        [Required(ErrorMessage = "L' IDCamera è un campo obbligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "L' IDCamera deve essere maggiore di 0")]
        public int IDCamera { get; set; }
    }
}