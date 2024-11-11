using ApexaTechAssess.Api.Helper;
using ApexaTechAssess.Api.Helper.Extensions;
using System.ComponentModel.DataAnnotations;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Domain
{
    /// <summary>
    /// This class is responsible to hold advisor related information.
    /// </summary>
    public class Advisor
    {
        /// <summary>
        /// Id - unique id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Full Name
        /// </summary>
        public required string FullName { get; set; }

        
        private string _sin="000000000";

        /// <summary>
        /// SIN Number - unique code - must be 9 digits
        /// </summary>
        public required string SIN
        {   get
            {
                return _sin.MaskedValue();
            }
            set
            {
                _sin = value;
            }
        }


        /// <summary>
        /// Address information
        /// </summary>
        public string Address { get; set; } = string.Empty;

        private string _phoneNumber= "0000000000";

        /// <summary>
        /// Phone Number - must be 10 digits if available.
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber.MaskedValue();
            }
            set
            {
                _phoneNumber = value;
            }
        }

        private string _wellnessStatus= AdditionalHelp.SetRandomWellnessStatus();

        /// <summary>
        /// Health status - randomly generated based on probability of green=0.6 , yellow=0.2 and red=0.2
        /// </summary>
        public string HealthStatus
        {
            get
            {
                return _wellnessStatus;
            }
            set
            {
                _wellnessStatus=value ;
            }
        }

        

       
    }
}
