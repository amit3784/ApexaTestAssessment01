using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Repos;
using MediatR;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Commands
{
    /// <summary>
    /// This command is responsible to handle the updateadvisorcommand request.
    /// </summary>
    public class UpdateAdvisorCommandHandler : IRequestHandler<UpdateAdvisorCommand, Advisor>
    {
        private readonly IAdvisorRepository advisorRepository;

        /// <summary>
        /// Initialize command handler
        /// </summary>
        /// <param name="advisorRepository"></param>
        public UpdateAdvisorCommandHandler(IAdvisorRepository advisorRepository)
        {
            this.advisorRepository = advisorRepository;
        }

        /// <summary>
        /// Handler method
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
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
