namespace ApexaTechAssessment.Test.TestHelpers
{
    public class SearializableAdvisor
    {
        /// <summary>
        /// Id - unique id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Full Name
        /// </summary>
        public string? FullName { get; set; }

        public string? Address { get; set; }
        public string? HealthStatus
        {
            get; set;
        }
    }

}
