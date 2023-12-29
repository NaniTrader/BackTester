using Volo.Abp.Modularity;

namespace NaniTrader.BackTester;

[DependsOn(
    typeof(BackTesterDomainModule),
    typeof(BackTesterTestBaseModule)
)]
public class BackTesterDomainTestModule : AbpModule
{

}
