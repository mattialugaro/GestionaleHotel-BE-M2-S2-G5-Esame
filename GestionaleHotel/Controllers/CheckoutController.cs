using GestionaleHotel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionaleHotel.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index(int id)
        {
            List<Checkout> listaChechout = new List<Checkout>();
            Checkout checkout = new Checkout();
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "SELECT NumeroCamera, InizioSoggiorno, FineSoggiorno, TariffaSoggiorno FROM Prenotazione AS P INNER JOIN Camera AS C ON P.IDCamera = C.IDCamera WHERE IDPrenotazione = @IDPrenotazione";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    
                    checkout.NumeroCamera = Convert.ToInt16(reader["NumeroCamera"]);
                    checkout.InizioSoggiorno = Convert.ToDateTime(reader["InizioSoggiorno"]);
                    checkout.FineSoggiorno = Convert.ToDateTime(reader["FineSoggiorno"]);
                    checkout.Caparra = Convert.ToInt16(reader["Caparra"]);
                    checkout.TariffaSoggiorno = Convert.ToInt16(reader["TariffaSoggiorno"]);
                }

                query = "SELECT * FROM ServiziAggiuntivi WHERE IDPrenotazione = @IDPrenotazione";

                SqlCommand cmd2 = new SqlCommand(query, conn);
                SqlDataReader reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    ServiziAggiuntivi serviziAggiuntivi = new ServiziAggiuntivi();
                    serviziAggiuntivi.Descrizione = reader2["Descrizione"].ToString();
                    serviziAggiuntivi.DataServizio = Convert.ToDateTime(reader2["Descrizione"]);
                    serviziAggiuntivi.Quantita = Convert.ToInt16(reader2["Quantita"]);
                    serviziAggiuntivi.Prezzo = Convert.ToInt16(reader2["Prezzo"]);
                    checkout.listaServizi.Add( serviziAggiuntivi );
                }

                decimal PrezzoTotaleServizi = 0;

                foreach (var servizio in checkout.listaServizi)
                {
                    decimal PrezzoQuantita = servizio.Quantita * servizio.Prezzo;
                    PrezzoTotaleServizi =+ PrezzoQuantita;
                }

                checkout.SaldoFinale = checkout.TariffaSoggiorno - checkout.Caparra + PrezzoTotaleServizi;
                listaChechout.Add(checkout);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return View(listaChechout);
        }

    }
}