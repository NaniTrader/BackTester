using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace NaniTrader.BackTester.Exchanges
{
    public class EquityOptionSecurity : Entity<long>
    {
        // here for ef core
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
        private EquityOptionSecurity() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor.

        public Exchange? Exchange { get; private set; }
        public int ExchangeId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        internal EquityOptionSecurity(string name, string description, int exchangeId)
        {
            SetName(name);
            SetDescription(description);
            ExchangeId = exchangeId;
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
