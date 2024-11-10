using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using MediatR;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Qerries
{
    /// <summary>
    /// this query is used to get an advisor based on the unique id provided by client.
    /// </summary>
    /// <param name="id"></param>
    public record GetAdvisorQueryById(int id) : IRequest<Advisor>;
    

    
}