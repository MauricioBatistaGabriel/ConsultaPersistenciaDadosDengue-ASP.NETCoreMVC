using System.Diagnostics;
using ConsultaPersistenciaDadosDengue.Controllers.Implements;
using ConsultaPersistenciaDadosDengue.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaPersistenciaDadosDengue.Controllers.Interfaces
{
    public class HomeController : Controller, IHomeController
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
