using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Repos
{
    public interface IAdvisorRepository
    {
        Task<Advisor> CreateAdvisor(Advisor advisor);
        Task DeleteAdvisor(int id);
        Task<Advisor?> GetAdvisorByIdAsync(int id);
        Task<List<Advisor>> GetAdvisors();
        Task<Advisor> UpdateAdvisor(Advisor advisor);
    }
}