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
    public class IndexOptionSecurity : FullAuditedAggregateRoot<Guid>
    {
        // here for ef core
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
        private IndexOptionSecurity() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor.

        public Guid ExchangeSecurityId { get; private set; }
        public MarketDataProvider MarketDataProvider { get; private set; }
        public IndexSecurity Underlying { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        internal IndexOptionSecurity(Guid id, string name, string description, MarketDataProvider marketDataProvider, IndexSecurity underlying, Guid exchangeSecurityId) : base(id)
        {
            SetName(name);
            SetDescription(description);
            MarketDataProvider = marketDataProvider;
            Underlying = underlying;
            ExchangeSecurityId = exchangeSecurityId;
        }

        [MemberNotNull(nameof(Name))]
        public IndexOptionSecurity SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), MarketDataProviderConsts.MaxNameLength, MarketDataProviderConsts.MinNameLength);
            return this;
        }

        [MemberNotNull(nameof(Description))]
        public IndexOptionSecurity SetDescription(string description)
        {
            Description = Check.NotNullOrWhiteSpace(description, nameof(description), MarketDataProviderConsts.MaxDescriptionLength, MarketDataProviderConsts.MinDescriptionLength);
            return this;
        }
    }
}
