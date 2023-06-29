using Newtonsoft.Json;
using PortfolioAPI.Models;
using StockAPI.Repository;

namespace StockAPI.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly string baseAddress;
        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
            baseAddress = "https://localhost:7012";


        }
        public async Task<Stock> CreateStock(Stock investment)
        {
            //return await _stockRepository.CreateStock(investment);
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:7012/api/PortfolioProfile/Portfolios/{investment.PortfolioId}/exists");
                if (response.IsSuccessStatusCode)
                {
                    string jsonresponse = await response.Content.ReadAsStringAsync();
                    bool status = Boolean.Parse(jsonresponse);
                    if (status)
                    {
                        return await _stockRepository.CreateStock(investment);
                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    // Handle error response
                    return null;
                }
            }
        }

        public async Task DeleteStock(int stockId, int portfolioId)
        {
            await _stockRepository.DeleteStock(stockId,portfolioId);
        }

        public async Task<IEnumerable<Stock>> GetStocks(int portfolioId)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:7012/api/PortfolioProfile/Portfolios/{portfolioId}/exists");
                if (response.IsSuccessStatusCode)
                {
                    string jsonresponse=await response.Content.ReadAsStringAsync();
                    bool status=Boolean.Parse(jsonresponse);
                    if (status)
                    {
                        return await _stockRepository.GetStocks(portfolioId);
                    }
                    else
                    {
                        return null;
                    }
                    
                }
                else
                {
                    // Handle error response
                    return null;
                }
            }
            
        }

        public async Task<Stock> GetStock(int stockId, int portfolioId)
        {
            return await _stockRepository.GetStock(stockId,portfolioId);
        }

        public async Task UpdateStock(int stockId, Stock investment)
        {
            await _stockRepository.UpdateStock(stockId,investment);
        }
    }
}
