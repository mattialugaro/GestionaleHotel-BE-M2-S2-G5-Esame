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
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<Cliente> listaClienti = new List<Cliente>();
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Cliente";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cliente c = new Cliente();
                    c.Nome = reader["Nome"].ToString();
                    c.Cognome = reader["Cognome"].ToString();
                    c.Citta = reader["Citta"].ToString();
                    c.Provincia = reader["Provincia"].ToString();
                    c.Email = reader["Email"].ToString();
                    c.CodiceFiscale = reader["CodiceFiscale"].ToString();
                    c.Telefono = reader["Telefono"].ToString();
                    c.Cellulare = reader["Cellulare"].ToString();
                    listaClienti.Add(c);
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

            return View(listaClienti);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente c)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "INSERT INTO Cliente(Nome, Cognome, Email, Provincia, Citta, CodiceFiscale, Telefono, Cellulare) VALUES(@Nome, @Cognome, @Email, @Provincia, @Citta, @CodiceFiscale, @Telefono, @Cellulare)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nome", c.Nome);
                cmd.Parameters.AddWithValue("@Cognome", c.Cognome);
                cmd.Parameters.AddWithValue("@Email", c.Email);
                cmd.Parameters.AddWithValue("@Provincia", c.Provincia);
                cmd.Parameters.AddWithValue("@Citta", c.Citta);
                cmd.Parameters.AddWithValue("@CodiceFiscale", c.CodiceFiscale);
                cmd.Parameters.AddWithValue("@Telefono", c.Telefono ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Cellulare", c.Cellulare);

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
    }
}