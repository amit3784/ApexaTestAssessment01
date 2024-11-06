using ApexaTechAssess.Api.Features.AdvisorFeatures.DB;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Validations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Repos
{
    public class AdvisorRepository : IAdvisorRepository
    {
        private readonly AdvisorDbContext _context;
        
        public AdvisorRepository(AdvisorDbContext context)
        {
            _context = context;
        }

        public async Task<List<Advisor>> GetAdvisors()
        {

            var result = await _context.Set<Advisor>().AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Advisor?> GetAdvisorByIdAsync(int id)
        {
            var result = await _context.Set<Advisor>().FindAsync(id);
            return result;
        }

        public async Task<Advisor> CreateAdvisor(Advisor advisor)
        {
           
                await _context.Set<Advisor>().AddAsync(advisor);
                await _context.SaveChangesAsync();
            
            return advisor;
        }

        public async Task<Advisor> UpdateAdvisor(Advisor advisor)
        {
            
                var result = await _context.Set<Advisor>().FindAsync(advisor.Id);
                if (result != null)
                {
                    result.PhoneNumber = advisor.PhoneNumber != string.Empty ? advisor.PhoneNumber : result.PhoneNumber;
                    result.FullName = advisor.FullName != string.Empty ? advisor.FullName : result.FullName;
                    result.Address = advisor.Address != string.Empty ? advisor.Address : result.Address;
                    result.SIN = advisor.SIN != string.Empty ? advisor.SIN : result.SIN;
                    
                    await _context.SaveChangesAsync();
                }
            
            return advisor;

        }

        public async Task DeleteAdvisor(int id)
        {
            var advisor = await _context.Set<Advisor>().FindAsync(id);
            if (advisor != null)
            {
                _context.Remove(advisor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
