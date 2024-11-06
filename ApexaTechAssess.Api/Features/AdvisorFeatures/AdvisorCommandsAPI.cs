using ApexaTechAssess.Api.Features.AdvisorFeatures.Commands;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Validations;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures
{
    public class AdvisorCommandsAPI : ICarterModule
    {
        

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            
            ////Create Advisor 
            app.MapPost("api/Advisor/Create", async (ISender sender,[FromBody]CreateAdvisorCommand cmd) =>
            {
                CreateAdvisorCommandValidator _createAdvisorValidator = new CreateAdvisorCommandValidator();
                var validationResult= _createAdvisorValidator.Validate(cmd);
                if (validationResult.IsValid)
                {
                    var result = await sender.Send(cmd);
                    return Results.Ok(result);
                }
                else
                {
                    return Results.BadRequest(validationResult);
                }
                
            }).WithDisplayName("CreateAdvisor")
            .WithOpenApi();

            ////Update Advisor 
            app.MapPut("api/Advisor/Update", async (ISender sender,[FromBody] UpdateAdvisorCommand cmd) =>
            {
                UpdateAdvisorCommandValidator _updateAdvisorValidator = new UpdateAdvisorCommandValidator();
                var validationResults= _updateAdvisorValidator.Validate(cmd);
                if (validationResults.IsValid)
                {
                    var result = await sender.Send(cmd);
                    return Results.Ok(result);
                }
                else
                {
                    return Results.BadRequest(validationResults);
                }
                
            }).WithDisplayName("UpdateAdvisorDetails")
            .WithOpenApi();

            ////Delete Advisor 
            app.MapDelete("api/Advisor/Delete", async (ISender sender, [FromBody] DeleteAdvisorCommand cmd) =>
            {
                 await sender.Send(cmd);
                
            }).WithDisplayName("DeleteAdvisor")
            .WithOpenApi();
        }
    }
}
