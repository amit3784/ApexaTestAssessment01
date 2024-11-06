using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using MediatR;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Commands
{
    public record UpdateAdvisorCommand:IRequest<Advisor>
    {
        public int Id { get; init; }
        public required string FullName { get; init; }


        public required string SIN { get; init; }


        public string Address { get; init; } = string.Empty;

        public string PhoneNumber { get; init; } = string.Empty;
    }
}
