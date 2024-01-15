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
    public class IndexFutureSecurity : FullAuditedEntity<long>
    {
        // here for ef core
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
        private IndexFutureSecurity() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor.

        public MarketDataProvider? MarketDataProvider { get; private set; }
        public int MarketDataProviderId { get; private set; }
        public IndexSecurity? IndexSecurity { get; private set; }
        public long IndexSecurityId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        internal IndexFutureSecurity(string name, string description, int marketDataProviderId, long indexSecurityId)
        {
            SetName(name);
            SetDescription(description);
            MarketDataProviderId = marketDataProviderId;
            IndexSecurityId = indexSecurityId;
        }

        [MemberNotNull(nameof(Name))]
        public IndexFutureSecurity SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), MarketDataProviderConsts.MaxNameLength, MarketDataProviderConsts.MinNameLength);
            return this;
        }

        [MemberNotNull(nameof(Description))]
        public IndexFutureSecurity SetDescription(string description)
        {
            Description = Check.NotNullOrWhiteSpace(description, nameof(description), MarketDataProviderConsts.MaxDescriptionLength, MarketDataProviderConsts.MinDescriptionLength);
            return this;
        }
    }
}
