using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using MediatR;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Commands
{
    public record CreateAdvisorCommand:IRequest<Advisor>
    {
        public required string FullName { get; init ; }


        public required string SIN { get; init; }


        public string Address { get; init; } = string.Empty;

        public string PhoneNumber { get; init; } = string.Empty;
    }

    
}
