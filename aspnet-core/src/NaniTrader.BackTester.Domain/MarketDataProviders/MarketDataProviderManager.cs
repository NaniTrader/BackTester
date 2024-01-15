﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Guids;
using Volo.Abp;

namespace NaniTrader.BackTester.MarketDataProviders
{
    public class MarketDataProviderManager : DomainService
    {
        private readonly IMarketDataProviderRepository _marketDataProviderRepository;

        public MarketDataProviderManager(IMarketDataProviderRepository MarketDataProviderRepository)
        {
            _marketDataProviderRepository = MarketDataProviderRepository;
        }

        public async Task<MarketDataProvider> CreateAsync(string name, string description)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingMarketDataProvider = await _marketDataProviderRepository.FindByNameAsync(name);
            if (existingMarketDataProvider != null)
            {
                throw new MarketDataProviderAlreadyExistsException(name);
            }

            return new MarketDataProvider(name, description);
        }
    }
}
