using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using MediatR;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Qerries
{
    public record GetAdvisorQuery() : IRequest<IEnumerable<Advisor>>;
}
