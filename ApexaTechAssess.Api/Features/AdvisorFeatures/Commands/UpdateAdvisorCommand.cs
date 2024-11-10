using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using MediatR;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Commands
{
    /// <summary>
    /// This command is responsible to update the advisor information to in-memory database.
    /// </summary>
    public record UpdateAdvisorCommand:IRequest<Advisor>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; init; }
        /// <summary>
        /// Full Name
        /// </summary>
        public required string FullName { get; init; }

        /// <summary>
        /// SIN Number
        /// </summary>
        public required string SIN { get; init; }

        /// <summary>
        /// Address 
        /// </summary>
        public string Address { get; init; } = string.Empty;

        /// <summary>
        /// Phone Number
        /// </summary>
        public string PhoneNumber { get; init; } = string.Empty;
    }
}
