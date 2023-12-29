using Volo.Abp.Modularity;

namespace NaniTrader.BackTester;

[DependsOn(
    typeof(BackTesterApplicationModule),
    typeof(BackTesterDomainTestModule)
)]
public class BackTesterApplicationTestModule : AbpModule
{

}
