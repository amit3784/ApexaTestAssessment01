using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using MediatR;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Qerries
{
    /// <summary>
    /// This query is used to get a list of advisors from in-memory database.
    /// </summary>
    /// <return>
    ///     a list of advisors.
    /// </return>
    public record GetAdvisorQuery() : IRequest<IEnumerable<Advisor>>;
}
