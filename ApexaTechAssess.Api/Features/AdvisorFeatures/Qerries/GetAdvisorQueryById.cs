using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using MediatR;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Qerries
{
    public record GetAdvisorQueryById(int id) : IRequest<Advisor>
    {

    }
}