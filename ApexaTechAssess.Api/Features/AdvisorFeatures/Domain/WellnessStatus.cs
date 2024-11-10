namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Domain
{
    /// <summary>
    /// This structure is used to hold the health status of the advisor.
    /// </summary>
    public  struct WellnessStatus
    {
        /// <summary>
        /// healthy
        /// </summary>
        public const string Green = "Green";
        /// <summary>
        /// Moderate risk
        /// </summary>
        public const string Yellow = "Yellow";
        /// <summary>
        /// Risk
        /// </summary>
        public const string Red = "Red";
    }
}