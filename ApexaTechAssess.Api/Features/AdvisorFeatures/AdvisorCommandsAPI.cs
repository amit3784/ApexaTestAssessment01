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
    /// <summary>
    /// This class is used as a placeholder for all command API such as Post, put or delete
    /// </summary>
    public class AdvisorCommandsAPI : ICarterModule
    {
        
        /// <summary>
        /// Command routes
        /// </summary>
        /// <param name="app"></param>
        public void AddRoutes(IEndpointRouteBuilder app)
        {

          
            app.MapPost("api/Advisor/Create", async (ISender sender,[FromBody]CreateAdvisorCommand cmd) =>
            {
                CreateAdvisorCommandValidator _createAdvisorValidator = new CreateAdvisorCommandValidator();
                var validationResult= _createAdvisorValidator.Validate(cmd);
                if (validationResult.IsValid)
                {
                    try
                    {
                        var result = await sender.Send(cmd);
                        return Results.Ok(result);
                    }
                    catch (Exception ex) {
                        return Results.BadRequest(ex);
                    }
                }
                else
                {
                    return Results.BadRequest(validationResult);
                }
                
            }).WithDisplayName("CreateAdvisor")
            .WithOpenApi();

            
            app.MapPut("api/Advisor/Update", async (ISender sender,[FromBody] UpdateAdvisorCommand cmd) =>
            {
                UpdateAdvisorCommandValidator _updateAdvisorValidator = new UpdateAdvisorCommandValidator();
                var validationResults= _updateAdvisorValidator.Validate(cmd);
                if (validationResults.IsValid)
                {
                    try
                    {
                        var result = await sender.Send(cmd);
                        return Results.Ok(result);
                    }
                    catch(Exception ex) {
                        return Results.BadRequest(ex);
                    }
                }
                else
                {
                    return Results.BadRequest(validationResults);
                }
                
            }).WithDisplayName("UpdateAdvisorDetails")
            .WithOpenApi();

            
            app.MapDelete("api/Advisor/Delete/{id:int}", async (int id,ISender sender) =>
            {
                try
                {
                    DeleteAdvisorCommand cmd = new DeleteAdvisorCommand(id);
                    await sender.Send(cmd);
                    return Results.NoContent();
                }
                catch(Exception ex) {
                    return Results.BadRequest(ex);
                }
                
            }).WithDisplayName("DeleteAdvisor")
            .WithOpenApi();
        }
    }
}
