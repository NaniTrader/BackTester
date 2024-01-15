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
    public class EquityOptionSecurity : FullAuditedEntity<long>
    {
        // here for ef core
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
        private EquityOptionSecurity() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor.

        public MarketDataProvider? MarketDataProvider { get; private set; }
        public int MarketDataProviderId { get; private set; }
        public EquitySecurity? EquitySecurity { get; private set; }
        public long EquitySecurityId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        internal EquityOptionSecurity(string name, string description, int marketDataProviderId, long equitySecurityId)
        {
            SetName(name);
            SetDescription(description);
            MarketDataProviderId = marketDataProviderId;
            EquitySecurityId = equitySecurityId;
        }

        [MemberNotNull(nameof(Name))]
        public EquityOptionSecurity SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), MarketDataProviderConsts.MaxNameLength, MarketDataProviderConsts.MinNameLength);
            return this;
        }

        [MemberNotNull(nameof(Description))]
        public EquityOptionSecurity SetDescription(string description)
        {
            Description = Check.NotNullOrWhiteSpace(description, nameof(description), MarketDataProviderConsts.MaxDescriptionLength, MarketDataProviderConsts.MinDescriptionLength);
            return this;
        }
    }
}
