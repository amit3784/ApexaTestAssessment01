using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ApexaTechAssess.Api;
using ApexaTechAssess.Api.Features.AdvisorFeatures;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Qerries;
using ApexaTechAssessment.Test.TestHelpers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ApexaTechAssessment.Test.QueryTest
{

    public class GetAdvisorQueryTests
    {
        
        private async Task<HttpResponseMessage?> GetAdvisors(string url)
        {
            using (HttpClient _httpClient = new() { BaseAddress = new Uri("https://localhost:7179") })
            {
                
                CancellationTokenSource cts = new CancellationTokenSource();
                CancellationToken cancellationToken = cts.Token;

                var response = await _httpClient.GetAsync(url, cancellationToken);

                return response;

            }

        }
        private async Task<HttpResponseMessage?> GetAdvisorById(string url,int id)
        {
            using (HttpClient _httpClient = new() { BaseAddress = new Uri("https://localhost:7179") })
            {

                CancellationTokenSource cts = new CancellationTokenSource();
                CancellationToken cancellationToken = cts.Token;
                var correctedUrl = url + "/" + id;

                var response = await _httpClient.GetAsync(correctedUrl,cancellationToken);

                return response;

            }

        }

        [Fact]
        public async Task GetAllAdvisors_Response_ShouldReturnJsonResultType()
        {
            //Arrange
            string _jsonMediaType = "application/json";

            //Act
            var response = await GetAdvisors("api/Advisor/GetAll");
            //Assert
            Assert.Equal(_jsonMediaType, response.Content.Headers.ContentType?.MediaType);


        }

        [Fact]
        public async Task GetAllAdvisors_Response_ShouldReturnStatusCodeOk()
        {
            //Arrange
            var expectedStatusCode = System.Net.HttpStatusCode.OK;
            
            //Act 
             var response=await GetAdvisors("api/Advisor/GetAll");
            
            //Assert
            Assert.Equal(expectedStatusCode, response?.StatusCode);


        }

        

        [Fact]
        public async Task GetAllAdvisors_Response_ShouldReturn_ContentAsListofSerializableAdvisors()
        {
            //Arrange 

            //Act
            var response = await GetAdvisors("api/Advisor/GetAll");
            var result = await response.Content.ReadAsStringAsync();
            var serializedExpectedResult = JsonSerializer.Deserialize<List<SearializableAdvisor>>(result);

            //Assert
            Assert.IsType<List<SearializableAdvisor>>(serializedExpectedResult);
            


        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(100)]
        [InlineData(200)]
        public async Task GetAdvisorById_Response_ShouldReturnCorrectStatusCode(int id)
        {
            
            //Arrange
            var okStatusCode = System.Net.HttpStatusCode.OK;
            var notFoundStatusCode=System.Net.HttpStatusCode.NotFound;
            
            //Act 
            var response = await GetAdvisorById("api/Advisor/GetById",id);

            if (response?.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //Assert
                Assert.Equal(okStatusCode, response?.StatusCode);
            }
            else if (response?.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                //Assert
                Assert.Equal(notFoundStatusCode, response?.StatusCode);
            }
           


        }



        [Theory]
        [InlineData(3)]
        public async Task GetAdvisorById_Response_ShouldReturn_ContentAsListofSerializableAdvisors(int id)
        {
            //Arrange 
            
            //Act 
            var response = await GetAdvisorById("api/Advisor/GetById",id );
            var result = await response.Content.ReadAsStringAsync();
            var serializedExpectedResult = JsonSerializer.Deserialize<SearializableAdvisor>(result);

            //Assert
            Assert.IsType<SearializableAdvisor>(serializedExpectedResult);



        }
        
        





    }

}
