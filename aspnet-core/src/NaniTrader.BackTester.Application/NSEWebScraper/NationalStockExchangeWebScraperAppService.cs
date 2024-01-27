using NaniTrader.BackTester.Exchanges;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.IO;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper;
using Refit;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Volo.Abp.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace NaniTrader.BackTester.NSEWebScraper
{
    public class NationalStockExchangeWebScraperAppService : BackTesterAppService, INationalStockExchangeWebScraperAppService
    {
        private readonly INSEWebScraper _nseWebScraper;
        private readonly NSEData.CashMarket.BhavCopyManager _cashMarketBhavCopyManager;
        private readonly ILogger<NationalStockExchangeWebScraperAppService> _logger;
        private readonly NSEData.CashMarket.IBhavCopyRepository _bhavCopyRepository;

        public NationalStockExchangeWebScraperAppService(INSEWebScraper nseWebScraper,
            NSEData.CashMarket.BhavCopyManager cashMarketBhavCopyManager,
            ILogger<NationalStockExchangeWebScraperAppService> logger,
            NSEData.CashMarket.IBhavCopyRepository bhavCopyRepository)
        {
            _nseWebScraper = nseWebScraper;
            _cashMarketBhavCopyManager = cashMarketBhavCopyManager;
            _logger = logger;
            _bhavCopyRepository = bhavCopyRepository;
        }

        public async Task GetCashMarketFullBhavCopyAsync(DateTime date)
        {
            date = DateTime.Today.AddDays(-1);
            await _nseWebScraper.GetAllReportsHomePageAsync();
            string archives = "[{\"name\":\"Full Bhavcopy and Security Deliverable data\"," +
                "\"type\":\"daily-reports\"," +
                "\"category\":\"capital-market\"," +
                "\"section\":\"equities\"}]";
            string type = "\"equities\"";
            string mode = "\"single\"";

            using (var data = await _nseWebScraper.GetReportsAsync(archives, "\"" + DateOnly.FromDateTime(date).ToString("dd-MMM-yyyy") + "\"", type, mode))
            {
                if (!data.IsSuccessStatusCode)
                {
                    var bhavCopy = await _cashMarketBhavCopyManager.AddNoBhavCopyEntryAsync(DateOnly.FromDateTime(date));
                    await _bhavCopyRepository.InsertAsync(bhavCopy);
                    _logger.LogWarning(data.ReasonPhrase);
                    return;
                }

                using var zipArchive = new ZipArchive(data.Content);
                foreach (var file in zipArchive.Entries)
                {
                    if (file.FullName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                    {
                        //using (Stream csvStream = file.Open())
                        //using (StreamReader reader = new StreamReader(csvStream))
                        //using (CsvReader csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = true}))
                        //{
                        //    // Process each CSV record using CsvHelper
                        //    foreach (var record in csv.GetRecords<dynamic>())
                        //    logger
                        //        // Access fields by name
                        //        Console.WriteLine($"Name: {record.Name}, Email: {record.Email}"); // Example
                        //    }
                        //}

                        var stream = file.Open();
                        byte[] bytes;
                        using (var ms = new MemoryStream())
                        {
                            stream.CopyTo(ms);
                            bytes = ms.ToArray();
                        }

                        var bhavCopy = await _cashMarketBhavCopyManager.AddBhavCopyDataAsync(
                            DateOnly.FromDateTime(date), bytes, file.Name, file.LastWriteTime.UtcDateTime);
                        await _bhavCopyRepository.InsertAsync(bhavCopy);
                    }

                }
            }
        }

    }
}
