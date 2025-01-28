using System.Net;
using ConsultaPersistenciaDadosDengue.Data;
using ConsultaPersistenciaDadosDengue.Models;
using ConsultaPersistenciaDadosDengue.Services.Implement;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;

namespace ConsultaPersistenciaDadosDengue.Tests.Services
{
    public class DadosDengueServiceTests
    {
        [Fact]
        public async Task ObtemDadosDengue_ReturnsListOfDadosDengueModel()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DadosDengueContext>()
                .UseInMemoryDatabase(databaseName: "DadosDengueDatabase")
                .Options;

            using var context = new DadosDengueContext(options);
            context.DadosDengue.Add(new DadosDengueModel { casos = 71, casos_est = 1208.5, nivel = 3, se = 202503 });
            context.SaveChanges();

            var service = new DadosDengueService(new HttpClient(), context);

            // Act
            var result = await service.ObtemDadosDengue();

            // Assert
            Assert.Single(result);
            var resultItem = result.First();
            Assert.Equal(1, resultItem.id);
            Assert.Equal(71, resultItem.casos);
            Assert.Equal(1208.5, resultItem.casos_est);
            Assert.Equal(3, resultItem.nivel);
            Assert.Equal(202503, resultItem.se);
        }

        [Fact]
        public async Task AtualizaDadosDengue_RemovesAndAddsData()
        {
            // Arrange
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            var expectedData = new List<DadosDengueModel>
            {
                new DadosDengueModel { id = 1, casos = 71, casos_est = 1208.5, nivel = 3, se = 202503 }
            };

            var responseContent = new StringContent(JsonConvert.SerializeObject(expectedData));
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = responseContent
            };

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(httpResponseMessage);

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);

            var options = new DbContextOptionsBuilder<DadosDengueContext>()
                .UseInMemoryDatabase(databaseName: "DadosDengueDatabase")
                .Options;

            using var context = new DadosDengueContext(options);
            var service = new DadosDengueService(httpClient, context);

            // Act
            await service.AtualizaDadosDengue();

            // Assert
            var result = await context.DadosDengue.ToListAsync();
            Assert.Single(result);
            var resultItem = result.First();
            Assert.Equal(1, resultItem.id);
            Assert.Equal(71, resultItem.casos);
            Assert.Equal(1208.5, resultItem.casos_est);
            Assert.Equal(3, resultItem.nivel);
            Assert.Equal(202503, resultItem.se);
        }
    }
}
