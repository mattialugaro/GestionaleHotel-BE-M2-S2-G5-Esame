using GestionaleHotel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace GestionaleHotel.Controllers
{
    [Authorize]
    public class ServiziAggiuntiviController : Controller
    {
        public int IDPrenotazione;

        // GET: ServiziAggiuntivi
        public ActionResult Create(int id)
        {
            IDPrenotazione = id;
            return View();
        }
            
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiziAggiuntivi s)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "INSERT INTO ServiziAggiuntivi(Descrizione, DataServizio, Quantita, Prezzo, IDPrenotazione) VALUES(@Descrizione, @DataServizio, @Quantita, @Prezzo, @IDPrenotazione)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Descrizione", s.Descrizione);
                cmd.Parameters.AddWithValue("@DataServizio", s.DataServizio);
                cmd.Parameters.AddWithValue("@Quantita", s.Quantita);
                cmd.Parameters.AddWithValue("@Prezzo", s.Prezzo);
                cmd.Parameters.AddWithValue("@IDPrenotazione", IDPrenotazione);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return RedirectToAction("Index", "ServiziAggiuntivi");
        }

        public ActionResult Index()
        {
            List<ServiziAggiuntivi> listaServizi = new List<ServiziAggiuntivi>();
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "SELECT * FROM ServiziAggiuntivi WHERE IDPrenotazione = @IDPrenotazione";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@IDPrenotazione", IDPrenotazione);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ServiziAggiuntivi s = new ServiziAggiuntivi();
                    s.Descrizione = reader["Descrizione"].ToString();
                    s.DataServizio = Convert.ToDateTime(reader["DataServizio"]);
                    s.Prezzo = Convert.ToInt16(reader["Prezzo"]);
                    s.Quantita = Convert.ToInt16(reader["Quantita"]);
                    listaServizi.Add(s);
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return View(listaServizi);
        }
    }

}