using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionaleHotel.Models
{
    public class Dipendente
    {
        [ScaffoldColumn(false)]
        public int IDDipendente { get; set; }
        
        [Required(ErrorMessage = "Lo Username è un campo obbligatorio")]
        [StringLength(50, ErrorMessage = "Lo Username non può avere più di 50 caratteri")]
        public string Username {  get; set; }

        [Required(ErrorMessage = "La Password è un campo obbligatorio")]
        [StringLength(50, ErrorMessage = "La Password non può avere più di 50 caratteri")]
        public string Password { get; set; }

    }
}