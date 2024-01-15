using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace NaniTrader.BackTester.Exchanges.Securities
{
    public class EquitySecurity : FullAuditedEntity<long>
    {
        // here for ef core
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
        private EquitySecurity() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor.

        public Exchange? Exchange { get; private set; }
        public int ExchangeId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ISIN { get; private set; }
        public string TickerSymbol { get; private set; }

        internal EquitySecurity(string name, string description, int exchangeId, string isin, string tickerSymbol)
        {
            SetName(name);
            SetDescription(description);
            ExchangeId = exchangeId;
            SetISIN(isin);
            SetTickerSymbol(tickerSymbol);
        }

        [MemberNotNull(nameof(Name))]
        public EquitySecurity SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), ExchangeConsts.MaxNameLength, ExchangeConsts.MinNameLength);
            return this;
        }

        [MemberNotNull(nameof(Description))]
        public EquitySecurity SetDescription(string description)
        {
            Description = Check.NotNullOrWhiteSpace(description, nameof(description), ExchangeConsts.MaxDescriptionLength, ExchangeConsts.MinDescriptionLength);
            return this;
        }

        [MemberNotNull(nameof(ISIN))]
        public EquitySecurity SetISIN(string isin)
        {
            ISIN = Check.NotNullOrWhiteSpace(isin, nameof(isin), ExchangeConsts.MaxISINLength, ExchangeConsts.MinISINLength);
            return this;
        }

        [MemberNotNull(nameof(TickerSymbol))]
        public EquitySecurity SetTickerSymbol(string tickerSymbol)
        {
            TickerSymbol = Check.NotNullOrWhiteSpace(tickerSymbol, nameof(tickerSymbol), ExchangeConsts.MaxTickerSymbolLength, ExchangeConsts.MinTickerSymbolLength);
            return this;
        }
    }
}
