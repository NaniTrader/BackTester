using NaniTrader.BackTester.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace NaniTrader.BackTester.Permissions;

public class BackTesterPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BackTesterPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BackTesterPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BackTesterResource>(name);
    }
}
