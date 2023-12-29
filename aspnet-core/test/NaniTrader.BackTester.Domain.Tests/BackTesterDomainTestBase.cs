using Volo.Abp.Modularity;

namespace NaniTrader.BackTester;

/* Inherit from this class for your domain layer tests. */
public abstract class BackTesterDomainTestBase<TStartupModule> : BackTesterTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
