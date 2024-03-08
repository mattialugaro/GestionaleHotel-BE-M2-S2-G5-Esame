using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionaleHotel.Models
{
    public class Camera
    {
        [ScaffoldColumn(false)]
        public int IDCamera {  get; set; }

        [Required(ErrorMessage = "Il Numero Camera è un campo obbligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Il Numero Camera deve essere maggiore di 0")]
        [DisplayName("Numero Camera")]
        public int NumeroCamera { get; set; }

        [DisplayName("Descrizione Camera")]
        public string Descrizione { get; set; }

        [Required(ErrorMessage = "La Tipologia della Camera è un campo obbligatorio")]
        [StringLength(7, ErrorMessage = "La Tipologia della Camera non può avere più di 7 caratteri")]
        [checkTipologiaCamera(Type = "Singola,Doppia", ErrorMessage = "La Tipologia della Camera può essere solo Singola o Dopppia.")]
        [DisplayName("Tipologia della Camera")]
        public string Tipologia { get; set; }
    }
}