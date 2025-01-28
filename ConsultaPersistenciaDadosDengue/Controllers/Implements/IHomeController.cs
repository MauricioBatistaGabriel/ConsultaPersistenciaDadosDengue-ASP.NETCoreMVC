using Microsoft.AspNetCore.Mvc;

namespace ConsultaPersistenciaDadosDengue.Controllers.Implements
{
    public interface IHomeController
    {
        IActionResult Index();
        IActionResult Error();
    }
}
