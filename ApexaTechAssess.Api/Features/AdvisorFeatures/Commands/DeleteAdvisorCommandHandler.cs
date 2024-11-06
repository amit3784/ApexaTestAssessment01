using ApexaTechAssess.Api.Features.AdvisorFeatures.Repos;
using MediatR;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Commands
{
    public class DeleteAdvisorCommandHandler : IRequestHandler<DeleteAdvisorCommand>
    {
        private readonly IAdvisorRepository _repository;

        public DeleteAdvisorCommandHandler(IAdvisorRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteAdvisorCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAdvisor(request.id);
        }
    }
}
