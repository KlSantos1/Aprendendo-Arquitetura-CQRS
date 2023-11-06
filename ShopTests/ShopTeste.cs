using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;

namespace ShopTests
{
    public class CostumerIntegrationTest : IClassFixture<WebApplicationFactory<Shop.Startup>>
    {
        private readonly WebApplicationFactory<Shop.Startup> _factory;

        public CostumerIntegrationTest(WebApplicationFactory<Shop.Startup> factory)
        {
            _factory = factory;
        }

        [Fact(DisplayName = "Teste Fact Request/Response")]
        public async Task Criar_Cliente_Retorna_Cliente_Criado_Fact()
        {
            // Arrange
            var client = _factory.CreateClient();
            var request = new
            {
                name = "Kauã",
                email = "Kauã@gmail.com"
            };

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/v1/costumer", content);

            // Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var createdCostumer = JsonConvert.DeserializeObject<CostumerResponse>(responseContent);

            Assert.Equal("Kauã", createdCostumer.name);
            Assert.Equal("Kauã@gmail.com", createdCostumer.email);
            Assert.NotNull(createdCostumer.id);
            Assert.NotNull(createdCostumer.date);
        }

        public static IEnumerable<object[]> DadosRequests =>
        new List<object[]>
        {
            new object[] { "Kauã", "Kauã@gmail.com" },
            new object[] { "Cleiton", "Cleiton@gmail.com" },
            new object[] { "Murilo", "Murilo@gmail.com" }
        };

        [Theory(DisplayName = "Teste Theory Request/Response")]
        [MemberData(nameof(DadosRequests))]
        public async Task Criar_Cliente_Retorna_Cliente_Criado_Theory(string name, string email)
        {
            // Arrange
            var client = _factory.CreateClient();
            var request = new
            {
                name,
                email
            };

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/v1/costumer", content);

            // Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var createdCostumer = JsonConvert.DeserializeObject<CostumerResponse>(responseContent);

            Assert.Equal(name, createdCostumer.name);
            Assert.Equal(email, createdCostumer.email);
            Assert.NotNull(createdCostumer.id);
            Assert.NotNull(createdCostumer.date);
        }
    }

    public class CostumerResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public DateTime date { get; set; }
    }
}