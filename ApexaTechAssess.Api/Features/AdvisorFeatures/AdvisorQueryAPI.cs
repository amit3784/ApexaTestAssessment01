using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Qerries;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Repos;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures
{
    /// <summary>
    /// This class is used as a placeholder for all query API.
    /// </summary>
    public class AdvisorQueryAPI : ICarterModule
    {
        /// <summary>
        /// Query API routes
        /// </summary>
        /// <param name="app"></param>
        [Produces("application/json")]
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            
            app.MapGet("api/Advisor/GetAll", async (ISender sender) =>
            {
                try
                {
                    var result = await sender.Send(new GetAdvisorQuery());
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex);
                }
            }).WithDisplayName("GetAllAdvisors")
            .WithOpenApi();


            
            app.MapGet("api/Advisor/GetById/{id:int}", async (int id,ISender sender) => {

                try
                {
                    GetAdvisorQueryById query=new GetAdvisorQueryById(id);
                    var result = await sender.Send(query);
                    if (result is not null)
                    {
                        return Results.Ok(result);
                    }
                    else
                        return Results.NotFound();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex);
                }
              
                    
            }).WithDisplayName("GetAdvisorById")
            .WithOpenApi();

            
        }
    }
}
