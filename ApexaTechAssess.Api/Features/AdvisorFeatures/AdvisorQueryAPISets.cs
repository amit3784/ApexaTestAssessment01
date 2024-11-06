using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Qerries;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Repos;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures
{
    public class AdvisorQueryAPISets : ICarterModule
    {
       

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            //Get All Advisors
            app.MapGet("api/Advisor/GetAll", async (ISender sender) =>
            {
                var result = await sender.Send(new GetAdvisorQuery());
                return result;
            }).WithDisplayName("GetAllAdvisors")
            .WithOpenApi();
            

            //Get Advisor by Id
            app.MapPost("api/Advisor/GetById", async (ISender sender,[FromBody]GetAdvisorQueryById query) => {
               var result= await sender.Send(query);
                return result;
            }).WithDisplayName("GetAdvisorById")
            .WithOpenApi();

            
        }
    }
}
