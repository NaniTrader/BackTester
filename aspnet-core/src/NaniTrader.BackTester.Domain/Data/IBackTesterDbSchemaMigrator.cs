using System.Threading.Tasks;

namespace NaniTrader.BackTester.Data;

public interface IBackTesterDbSchemaMigrator
{
    Task MigrateAsync();
}
