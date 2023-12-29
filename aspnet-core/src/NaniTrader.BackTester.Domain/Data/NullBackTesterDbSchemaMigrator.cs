using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace NaniTrader.BackTester.Data;

/* This is used if database provider does't define
 * IBackTesterDbSchemaMigrator implementation.
 */
public class NullBackTesterDbSchemaMigrator : IBackTesterDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
