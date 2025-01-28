using ConsultaPersistenciaDadosDengue.Models;

namespace ConsultaPersistenciaDadosDengue.Services.Interface
{
    public interface IDadosDengueService
    {
        Task AtualizaDadosDengue();
        Task<List<DadosDengueModel>> ObtemDadosDengue();
    }
}
