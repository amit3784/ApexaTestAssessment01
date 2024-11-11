using ApexaTechAssess.Api.Features.AdvisorFeatures.Commands;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Qerries;
using ApexaTechAssessment.Test.TestHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApexaTechAssessment.Test.CommandTest
{
    public class AdvisorCreateCommandTests
    {
        private async Task<HttpResponseMessage?> PostHttpCreateCommand(string url, CreateAdvisorCommand cmd)
        {
            using (HttpClient _httpClient = new() { BaseAddress = new Uri("https://localhost:7179") })
            {

                CancellationTokenSource cts = new CancellationTokenSource();
                CancellationToken cancellationToken = cts.Token;
                var json = System.Text.Json.JsonSerializer.Serialize(cmd);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content, cancellationToken);

                return response;

            }

        }

        [Fact]
        public async Task CreateAdvisor_Response_ShouldReturnJsonResultType()
        {
            //Arrange
            string _jsonMediaType = "application/json";
            CreateAdvisorCommand cmd=new CreateAdvisorCommand() 
            { 
                FullName = "test3" ,
                SIN="123456789",
                Address="test",
                PhoneNumber="1234567890"
            };
            //Act
            var response = await PostHttpCreateCommand("api/Advisor/Create",cmd);

            //Assert
            Assert.Equal(_jsonMediaType, response.Content.Headers.ContentType?.MediaType);


        }

        [Fact]
        public async Task CreateAdvisor_Response_ShouldReturnStatusCodeOk()
        {
            //Arrange
            var expectedStatusCode = System.Net.HttpStatusCode.OK;
            CreateAdvisorCommand cmd = new CreateAdvisorCommand()
            {
                FullName = "test3",
                SIN = "123456789",
                Address = "test",
                PhoneNumber = "1234567890"
            };
            //Act
            var response = await PostHttpCreateCommand("api/Advisor/Create", cmd);
            

            //Assert
            Assert.Equal(expectedStatusCode, response?.StatusCode);


        }



        [Fact]
        public async Task CreateAdvisor_Response_ShouldReturn_ContentAsSerializableAdvisor()
        {
            //Arrange 

            
            CreateAdvisorCommand cmd = new CreateAdvisorCommand()
            {
                FullName = "test3",
                SIN = "123456789",
                Address = "test",
                PhoneNumber = "1234567890"
            };
            
            //Act
            var response = await PostHttpCreateCommand("api/Advisor/Create", cmd);
            var result = await response.Content.ReadAsStringAsync();
            var serializedExpectedResult = JsonSerializer.Deserialize<SearializableAdvisor>(result);

            //Assert
            Assert.IsType<SearializableAdvisor>(serializedExpectedResult);



        }
    }
}
