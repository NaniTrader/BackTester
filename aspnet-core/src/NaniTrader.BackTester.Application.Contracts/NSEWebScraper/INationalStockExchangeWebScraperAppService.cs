using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace NaniTrader.BackTester.NSEWebScraper
{
    public interface INationalStockExchangeWebScraperAppService : IApplicationService
    {
        Task GetCashMarketFullBhavCopyAsync(DateTime date);
    }
}