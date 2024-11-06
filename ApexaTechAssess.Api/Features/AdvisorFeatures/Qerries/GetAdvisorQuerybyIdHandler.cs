using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Repos;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Qerries
{
    public class GetAdvisorQuerybyIdHandler : IRequestHandler<GetAdvisorQueryById, Advisor>
    {
        private readonly IAdvisorRepository advisorRepository;

        public GetAdvisorQuerybyIdHandler(IAdvisorRepository advisorRepository)
        {
            this.advisorRepository = advisorRepository;
        }

        public async Task<Advisor> Handle(GetAdvisorQueryById request, CancellationToken cancellationToken)
        {
            var result = await advisorRepository.GetAdvisorByIdAsync(request.id);
            if (result is not null)
            {
                return result;
            }
            else
                return result;
        }
    }
}
