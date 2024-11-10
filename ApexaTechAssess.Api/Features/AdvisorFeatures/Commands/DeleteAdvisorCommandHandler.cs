using ApexaTechAssess.Api.Features.AdvisorFeatures.Repos;
using MediatR;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Commands
{
    /// <summary>
    /// This handler is responsible to handle deleteadvisorcommand request.
    /// </summary>
    public class DeleteAdvisorCommandHandler : IRequestHandler<DeleteAdvisorCommand>
    {
        private readonly IAdvisorRepository _repository;

        /// <summary>
        /// Constructor for delete advisor command
        /// </summary>
        /// <param name="repository"></param>
        public DeleteAdvisorCommandHandler(IAdvisorRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Handler method for delete advisor command
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(DeleteAdvisorCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAdvisor(request.id);
        }
    }
}
