using MediatR;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Commands
{
    /// <summary>
    /// This command is responsible to delete the advisor from in-memory database.
    /// </summary>
    public record DeleteAdvisorCommand(int id):IRequest;
    
    
}
