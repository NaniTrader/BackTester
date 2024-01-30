using Microsoft.Extensions.Logging;
using NaniTrader.BackTester.MarketDataProviders.Securities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace NaniTrader.BackTester.MarketDataProviders
{
    public class MarketDataProvider : FullAuditedAggregateRoot<Guid>
    {
        // here for ef core
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
        private MarketDataProvider() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor.

        public string Name { get; private set; }
        public string Description { get; private set; }

        public ICollection<Guid> SubscribedExchanges { get; private set; }
        public ICollection<EquitySecurity> EquitySecurities { get; private set; }
        public ICollection<EquityFutureSecurity> EquityFutureSecurities { get; private set; }
        public ICollection<EquityOptionSecurity> EquityOptionSecurities { get; private set; }
        public ICollection<IndexSecurity> IndexSecurities { get; private set; }
        public ICollection<IndexFutureSecurity> IndexFutureSecurities { get; private set; }
        public ICollection<IndexOptionSecurity> IndexOptionSecurities { get; private set; }

        internal MarketDataProvider(Guid id, string name, string description) : base(id)
        {
            SetName(name);
            SetDescription(description);

            SubscribedExchanges = new Collection<Guid>();
            EquitySecurities = new Collection<EquitySecurity>();
            EquityFutureSecurities = new Collection<EquityFutureSecurity>();
            EquityOptionSecurities = new Collection<EquityOptionSecurity>();
            IndexSecurities = new Collection<IndexSecurity>();
            IndexFutureSecurities = new Collection<IndexFutureSecurity>();
            IndexOptionSecurities = new Collection<IndexOptionSecurity>();
        }

        [MemberNotNull(nameof(Name))]
        public MarketDataProvider SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), MarketDataProviderConsts.MaxNameLength, MarketDataProviderConsts.MinNameLength);
            return this;
        }

        [MemberNotNull(nameof(Description))]
        public MarketDataProvider SetDescription(string description)
        {
            Description = Check.NotNullOrWhiteSpace(description, nameof(description), MarketDataProviderConsts.MaxDescriptionLength, MarketDataProviderConsts.MinDescriptionLength);
            return this;
        }

        internal MarketDataProvider AddExchange(Guid exchangeId)
        {
            if (SubscribedExchanges.Contains(exchangeId))
            {
                throw new BusinessException(BackTesterDomainErrorCodes.ExchangeAlreadyExists)
                    .WithData("ExchangeId", exchangeId);
            }

            SubscribedExchanges.Add(exchangeId);

            return this;
        }
    }
}
