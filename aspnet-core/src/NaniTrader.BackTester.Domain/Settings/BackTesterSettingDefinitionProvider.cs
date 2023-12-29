using Volo.Abp.Settings;

namespace NaniTrader.BackTester.Settings;

public class BackTesterSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BackTesterSettings.MySetting1));
    }
}
