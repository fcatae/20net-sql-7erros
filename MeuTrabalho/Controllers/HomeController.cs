using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeuTrabalho.Models;
using System.Data.SqlClient;
using MeuTrabalho.Repositories;

namespace MeuTrabalho.Controllers
{
    public class HomeController : Controller, IDisposable
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return RedirectToActionPermanent("Index", "Account");
        }

        public IActionResult Dashboard(string name)
        {
            if( name == null )
            {
                throw new ArgumentNullException(name);
            }

            ViewBag.Name = name;
            return View();
        }

        public IActionResult About([FromQuery]string teste = "")
        {
            using (SqlConnection connection = new SqlConnection("Server=.;Database=sql20;Integrated Security=SSPI;Connection Timeout=3;Max Pool Size=5"))
            {
                connection.Open();
                LogRepository logRepository = new LogRepository(connection);

                if (teste == "")
                {
                    teste = logRepository.TotalRegistros().ToString();
                }

                ViewData["Message"] = "Total de acessos: " + teste;

                SqlCommand sql = new SqlCommand("INSERT tbLog VALUES ('about')", connection);
                var retorno = sql.ExecuteReader();

                if (retorno == null)
                {
                    return RedirectToAction("RETORNO NULO");
                }

                return View();
            }
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            using (SqlConnection connection = new SqlConnection("Server=.;Database=sql20;Integrated Security=SSPI;Connection Timeout=3;Max Pool Size=5"))
            {
                connection.Open();

                SqlConnection conn1 = connection;

                SqlCommand sql = new SqlCommand("INSERT tbLog VALUES ('contact')");
                sql.Connection = conn1;

                sql.ExecuteScalar();

                return View();
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
