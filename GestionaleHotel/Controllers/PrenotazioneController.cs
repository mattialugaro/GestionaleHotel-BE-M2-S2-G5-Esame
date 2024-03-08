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
    [Authorize]
    public class PrenotazioneController : Controller
    {
        // GET: Prenotazione
        public ActionResult Index()
        {
            List<Prenotazione> listaPrenotazioni = new List<Prenotazione>();
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Prenotazione";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Prenotazione p = new Prenotazione();
                    p.IDPrenotazione = Convert.ToInt16(reader["IDPrenotazione"]);
                    p.DataPrenotazione = Convert.ToDateTime(reader["DataPrenotazione"]);
                    p.AnnoPrenotazione = Convert.ToInt16(reader["AnnoPrenotazione"]);
                    p.InizioSoggiorno = Convert.ToDateTime(reader["InizioSoggiorno"]);
                    p.FineSoggiorno = Convert.ToDateTime(reader["FineSoggiorno"]);
                    p.Caparra = Convert.ToDecimal(reader["Caparra"]);
                    p.TariffaSoggiorno = Convert.ToDecimal(reader["TariffaSoggiorno"]);
                    p.TipologiaPrenotazione = reader["TipologiaPrenotazione"].ToString();
                    p.IDCliente = Convert.ToInt16(reader["IDCliente"]);
                    p.IDCamera = Convert.ToInt16(reader["IDCamera"]);
                    listaPrenotazioni.Add(p);
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

            return View(listaPrenotazioni);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Prenotazione p)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "INSERT INTO Prenotazione(DataPrenotazione, AnnoPrenotazione, InizioSoggiorno, FineSoggiorno, Caparra, TariffaSoggiorno, TipologiaPrenotazione, IDCliente, IDCamera) VALUES(@DataPrenotazione, @AnnoPrenotazione, @InizioSoggiorno, @FineSoggiorno, @Caparra, @TariffaSoggiorno, @TipologiaPrenotazione, @IDCliente, @IDCamera)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@DataPrenotazione", p.DataPrenotazione);
                cmd.Parameters.AddWithValue("@AnnoPrenotazione", p.AnnoPrenotazione);
                cmd.Parameters.AddWithValue("@InizioSoggiorno", p.InizioSoggiorno);
                cmd.Parameters.AddWithValue("@FineSoggiorno", p.FineSoggiorno);
                cmd.Parameters.AddWithValue("@Caparra", p.Caparra);
                cmd.Parameters.AddWithValue("@TariffaSoggiorno", p.TariffaSoggiorno);
                cmd.Parameters.AddWithValue("@TipologiaPrenotazione", p.TipologiaPrenotazione);
                cmd.Parameters.AddWithValue("@IDCliente", p.IDCliente);
                cmd.Parameters.AddWithValue("@IDCamera", p.IDCamera);

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

            return RedirectToAction("Index");
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PrenotazioneByCF(string CodiceFiscale)
        {
            // Inizializza una lista di spedizioni
            List<Prenotazione> prenotazioni;

            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string sql = @"SELECT * Prenotazione AS P INNER JOIN Cliente AS C ON P.IDCliente = C.IDCliente WHERE CodiceFiscale = @CodiceFiscale ";


                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CodiceFiscale", CodiceFiscale);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                prenotazioni = new List<Prenotazione>();
                while (reader.Read())
                {
                    Prenotazione p = new Prenotazione();
                    p.IDPrenotazione = Convert.ToInt16(reader["IDPrenotazione"]);
                    p.DataPrenotazione = Convert.ToDateTime(reader["DataPrenotazione"]);
                    p.AnnoPrenotazione = Convert.ToInt16(reader["AnnoPrenotazione"]);
                    p.InizioSoggiorno = Convert.ToDateTime(reader["InizioSoggiorno"]);
                    p.FineSoggiorno = Convert.ToDateTime(reader["FineSoggiorno"]);
                    p.Caparra = Convert.ToDecimal(reader["Caparra"]);
                    p.TariffaSoggiorno = Convert.ToDecimal(reader["TariffaSoggiorno"]);
                    p.TipologiaPrenotazione = reader["TipologiaPrenotazione"].ToString();
                    p.IDCliente = Convert.ToInt16(reader["IDCliente"]);
                    p.IDCamera = Convert.ToInt16(reader["IDCamera"]);
                    prenotazioni.Add(p);
                }
            }
            return Json(prenotazioni, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult PrenotazioneByFB()
        {
            // Inizializza una lista di spedizioni
            List<Prenotazione> prenotazioni;

            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string sql = @"SELECT * FROM Prenotazione WHERE TipologiaPrenotazione = @TipologiaPrenotazione";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TipologiaPrenotazione", "FB");

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                prenotazioni = new List<Prenotazione>();
                while (reader.Read())
                {
                    Prenotazione p = new Prenotazione();
                    p.IDPrenotazione = Convert.ToInt16(reader["IDPrenotazione"]);
                    p.DataPrenotazione = Convert.ToDateTime(reader["DataPrenotazione"]);
                    p.AnnoPrenotazione = Convert.ToInt16(reader["AnnoPrenotazione"]);
                    p.InizioSoggiorno = Convert.ToDateTime(reader["InizioSoggiorno"]);
                    p.FineSoggiorno = Convert.ToDateTime(reader["FineSoggiorno"]);
                    p.Caparra = Convert.ToDecimal(reader["Caparra"]);
                    p.TariffaSoggiorno = Convert.ToDecimal(reader["TariffaSoggiorno"]);
                    p.TipologiaPrenotazione = reader["TipologiaPrenotazione"].ToString();
                    p.IDCliente = Convert.ToInt16(reader["IDCliente"]);
                    p.IDCamera = Convert.ToInt16(reader["IDCamera"]);
                    prenotazioni.Add(p);
                }
            }
            return Json(prenotazioni, JsonRequestBehavior.AllowGet);
        }
    }
}