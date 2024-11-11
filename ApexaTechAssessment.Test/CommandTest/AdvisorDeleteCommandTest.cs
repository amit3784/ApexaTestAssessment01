using ApexaTechAssess.Api.Features.AdvisorFeatures.Commands;
using ApexaTechAssessment.Test.TestHelpers;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApexaTechAssessment.Test.CommandTest
{
    public class AdvisorDeleteCommandTest
    {
        private async Task<HttpResponseMessage?> DeleteHttpCommand(string url, int id)
        {
            using (HttpClient _httpClient = new() { BaseAddress = new Uri("https://localhost:7179") })
            {

                CancellationTokenSource cts = new CancellationTokenSource();
                CancellationToken cancellationToken = cts.Token;
                
                string correctUrl=url+"/"+id;
                var response = await _httpClient.DeleteAsync(correctUrl,cancellationToken);

                return response;

            }

        }

       
        

       



        [Fact]
        public async Task DeleteAdvisor_Response_ShouldReturn_NoContentPostDeletion()
        {
            //Arrange 

            var expectedResponse=System.Net.HttpStatusCode.NoContent;
            int id = 2;

            //Act
            var response = await DeleteHttpCommand("api/Advisor/Delete", id);
            
            //Assert
            Assert.Equal(expectedResponse,response?.StatusCode);



        }
    }
}
