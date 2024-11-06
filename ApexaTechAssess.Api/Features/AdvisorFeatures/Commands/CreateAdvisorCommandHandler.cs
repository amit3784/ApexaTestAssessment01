using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Repos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Commands
{
    public class CreateAdvisorCommandHandler : IRequestHandler<CreateAdvisorCommand, Advisor>
    {
        private readonly IAdvisorRepository _repository;

        public CreateAdvisorCommandHandler(IAdvisorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Advisor> Handle(CreateAdvisorCommand request, CancellationToken cancellationToken)
        {
            Advisor advisor = new Advisor()
            {
                SIN = request.SIN,
                FullName = request.FullName,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber
            };
            var result =await _repository.CreateAdvisor(advisor);
            return result;
        }
    }
}
