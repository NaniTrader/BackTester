using NaniTrader.BackTester.Samples;
using Xunit;

namespace NaniTrader.BackTester.EntityFrameworkCore.Applications;

[Collection(BackTesterTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<BackTesterEntityFrameworkCoreTestModule>
{

}
