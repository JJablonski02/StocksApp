using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp.Services;

namespace StocksApp.Controllers
{
    public class StockController : Controller
    {
        private readonly StockService _stockService;
        private readonly IOptions<TradingOptions> _tradingOptions;
        public StockController(StockService stockService, IOptions<TradingOptions> tradingOptions)
        {
            _stockService = stockService;
            _tradingOptions = tradingOptions;
        }
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            if(_tradingOptions.Value.DefaultStockSymbol == null)
            {
                _tradingOptions.Value.DefaultStockSymbol = "MSFT";
            }
            Dictionary<string,object>? responseDictionary = await _stockService.GetStockPriceQuote(_tradingOptions.Value.DefaultStockSymbol);
            return View();
        }
    }
}
