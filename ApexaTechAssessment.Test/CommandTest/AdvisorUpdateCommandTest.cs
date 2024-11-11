using ApexaTechAssess.Api.Features.AdvisorFeatures.Commands;
using ApexaTechAssessment.Test.TestHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApexaTechAssessment.Test.CommandTest
{
    public class AdvisorUpdateCommandTest
    {
        private async Task<HttpResponseMessage?> PostHttpUpdateCommand(string url, UpdateAdvisorCommand cmd)
        {
            using (HttpClient _httpClient = new() { BaseAddress = new Uri("https://localhost:7179") })
            {

                CancellationTokenSource cts = new CancellationTokenSource();
                CancellationToken cancellationToken = cts.Token;
                var json = System.Text.Json.JsonSerializer.Serialize(cmd);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(url, content, cancellationToken);

                return response;

            }

        }

        [Fact]
        public async Task UpdateAdvisor_Response_ShouldReturnJsonResultType()
        {
            //Arrange
            string _jsonMediaType = "application/json";
            UpdateAdvisorCommand cmd = new UpdateAdvisorCommand()
            {
                Id = 1,
                FullName = "test3",
                SIN = "123456789",
                Address = "test",
                PhoneNumber = "1234567890"
            };
            //Act
            var response = await PostHttpUpdateCommand("api/Advisor/Update", cmd);

            //Assert
            Assert.Equal(_jsonMediaType, response.Content.Headers.ContentType?.MediaType);


        }

        [Fact]
        public async Task UpdateAdvisor_Response_ShouldReturnStatusCodeOk()
        {
            //Arrange
            var expectedStatusCode = System.Net.HttpStatusCode.OK;
            UpdateAdvisorCommand cmd = new UpdateAdvisorCommand()
            {
                Id = 1,
                FullName = "test3",
                SIN = "123456789",
                Address = "test",
                PhoneNumber = "1234567890"
            };
            //Act
            var response = await PostHttpUpdateCommand("api/Advisor/Update", cmd);


            //Assert
            Assert.Equal(expectedStatusCode, response?.StatusCode);


        }



        [Fact]
        public async Task UpdateAdvisor_Response_ShouldReturn_ContentAsSerializableAdvisor()
        {
            //Arrange 


            UpdateAdvisorCommand cmd = new UpdateAdvisorCommand()
            {
                Id = 1,
                FullName = "test3",
                SIN = "123456789",
                Address = "test",
                PhoneNumber = "1234567890"
            };

            //Act
            var response = await PostHttpUpdateCommand("api/Advisor/Update", cmd);
            var result = await response.Content.ReadAsStringAsync();
            var serializedExpectedResult = JsonSerializer.Deserialize<SearializableAdvisor>(result);

            //Assert
            Assert.IsType<SearializableAdvisor>(serializedExpectedResult);



        }
    }
}
