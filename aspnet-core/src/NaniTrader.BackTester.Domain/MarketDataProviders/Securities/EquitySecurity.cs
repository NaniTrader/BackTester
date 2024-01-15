using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace NaniTrader.BackTester.MarketDataProviders.Securities
{
    public class EquitySecurity : FullAuditedEntity<long>
    {
        // here for ef core
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
        private EquitySecurity() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor.

        public MarketDataProvider? MarketDataProvider { get; private set; }
        public int MarketDataProviderId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ISIN { get; private set; }
        public string TickerSymbol { get; private set; }

        internal EquitySecurity(string name, string description, int marketDataProviderId, string isin, string tickerSymbol)
        {
            SetName(name);
            SetDescription(description);
            MarketDataProviderId = marketDataProviderId;
            SetISIN(isin);
            SetTickerSymbol(tickerSymbol);
        }

        [MemberNotNull(nameof(Name))]
        public EquitySecurity SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), MarketDataProviderConsts.MaxNameLength, MarketDataProviderConsts.MinNameLength);
            return this;
        }

        [MemberNotNull(nameof(Description))]
        public EquitySecurity SetDescription(string description)
        {
            Description = Check.NotNullOrWhiteSpace(description, nameof(description), MarketDataProviderConsts.MaxDescriptionLength, MarketDataProviderConsts.MinDescriptionLength);
            return this;
        }

        [MemberNotNull(nameof(ISIN))]
        public EquitySecurity SetISIN(string isin)
        {
            ISIN = Check.NotNullOrWhiteSpace(isin, nameof(isin), MarketDataProviderConsts.MaxISINLength, MarketDataProviderConsts.MinISINLength);
            return this;
        }

        [MemberNotNull(nameof(TickerSymbol))]
        public EquitySecurity SetTickerSymbol(string tickerSymbol)
        {
            TickerSymbol = Check.NotNullOrWhiteSpace(tickerSymbol, nameof(tickerSymbol), MarketDataProviderConsts.MaxTickerSymbolLength, MarketDataProviderConsts.MinTickerSymbolLength);
            return this;
        }
    }
}
