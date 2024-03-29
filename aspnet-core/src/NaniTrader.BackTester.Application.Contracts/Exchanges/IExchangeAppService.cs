﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace NaniTrader.BackTester.Exchanges
{
    public interface IExchangeAppService : IApplicationService
    {
        Task<ExchangeDto> GetAsync(Guid id);

        Task<ExchangeDto> CreateAsync(CreateUpdateExchangeDto input);

        Task<PagedResultDto<ExchangeInListDto>> GetPagedListWithNameFilterAsync(ExchangeListFilterDto input);

        Task DeleteAsync(Guid id);
    }
}
