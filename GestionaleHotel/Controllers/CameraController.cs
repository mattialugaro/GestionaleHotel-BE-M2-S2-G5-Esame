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
    public class CameraController : Controller
    {
        // GET: Camera
        public ActionResult Index()
        {
            List<Camera> listaCamere = new List<Camera>();
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Camera";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Camera cm = new Camera();
                    cm.NumeroCamera = Convert.ToInt16(reader["NumeroCamera"]);
                    cm.Descrizione = reader["Descrizione"].ToString();
                    cm.Tipologia = reader["Tipologia"].ToString();
                    listaCamere.Add(cm);
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

            return View(listaCamere);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Camera cm)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "INSERT INTO Camera(NumeroCamera, Descrizione, Tipologia) VALUES(@NumeroCamera, @Descrizione, @Tipologia)";


                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@NumeroCamera", cm.NumeroCamera);
                cmd.Parameters.AddWithValue("@Descrizione", cm.Descrizione ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Tipologia", cm.Tipologia);

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