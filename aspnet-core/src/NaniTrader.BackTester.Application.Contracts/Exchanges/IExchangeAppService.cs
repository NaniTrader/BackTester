using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace NaniTrader.BackTester.Exchanges
{
    public interface IExchangeAppService : IApplicationService
    {
        Task<ExchangeDto> GetAsync(int id);

        Task<ExchangeDto> CreateAsync(CreateUpdateExchangeDto input);

        Task<PagedResultDto<ExchangeInListDto>> GetListAsync(ExchangeListFilterDto input);

        Task DeleteAsync(int id);
    }
}
