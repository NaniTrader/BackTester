﻿using NaniTrader.BackTester.Countries;
using NaniTrader.BackTester.Exchanges;
using NaniTrader.BackTester.MarketDataProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace NaniTrader.BackTester.Data
{
    public class BackTesterDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Country, Guid> _countryRepository;
        private readonly IExchangeRepository _exchangeRepository;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IMarketDataProviderRepository _marketDataProviderRepository;

        public BackTesterDataSeedContributor(
            IRepository<Country, Guid> countryRepository,
            IExchangeRepository exchangeRepository,
            IGuidGenerator guidGenerator,
            IMarketDataProviderRepository marketDataProviderRepository)
        {
            _countryRepository = countryRepository;
            _exchangeRepository = exchangeRepository;
            _guidGenerator = guidGenerator;
            _marketDataProviderRepository = marketDataProviderRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await CreateCountriesAsync();
            await CreateExchangesAsync();
            await CreateMarketDataProvidersAsync();
        }

        private async Task CreateMarketDataProvidersAsync()
        {
            if (await _marketDataProviderRepository.GetCountAsync() > 0)
            {
                return;
            }

            var marketDataProvider = new MarketDataProvider(_guidGenerator.Create(), "ExchangeWebsiteScrapedData", "Data Scraped from Exchanges Website");
            var exchanges = await _exchangeRepository.GetPagedListAsync(0, 10, "");

            foreach (var exchange in exchanges)
            {
                marketDataProvider.AddExchange(exchange.Id);
            }

            await _marketDataProviderRepository.InsertAsync(marketDataProvider, autoSave: true);
        }

        private async Task CreateExchangesAsync()
        {
            if (await _exchangeRepository.GetCountAsync() > 0)
            {
                return;
            }

            var exchanges = new List<Exchange>
            {
                new Exchange(_guidGenerator.Create(), "NSE", "National Stock Exchange"),
                new Exchange(_guidGenerator.Create(), "BSE", "Bombay Stock Exchange")
            };

            await _exchangeRepository.InsertManyAsync(exchanges, autoSave: true);
        }

        private async Task CreateCountriesAsync()
        {
            if (await _countryRepository.GetCountAsync() > 0)
            {
                return;
            }

            var countries = new List<Country>
            {
                new Country(_guidGenerator.Create(), "Afghanistan"),
                new Country(_guidGenerator.Create(), "Albania"),
                new Country(_guidGenerator.Create(), "Algeria"),
                new Country(_guidGenerator.Create(), "Andorra"),
                new Country(_guidGenerator.Create(), "Angola"),
                new Country(_guidGenerator.Create(), "Antigua and Barbuda"),
                new Country(_guidGenerator.Create(), "Argentina"),
                new Country(_guidGenerator.Create(), "Armenia"),
                new Country(_guidGenerator.Create(), "Australia"),
                new Country(_guidGenerator.Create(), "Austria"),
                new Country(_guidGenerator.Create(), "Azerbaijan"),
                new Country(_guidGenerator.Create(), "Bahamas"),
                new Country(_guidGenerator.Create(), "Bahrain"),
                new Country(_guidGenerator.Create(), "Bangladesh"),
                new Country(_guidGenerator.Create(), "Barbados"),
                new Country(_guidGenerator.Create(), "Belarus"),
                new Country(_guidGenerator.Create(), "Belgium"),
                new Country(_guidGenerator.Create(), "Belize"),
                new Country(_guidGenerator.Create(), "Benin"),
                new Country(_guidGenerator.Create(), "Bhutan"),
                new Country(_guidGenerator.Create(), "Bolivia"),
                new Country(_guidGenerator.Create(), "Bosnia and Herzegovina"),
                new Country(_guidGenerator.Create(), "Botswana"),
                new Country(_guidGenerator.Create(), "Brazil"),
                new Country(_guidGenerator.Create(), "Brunei"),
                new Country(_guidGenerator.Create(), "Bulgaria"),
                new Country(_guidGenerator.Create(), "Burkina Faso"),
                new Country(_guidGenerator.Create(), "Burundi"),
                new Country(_guidGenerator.Create(), "Côte d'Ivoire"),
                new Country(_guidGenerator.Create(), "Cabo Verde"),
                new Country(_guidGenerator.Create(), "Cambodia"),
                new Country(_guidGenerator.Create(), "Cameroon"),
                new Country(_guidGenerator.Create(), "Canada"),
                new Country(_guidGenerator.Create(), "Central African Republic"),
                new Country(_guidGenerator.Create(), "Chad"),
                new Country(_guidGenerator.Create(), "Chile"),
                new Country(_guidGenerator.Create(), "China"),
                new Country(_guidGenerator.Create(), "Colombia"),
                new Country(_guidGenerator.Create(), "Comoros"),
                new Country(_guidGenerator.Create(), "Congo (Congo-Brazzaville)"),
                new Country(_guidGenerator.Create(), "Costa Rica"),
                new Country(_guidGenerator.Create(), "Croatia"),
                new Country(_guidGenerator.Create(), "Cuba"),
                new Country(_guidGenerator.Create(), "Cyprus"),
                new Country(_guidGenerator.Create(), "Czechia (Czech Republic)"),
                new Country(_guidGenerator.Create(), "Democratic Republic of the Congo"),
                new Country(_guidGenerator.Create(), "Denmark"),
                new Country(_guidGenerator.Create(), "Djibouti"),
                new Country(_guidGenerator.Create(), "Dominica"),
                new Country(_guidGenerator.Create(), "Dominican Republic"),
                new Country(_guidGenerator.Create(), "Ecuador"),
                new Country(_guidGenerator.Create(), "Egypt"),
                new Country(_guidGenerator.Create(), "El Salvador"),
                new Country(_guidGenerator.Create(), "Equatorial Guinea"),
                new Country(_guidGenerator.Create(), "Eritrea"),
                new Country(_guidGenerator.Create(), "Estonia"),
                new Country(_guidGenerator.Create(), "Eswatini (formerly Swaziland)"),
                new Country(_guidGenerator.Create(), "Ethiopia"),
                new Country(_guidGenerator.Create(), "Fiji"),
                new Country(_guidGenerator.Create(), "Finland"),
                new Country(_guidGenerator.Create(), "France"),
                new Country(_guidGenerator.Create(), "Gabon"),
                new Country(_guidGenerator.Create(), "Gambia"),
                new Country(_guidGenerator.Create(), "Georgia"),
                new Country(_guidGenerator.Create(), "Germany"),
                new Country(_guidGenerator.Create(), "Ghana"),
                new Country(_guidGenerator.Create(), "Greece"),
                new Country(_guidGenerator.Create(), "Grenada"),
                new Country(_guidGenerator.Create(), "Guatemala"),
                new Country(_guidGenerator.Create(), "Guinea"),
                new Country(_guidGenerator.Create(), "Guinea-Bissau"),
                new Country(_guidGenerator.Create(), "Guyana"),
                new Country(_guidGenerator.Create(), "Haiti"),
                new Country(_guidGenerator.Create(), "Holy See"),
                new Country(_guidGenerator.Create(), "Honduras"),
                new Country(_guidGenerator.Create(), "Hungary"),
                new Country(_guidGenerator.Create(), "Iceland"),
                new Country(_guidGenerator.Create(), "India"),
                new Country(_guidGenerator.Create(), "Indonesia"),
                new Country(_guidGenerator.Create(), "Iran"),
                new Country(_guidGenerator.Create(), "Iraq"),
                new Country(_guidGenerator.Create(), "Ireland"),
                new Country(_guidGenerator.Create(), "Israel"),
                new Country(_guidGenerator.Create(), "Italy"),
                new Country(_guidGenerator.Create(), "Jamaica"),
                new Country(_guidGenerator.Create(), "Japan"),
                new Country(_guidGenerator.Create(), "Jordan"),
                new Country(_guidGenerator.Create(), "Kazakhstan"),
                new Country(_guidGenerator.Create(), "Kenya"),
                new Country(_guidGenerator.Create(), "Kiribati"),
                new Country(_guidGenerator.Create(), "Kuwait"),
                new Country(_guidGenerator.Create(), "Kyrgyzstan"),
                new Country(_guidGenerator.Create(), "Laos"),
                new Country(_guidGenerator.Create(), "Latvia"),
                new Country(_guidGenerator.Create(), "Lebanon"),
                new Country(_guidGenerator.Create(), "Lesotho"),
                new Country(_guidGenerator.Create(), "Liberia"),
                new Country(_guidGenerator.Create(), "Libya"),
                new Country(_guidGenerator.Create(), "Liechtenstein"),
                new Country(_guidGenerator.Create(), "Lithuania"),
                new Country(_guidGenerator.Create(), "Luxembourg"),
                new Country(_guidGenerator.Create(), "Madagascar"),
                new Country(_guidGenerator.Create(), "Malawi"),
                new Country(_guidGenerator.Create(), "Malaysia"),
                new Country(_guidGenerator.Create(), "Maldives"),
                new Country(_guidGenerator.Create(), "Mali"),
                new Country(_guidGenerator.Create(), "Malta"),
                new Country(_guidGenerator.Create(), "Marshall Islands"),
                new Country(_guidGenerator.Create(), "Mauritania"),
                new Country(_guidGenerator.Create(), "Mauritius"),
                new Country(_guidGenerator.Create(), "Mexico"),
                new Country(_guidGenerator.Create(), "Micronesia"),
                new Country(_guidGenerator.Create(), "Moldova"),
                new Country(_guidGenerator.Create(), "Monaco"),
                new Country(_guidGenerator.Create(), "Mongolia"),
                new Country(_guidGenerator.Create(), "Montenegro"),
                new Country(_guidGenerator.Create(), "Morocco"),
                new Country(_guidGenerator.Create(), "Mozambique"),
                new Country(_guidGenerator.Create(), "Myanmar (formerly Burma)"),
                new Country(_guidGenerator.Create(), "Namibia"),
                new Country(_guidGenerator.Create(), "Nauru"),
                new Country(_guidGenerator.Create(), "Nepal"),
                new Country(_guidGenerator.Create(), "Netherlands"),
                new Country(_guidGenerator.Create(), "New Zealand"),
                new Country(_guidGenerator.Create(), "Nicaragua"),
                new Country(_guidGenerator.Create(), "Niger"),
                new Country(_guidGenerator.Create(), "Nigeria"),
                new Country(_guidGenerator.Create(), "North Korea"),
                new Country(_guidGenerator.Create(), "North Macedonia"),
                new Country(_guidGenerator.Create(), "Norway"),
                new Country(_guidGenerator.Create(), "Oman"),
                new Country(_guidGenerator.Create(), "Pakistan"),
                new Country(_guidGenerator.Create(), "Palau"),
                new Country(_guidGenerator.Create(), "Palestine State"),
                new Country(_guidGenerator.Create(), "Panama"),
                new Country(_guidGenerator.Create(), "Papua New Guinea"),
                new Country(_guidGenerator.Create(), "Paraguay"),
                new Country(_guidGenerator.Create(), "Peru"),
                new Country(_guidGenerator.Create(), "Philippines"),
                new Country(_guidGenerator.Create(), "Poland"),
                new Country(_guidGenerator.Create(), "Portugal"),
                new Country(_guidGenerator.Create(), "Qatar"),
                new Country(_guidGenerator.Create(), "Romania"),
                new Country(_guidGenerator.Create(), "Russia"),
                new Country(_guidGenerator.Create(), "Rwanda"),
                new Country(_guidGenerator.Create(), "Saint Kitts and Nevis"),
                new Country(_guidGenerator.Create(), "Saint Lucia"),
                new Country(_guidGenerator.Create(), "Saint Vincent and the Grenadines"),
                new Country(_guidGenerator.Create(), "Samoa"),
                new Country(_guidGenerator.Create(), "San Marino"),
                new Country(_guidGenerator.Create(), "Sao Tome and Principe"),
                new Country(_guidGenerator.Create(), "Saudi Arabia"),
                new Country(_guidGenerator.Create(), "Senegal"),
                new Country(_guidGenerator.Create(), "Serbia"),
                new Country(_guidGenerator.Create(), "Seychelles"),
                new Country(_guidGenerator.Create(), "Sierra Leone"),
                new Country(_guidGenerator.Create(), "Singapore"),
                new Country(_guidGenerator.Create(), "Slovakia"),
                new Country(_guidGenerator.Create(), "Slovenia"),
                new Country(_guidGenerator.Create(), "Solomon Islands"),
                new Country(_guidGenerator.Create(), "Somalia"),
                new Country(_guidGenerator.Create(), "South Africa"),
                new Country(_guidGenerator.Create(), "South Korea"),
                new Country(_guidGenerator.Create(), "South Sudan"),
                new Country(_guidGenerator.Create(), "Spain"),
                new Country(_guidGenerator.Create(), "Sri Lanka"),
                new Country(_guidGenerator.Create(), "Sudan"),
                new Country(_guidGenerator.Create(), "Suriname"),
                new Country(_guidGenerator.Create(), "Sweden"),
                new Country(_guidGenerator.Create(), "Switzerland"),
                new Country(_guidGenerator.Create(), "Syria"),
                new Country(_guidGenerator.Create(), "Tajikistan"),
                new Country(_guidGenerator.Create(), "Tanzania"),
                new Country(_guidGenerator.Create(), "Thailand"),
                new Country(_guidGenerator.Create(), "Timor-Leste"),
                new Country(_guidGenerator.Create(), "Togo"),
                new Country(_guidGenerator.Create(), "Tonga"),
                new Country(_guidGenerator.Create(), "Trinidad and Tobago"),
                new Country(_guidGenerator.Create(), "Tunisia"),
                new Country(_guidGenerator.Create(), "Turkey"),
                new Country(_guidGenerator.Create(), "Turkmenistan"),
                new Country(_guidGenerator.Create(), "Tuvalu"),
                new Country(_guidGenerator.Create(), "Uganda"),
                new Country(_guidGenerator.Create(), "Ukraine"),
                new Country(_guidGenerator.Create(), "United Arab Emirates"),
                new Country(_guidGenerator.Create(), "United Kingdom"),
                new Country(_guidGenerator.Create(), "United States of America"),
                new Country(_guidGenerator.Create(), "Uruguay"),
                new Country(_guidGenerator.Create(), "Uzbekistan"),
                new Country(_guidGenerator.Create(), "Vanuatu"),
                new Country(_guidGenerator.Create(), "Venezuela"),
                new Country(_guidGenerator.Create(), "Vietnam"),
                new Country(_guidGenerator.Create(), "Yemen"),
                new Country(_guidGenerator.Create(), "Zambia"),
                new Country(_guidGenerator.Create(), "Zimbabwe")
            };

            await _countryRepository.InsertManyAsync(countries, autoSave: true);
        }
    }
}
