using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Models;
using StockAPI.Services;

namespace StockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet("{portfolioId}")]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStocks(int portfolioId)
        {
            var investments =await _stockService.GetStocks(portfolioId);
            return Ok(investments);
        }

        [HttpGet]
        public async Task<ActionResult<Stock>> GetStock(int stockId, int portfolioId)
        {
            var investment = await _stockService.GetStock(stockId, portfolioId);
            if (investment == null)
            {
                return NotFound();
            }
            return Ok(investment);
        }

        [HttpPost]
        public async Task<ActionResult<Stock>> CreateStock(Stock investment)
        {
            var createdStock = await _stockService.CreateStock(investment);
            return CreatedAtAction(nameof(GetStock), new { id = createdStock.Stockid }, createdStock);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStock(int stockId, Stock investment)
        {
            if (stockId != investment.Stockid)
            {
                return BadRequest();
            }
            await _stockService.UpdateStock(stockId, investment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int stockId,int portfolioId)
        {
            var investment =await _stockService.GetStock(stockId, portfolioId);
            if (investment == null)
            {
                return NotFound();
            }
            await _stockService.DeleteStock(stockId, portfolioId);
            return NoContent();
        }
    }
}
