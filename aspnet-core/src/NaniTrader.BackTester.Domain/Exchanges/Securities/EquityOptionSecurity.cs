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
    public class EquityOptionSecurity : FullAuditedEntity<Guid>
    {
        // here for ef core
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
        private EquityOptionSecurity() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor.

        public Exchange Exchange { get; private set; }
        public EquitySecurity Underlying { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        internal EquityOptionSecurity(Guid id, string name, string description, Exchange exchange, EquitySecurity underlying) : base(id)
        {
            SetName(name);
            SetDescription(description);
            Underlying = underlying;
            Exchange = exchange;
        }

        [MemberNotNull(nameof(Name))]
        public EquityOptionSecurity SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), ExchangeConsts.MaxNameLength, ExchangeConsts.MinNameLength);
            return this;
        }

        [MemberNotNull(nameof(Description))]
        public EquityOptionSecurity SetDescription(string description)
        {
            Description = Check.NotNullOrWhiteSpace(description, nameof(description), ExchangeConsts.MaxDescriptionLength, ExchangeConsts.MinDescriptionLength);
            return this;
        }
    }
}
