using AutoMapper;
using NaniTrader.BackTester.Exchanges;

namespace NaniTrader.BackTester;

public class BackTesterApplicationAutoMapperProfile : Profile
{
    public BackTesterApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Exchange, ExchangeDto>();
        CreateMap<Exchange, ExchangeInListDto>();
        CreateMap<CreateUpdateExchangeDto, Exchange>();
    }
}
