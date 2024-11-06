using MediatR;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Commands
{
    public record DeleteAdvisorCommand(int id):IRequest;
    
    
}
