using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Guids;
using Volo.Abp;

namespace NaniTrader.BackTester.Exchanges
{
    public class ExchangeManager : DomainService
    {
        private readonly IExchangeRepository _exchangeRepository;
        private readonly IGuidGenerator _guidGenerator;

        public ExchangeManager(IExchangeRepository exchangeRepository, IGuidGenerator guidGenerator)
        {
            _exchangeRepository = exchangeRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task<Exchange> CreateAsync(string name, string description)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingExchange = await _exchangeRepository.FindByNameAsync(name);
            if (existingExchange != null)
            {
                throw new ExchangeAlreadyExistsException(name);
            }

            return new Exchange(_guidGenerator.Create(), name, description);
        }
    }
}
