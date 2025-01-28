using System.Globalization;
using ConsultaPersistenciaDadosDengue.Data;
using ConsultaPersistenciaDadosDengue.Models;
using ConsultaPersistenciaDadosDengue.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ConsultaPersistenciaDadosDengue.Services.Implement
{
    public class DadosDengueService : IDadosDengueService
    {
        private readonly HttpClient _httpClient;
        private readonly DadosDengueContext _dadosDengueContext;

        public DadosDengueService(HttpClient httpClient, DadosDengueContext dadosDengueContext)
        {
            _httpClient = httpClient;
            _dadosDengueContext = dadosDengueContext;
        }

        public async Task AtualizaDadosDengue()
        {
            _dadosDengueContext.RemoveRange(_dadosDengueContext.DadosDengue);
            _dadosDengueContext.SaveChanges();

            CultureInfo ci = CultureInfo.CurrentCulture;
            Calendar calendar = ci.Calendar;
            CalendarWeekRule weekRule = ci.DateTimeFormat.CalendarWeekRule;
            DayOfWeek firstDayOfWeek = ci.DateTimeFormat.FirstDayOfWeek;

            int semanaAtual = calendar.GetWeekOfYear(DateTime.Today, weekRule, firstDayOfWeek);
            int anoAtual = DateTime.Now.Year;

            int semanaInicial = calendar.GetWeekOfYear(DateTime.Today.AddMonths(-6), weekRule, firstDayOfWeek);
            int anoInicial = calendar.GetYear(DateTime.Today.AddMonths(-6));

            string api = $"https://info.dengue.mat.br/api/alertcity?geocode=3106200&disease=dengue&format=json&ew_start={semanaInicial}&ew_end={semanaAtual}&ey_start={anoInicial}&ey_end={anoAtual}";
            var response = await _httpClient.GetAsync(api);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Status de requisição: {response.StatusCode}");
            }

            var content = response.Content.ReadAsStringAsync().Result;

            if (content == null)
            {
                throw new Exception("o conteúdo é nulo");
            }

            List<DadosDengueModel>? data = JsonConvert.DeserializeObject<List<DadosDengueModel>>(content);

            if (data == null)
            {
                throw new Exception("Erro ao deserializar o conteúdo");
            }

            _dadosDengueContext.DadosDengue.AddRange(data);
            _dadosDengueContext.SaveChanges();
        }

        public async Task<List<DadosDengueModel>> ObtemDadosDengue()
        {
            return await _dadosDengueContext.DadosDengue
                .OrderByDescending(d => d.id)
                .ToListAsync();
        }
    }
}
