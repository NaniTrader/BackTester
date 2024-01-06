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
    public class IndexSecurity : Entity<long>
    {
        // here for ef core
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
        private IndexSecurity() { }
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor.

        public string Name { get; private set; }
        public string Description { get; private set; }

        internal IndexSecurity(
            long id,
            string name,
            string description)
        : base(id)
        {
            SetName(name);
            SetDescription(description);
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
