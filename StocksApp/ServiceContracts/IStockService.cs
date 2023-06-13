namespace StocksApp.ServiceContracts
{
    public interface IStockService
    {
        Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol);
    }
}
