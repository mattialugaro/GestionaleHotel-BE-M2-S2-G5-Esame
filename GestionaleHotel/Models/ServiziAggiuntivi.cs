using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GestionaleHotel.Models
{
    public class ServiziAggiuntivi
    {
        [ScaffoldColumn(false)]
        public int IDServiziAggiuntivi { get; set; }

        [Required(ErrorMessage = "La Data del Servizio è un campo obbligatorio")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.DateTime)]
        [DisplayName("Data del Servizio")]
        public DateTime DataServizio { get; set; }

        [Required(ErrorMessage = "La Descrizione del Servizio è un campo obbligatorio")]
        [DisplayName("Descrizione Servizio")]
        public string Descrizione { get; set; }

        [Required(ErrorMessage = "La Quantità del Servizio è un campo obbligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "La Quantità deve essere maggiore di 0")]
        [DisplayName("Quantità Servizio")]
        public int Quantita { get; set; }

        [Required(ErrorMessage = "Il Prezzo del Servizio è un campo obbligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Il Prezzo del Servizio deve essere maggiore di 0")]
        [DisplayName("Prezzo Servizio")]
        public decimal Prezzo {  get; set; }

        [Required(ErrorMessage = "L' IDPrenotazione è un campo obbligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "L' IDPrenotazione deve essere maggiore di 0")]
        public int IDPrenotazione {  get; set; }
    }
}