using GestionaleHotel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GestionaleHotel.Controllers
{
    public class DipendenteController : Controller
    {
        // GET: Dipendente

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Dipendente d)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Dipendente WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("Username", d.Username);
                cmd.Parameters.AddWithValue("Password", d.Password);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    FormsAuthentication.SetAuthCookie(d.Username, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    conn.Close();
                    ViewBag.Error = "Autenticazione non riuscita, riprovare";
                    return View();

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

            return View();
        }
    }
}