using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GestionaleHotel.Models
{
    public class Cliente
    {
        [ScaffoldColumn(false)]
        public int IDCliente { get; set; }

        [Required(ErrorMessage = "Il Codice Fiscale è un campo obbligatorio")]
        [StringLength(16, ErrorMessage = "Il Codice Fiscale non può avere più di 16 caratteri")]
        [DisplayName("Codice Fiscale")]
        public string CodiceFiscale { get; set; }

        [Required(ErrorMessage = "Il Nome è un campo obbligatorio")]
        [StringLength(50, ErrorMessage = "Il Nome non può avere più di 50 caratteri")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il Cognome è un campo obbligatorio")]
        [StringLength(50, ErrorMessage = "Il Cognome non può avere più di 50 caratteri")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "L' Email è un campo obbligatorio")]
        [StringLength(50, ErrorMessage = "L' Email non può avere più di 50 caratteri")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "La Città è un campo obbligatorio")]
        [StringLength(50, ErrorMessage = "La Città non può avere più di 50 caratteri")]
        public string Citta { get; set; }
        
        [Required(ErrorMessage = "La Provincia è un campo obbligatorio")]
        [StringLength(50, ErrorMessage = "La Provincia non può avere più di 50 caratteri")]
        public string Provincia { get; set; }

        [StringLength(50, ErrorMessage = "Il Telefono non può avere più di 50 caratteri")]
        public string Telefono { get; set; }
        
        [Required(ErrorMessage = "Il Cellulare è un campo obbligatorio")]
        [StringLength(50, ErrorMessage = "Il Cellulare non può avere più di 50 caratteri")]
        public string Cellulare { get; set; }




    }
}