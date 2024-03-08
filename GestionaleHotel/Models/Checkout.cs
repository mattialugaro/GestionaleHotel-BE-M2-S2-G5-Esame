using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionaleHotel.Models
{
    public class Checkout
    {
        [DisplayName("Numero Camera")]
        public int NumeroCamera { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("L'Inizio del Soggiorno")]
        public DateTime InizioSoggiorno { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("La Fine del Soggiorno")]
        public DateTime FineSoggiorno { get; set; }

        [DisplayName("La Tariffa del Soggiorno")]
        public decimal TariffaSoggiorno { get; set; }

        public decimal Caparra {  get; set; }

        public decimal SaldoFinale {  get; set; }
        public List<ServiziAggiuntivi> listaServizi {  get; set; }

    }
}