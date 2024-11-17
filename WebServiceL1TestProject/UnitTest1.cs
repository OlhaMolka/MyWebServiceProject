using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace WebServiceL1
{
    public class ControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ControllerTests(WebApplicationFactory<Program> factory)
        {
            // Створюємо клієнт для тестування API
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Test_HelloWorld_ReturnsOkAndHelloMessage()
        {
            // Arrange
            var url = "/api/helloworld?name=World"; // Шлях до API методу

            // Act
            var response = await _client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Перевірка, що код відповіді 200 OK
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("Hello, World", responseString); // Перевірка, що відповідь правильна
        }
    }
}
