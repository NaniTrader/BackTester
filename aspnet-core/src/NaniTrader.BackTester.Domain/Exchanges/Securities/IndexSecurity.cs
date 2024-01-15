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
    public class IndexSecurity : FullAuditedEntity<long>
    {
        // here for ef core
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
        private IndexSecurity() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor.

        public Exchange? Exchange { get; private set; }
        public int ExchangeId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        internal IndexSecurity(string name, string description, int exchangeId)
        {
            SetName(name);
            SetDescription(description);
            ExchangeId = exchangeId;
        }

        [MemberNotNull(nameof(Name))]
        public IndexSecurity SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), ExchangeConsts.MaxNameLength, ExchangeConsts.MinNameLength);
            return this;
        }

        [MemberNotNull(nameof(Description))]
        public IndexSecurity SetDescription(string description)
        {
            Description = Check.NotNullOrWhiteSpace(description, nameof(description), ExchangeConsts.MaxDescriptionLength, ExchangeConsts.MinDescriptionLength);
            return this;
        }
    }
}
