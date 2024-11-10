using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Repos
{
    /// <summary>
    /// Interface for Advisory repository.
    /// </summary>
    public interface IAdvisorRepository
    {
        /// <summary>
        /// Command for createAdvisor.
        /// </summary>
        /// <param name="advisor"></param>
        /// <returns>Advisor</returns>
        Task<Advisor> CreateAdvisor(Advisor advisor);

        /// <summary>
        /// Command for delete advisor.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>void</returns>
        Task DeleteAdvisor(int id);

        /// <summary>
        /// query to get advisor based on unique id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Advisor</returns>
        Task<Advisor?> GetAdvisorByIdAsync(int id);


        /// <summary>
        /// query to get all advisors.
        /// </summary>
        /// <returns>List of advisors</returns>
        Task<List<Advisor>> GetAdvisors();

        /// <summary>
        /// Command for update advisor.
        /// </summary>
        /// <param name="advisor"></param>
        /// <returns>Advisor</returns>
        Task<Advisor> UpdateAdvisor(Advisor advisor);
    }
}