using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace NaniTrader.BackTester;

[Dependency(ReplaceServices = true)]
public class BackTesterBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BackTester";
}
