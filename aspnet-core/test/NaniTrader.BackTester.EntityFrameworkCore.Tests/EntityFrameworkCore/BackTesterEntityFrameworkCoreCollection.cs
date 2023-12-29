using Xunit;

namespace NaniTrader.BackTester.EntityFrameworkCore;

[CollectionDefinition(BackTesterTestConsts.CollectionDefinitionName)]
public class BackTesterEntityFrameworkCoreCollection : ICollectionFixture<BackTesterEntityFrameworkCoreFixture>
{

}
