using ConsultaPersistenciaDadosDengue.Controllers.Implements;
using ConsultaPersistenciaDadosDengue.Models;
using ConsultaPersistenciaDadosDengue.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaPersistenciaDadosDengue.Controllers.Interfaces
{
    public class DadosDengueController : Controller, IDadosDengueController
    {
        private readonly IDadosDengueService _dadosDengueService;

        public DadosDengueController(IDadosDengueService dadosDengueService)
        {
            _dadosDengueService = dadosDengueService;
        }

        public async Task<IActionResult> Index()
        {
            List<DadosDengueModel> data = await _dadosDengueService.ObtemDadosDengue();

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizaDadosDengue()
        {
            await _dadosDengueService.AtualizaDadosDengue();
            return RedirectToAction("Index");
        }
    }
}
