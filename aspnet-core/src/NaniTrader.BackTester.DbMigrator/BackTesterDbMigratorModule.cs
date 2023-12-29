using NaniTrader.BackTester.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace NaniTrader.BackTester.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BackTesterEntityFrameworkCoreModule),
    typeof(BackTesterApplicationContractsModule)
    )]
public class BackTesterDbMigratorModule : AbpModule
{
}
