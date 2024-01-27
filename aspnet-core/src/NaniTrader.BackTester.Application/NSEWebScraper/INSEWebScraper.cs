using Refit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaniTrader.BackTester.NSEWebScraper
{
    public interface INSEWebScraper
    {
        [Get("/all-reports")]
        Task GetAllReportsHomePageAsync();

        [Get("/api/reports")]
        Task<ApiResponse<Stream>> GetReportsAsync(string archives, string date, string type, string mode);
    }
}
