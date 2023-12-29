using NaniTrader.BackTester.Samples;
using Xunit;

namespace NaniTrader.BackTester.EntityFrameworkCore.Domains;

[Collection(BackTesterTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<BackTesterEntityFrameworkCoreTestModule>
{

}
