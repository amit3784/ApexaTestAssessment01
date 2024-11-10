using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Repos;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Qerries
{
    /// <summary>
    /// this handler is used to handle the GetAdvisorQueryHandlerById request.
    /// </summary>
    public class GetAdvisorQuerybyIdHandler : IRequestHandler<GetAdvisorQueryById, Advisor?>
    {
        private readonly IAdvisorRepository advisorRepository;

        /// <summary>
        /// Initialize the handler
        /// </summary>
        /// <param name="advisorRepository"></param>
        public GetAdvisorQuerybyIdHandler(IAdvisorRepository advisorRepository)
        {
            this.advisorRepository = advisorRepository;
        }

        /// <summary>
        /// Get advisor query by id handler method.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Advisor?> Handle(GetAdvisorQueryById request, CancellationToken cancellationToken)
        {
            var result = await advisorRepository.GetAdvisorByIdAsync(request.id);
            return result;
        }
    }
}
