using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Repos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Commands
{
    /// <summary>
    /// This command handler is responsible to handle CreateAdvisorCommand request.
    /// </summary>
    public class CreateAdvisorCommandHandler : IRequestHandler<CreateAdvisorCommand, Advisor>
    {
        private readonly IAdvisorRepository _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public CreateAdvisorCommandHandler(IAdvisorRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Create advisor command handler method
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
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
