using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Repos;
using MediatR;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Qerries
{
    public class GetAdvisorQueryHandler : IRequestHandler<GetAdvisorQuery, IEnumerable<Advisor>>
    {
        private readonly IAdvisorRepository _repository;

        public GetAdvisorQueryHandler(IAdvisorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Advisor>> Handle(GetAdvisorQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAdvisors();
        }
    }
}
