using Microsoft.AspNetCore.Mvc;
using StocksApp.Services;

namespace StocksApp.Controllers
{
    public class StockController : Controller
    {
        private readonly StockService _stockService;
        public StockController(StockService stockService)
        {
            _stockService = stockService;
        }
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            Dictionary<string,object>? responseDictionary = await _stockService.GetStockPriceQuote("MSFT");
            return View();
        }
    }
}
