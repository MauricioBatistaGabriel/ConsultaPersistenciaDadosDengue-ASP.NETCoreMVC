using Microsoft.AspNetCore.Mvc;

namespace ConsultaPersistenciaDadosDengue.Controllers.Implements
{
    public interface IDadosDengueController
    {
        Task<IActionResult> Index();
        Task<IActionResult> AtualizaDadosDengue();
    }
}
