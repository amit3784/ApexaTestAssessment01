using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Repos;
using MediatR;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Commands
{
    
    public class UpdateAdvisorCommandHandler : IRequestHandler<UpdateAdvisorCommand, Advisor>
    {
        private readonly IAdvisorRepository advisorRepository;

        public UpdateAdvisorCommandHandler(IAdvisorRepository advisorRepository)
        {
            this.advisorRepository = advisorRepository;
        }

        public async Task<Advisor> Handle(UpdateAdvisorCommand request, CancellationToken cancellationToken)
        {
            Advisor advisor = new Advisor()
            {
                Id = request.Id,
                SIN = request.SIN,
                FullName = request.FullName,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber
            };
            var result = await advisorRepository.UpdateAdvisor(advisor);
            return result;
        }
    }
}
