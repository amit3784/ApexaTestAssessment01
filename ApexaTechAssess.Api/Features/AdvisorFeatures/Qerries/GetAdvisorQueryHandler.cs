using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Repos;
using MediatR;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Qerries
{
    /// <summary>
    /// This command is used to handle GetAdvisorQuery request and returns a list of advisors.
    /// </summary>
    public class GetAdvisorQueryHandler : IRequestHandler<GetAdvisorQuery, IEnumerable<Advisor>>
    {
        private readonly IAdvisorRepository _repository;

        /// <summary>
        /// Initialize the handler
        /// </summary>
        /// <param name="repository"></param>
        public GetAdvisorQueryHandler(IAdvisorRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Get advisor query handler method.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Advisor>> Handle(GetAdvisorQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAdvisors();
        }
    }
}
