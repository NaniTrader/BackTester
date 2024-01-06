using Microsoft.Extensions.Logging;
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

namespace NaniTrader.BackTester.Exchanges
{
    public class Exchange : FullAuditedAggregateRoot<int>
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
        private Exchange() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor.

        public string Name { get; private set; }
        public string Description { get; private set; }

        public ICollection<EquitySecurity> EquitySecurities { get; private set; }
        public ICollection<EquityFutureSecurity> EquityFutureSecurities { get; private set; }
        public ICollection<EquityOptionSecurity> EquityOptionSecurities { get; private set; }
        public ICollection<IndexSecurity> IndexSecurities { get; private set; }
        public ICollection<IndexFutureSecurity> IndexFutureSecurities { get; private set; }
        public ICollection<IndexOptionSecurity> IndexOptionSecurities { get; private set; }

        internal Exchange(
            int id,
            string name,
            string description)
        : base(id)
        {
            SetName(name);
            SetDescription(description);

            EquitySecurities = new Collection<EquitySecurity>();
            EquityFutureSecurities = new Collection<EquityFutureSecurity>();
            EquityOptionSecurities = new Collection<EquityOptionSecurity>();
            IndexSecurities = new Collection<IndexSecurity>();
            IndexFutureSecurities = new Collection<IndexFutureSecurity>();
            IndexOptionSecurities = new Collection<IndexOptionSecurity>();
        }

        [MemberNotNull(nameof(Name))]
        public Exchange SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), ExchangeConsts.MaxNameLength, ExchangeConsts.MinNameLength);
            return this;
        }

        [MemberNotNull(nameof(Description))]
        public Exchange SetDescription(string description)
        {
            Description = Check.NotNullOrWhiteSpace(description, nameof(description), ExchangeConsts.MaxDescriptionLength, ExchangeConsts.MinDescriptionLength);
            return this;
        }
    }
}
