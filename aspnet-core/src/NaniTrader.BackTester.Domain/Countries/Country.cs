using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp;

namespace NaniTrader.BackTester.Countries
{
    public class Country : BasicAggregateRoot<Guid>
    {
        // here for ef core
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
        private Country() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
        public string Name { get; private set; }

        internal Country(Guid id, string name) : base(id)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), CountryConsts.MaxNameLength);
        }
    }
}
