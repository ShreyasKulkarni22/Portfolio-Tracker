﻿using PortfolioAPI.Models;

namespace PortfolioAPI.Repository
{
    public interface IPortfolioProfileRepository
    {
        Task<IEnumerable<PortfolioProfile>> GetPortfolioProfiles();
        Task<PortfolioProfile> GetPortfolioProfile(int portfolioId);
        Task CreatePortfolioProfile(PortfolioProfile portfolioProfile);
        Task UpdatePortfolioProfile(int id, PortfolioProfile portfolioProfile);
        Task DeletePortfolioProfile(int portfolioId);
        Task<bool> PortfolioExists(int id);
    }
}
