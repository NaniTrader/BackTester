using Volo.Abp.Modularity;

namespace NaniTrader.BackTester;

public abstract class BackTesterApplicationTestBase<TStartupModule> : BackTesterTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
