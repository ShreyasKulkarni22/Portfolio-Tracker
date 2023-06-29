using PortfolioAPI.Models;
using PortfolioAPI.Repository;

namespace PortfolioAPI.Services
{
    public class PortfolioProfileService : IPortfolioProfileService
    {
        private readonly IPortfolioProfileRepository _portfolioProfileRepository;

        public PortfolioProfileService(IPortfolioProfileRepository portfolioProfileRepository)
        {
            _portfolioProfileRepository = portfolioProfileRepository;
        }

        public async Task<IEnumerable<PortfolioProfile>> GetPortfolioProfiles()
        {
            var portfolios=await _portfolioProfileRepository.GetPortfolioProfiles();
            return portfolios;

        }

        public async Task<PortfolioProfile> GetPortfolioProfile(int portfolioId)
        {
            return await _portfolioProfileRepository.GetPortfolioProfile(portfolioId);
        }

        public async Task CreatePortfolioProfile(PortfolioProfile portfolioProfile)
        {
            await _portfolioProfileRepository.CreatePortfolioProfile(portfolioProfile);
        }

        public async Task UpdatePortfolioProfile(int id,PortfolioProfile portfolioProfile)
        {
            await _portfolioProfileRepository.UpdatePortfolioProfile(id,portfolioProfile);
        }

        public async Task DeletePortfolioProfile(int portfolioId)
        {
            await _portfolioProfileRepository.DeletePortfolioProfile(portfolioId);
        }

        public async Task<bool> PortfolioExists(int id)
        {
            var isPortfolio = await _portfolioProfileRepository.PortfolioExists(id);
            return isPortfolio;
        }
    }

}
