﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace NaniTrader.BackTester.Exchanges
{
    public class ExchangeAppService : BackTesterAppService, IExchangeAppService
    {
        private readonly IExchangeRepository _exchangeRepository;
        private readonly ExchangeManager _exchangeManager;

        public ExchangeAppService(
            IExchangeRepository exchangeRepository,
            ExchangeManager exchangeManager)
        {
            _exchangeRepository = exchangeRepository;
            _exchangeManager = exchangeManager;
        }

        public async Task<ExchangeDto> GetAsync(int id)
        {
            var exchange = await _exchangeRepository.GetAsync(id);
            return ObjectMapper.Map<Exchange, ExchangeDto>(exchange);
        }

        public async Task<PagedResultDto<ExchangeInListDto>> GetListAsync(ExchangeListFilterDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Exchange.Name);
            }

            var exchanges = await _exchangeRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Name
            );

            var totalCount = input.Name == null
                ? await _exchangeRepository.CountAsync()
                : await _exchangeRepository.CountAsync(
                    exchange => exchange.Name.Contains(input.Name));

            return new PagedResultDto<ExchangeInListDto>(
                totalCount,
                ObjectMapper.Map<List<Exchange>, List<ExchangeInListDto>>(exchanges)
            );
        }

        public async Task<ExchangeDto> CreateAsync(CreateUpdateExchangeDto input)
        {
            var exchange = await _exchangeManager.CreateAsync(
                input.Name,
                input.Description
            );

            await _exchangeRepository.InsertAsync(exchange);

            return ObjectMapper.Map<Exchange, ExchangeDto>(exchange);
        }

        public async Task DeleteAsync(int id)
        {
            await _exchangeRepository.DeleteAsync(id);
        }
    }
}
