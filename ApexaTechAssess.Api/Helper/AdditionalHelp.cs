using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;

namespace ApexaTechAssess.Api.Helper
{
    /// <summary>
    /// This class is used to handle additional operations.
    /// </summary>
    public static class AdditionalHelp
    {
        /// <summary>
        /// This method is used to generate the health status for an advisor randomly based on probability of green=0.6 , yellow=0.2 and red=0.2
        /// </summary>
        /// <returns></returns>
        public static string SetRandomWellnessStatus()
        {
            double randomVal = Random.Shared.NextDouble();

            if (randomVal >= 0.0f && randomVal <= 0.6f)
            {
                return WellnessStatus.Green;
            }
            if (randomVal > 0.6f && randomVal <= 0.8f)
            {
                return WellnessStatus.Yellow;
            }
            else
            {
                return WellnessStatus.Red;
            }

        }
        
    }
}
