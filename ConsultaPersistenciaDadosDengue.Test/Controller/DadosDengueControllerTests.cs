using ConsultaPersistenciaDadosDengue.Controllers;
using ConsultaPersistenciaDadosDengue.Controllers.Interfaces;
using ConsultaPersistenciaDadosDengue.Models;
using ConsultaPersistenciaDadosDengue.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ConsultaPersistenciaDadosDengue.Tests.Controllers
{
    public class DadosDengueControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewResult_WithListOfDadosDengueModel()
        {
            // Arrange
            var mockService = new Mock<IDadosDengueService>();
            var expectedData = new List<DadosDengueModel>
            {
                new DadosDengueModel { id = 1, casos = 71, casos_est = 1208.5, nivel = 3, se = 202503 }
            };
            mockService.Setup(service => service.ObtemDadosDengue()).ReturnsAsync(expectedData);
            var controller = new DadosDengueController(mockService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<DadosDengueModel>>(viewResult.ViewData.Model);
            Assert.Equal(expectedData, model);
        }

        [Fact]
        public async Task AtualizaDadosDengue_ReturnsRedirectToActionResult()
        {
            // Arrange
            var mockService = new Mock<IDadosDengueService>();
            mockService.Setup(service => service.AtualizaDadosDengue()).Returns(Task.CompletedTask);
            var controller = new DadosDengueController(mockService.Object);

            // Act
            var result = await controller.AtualizaDadosDengue();

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
        }
    }
}
