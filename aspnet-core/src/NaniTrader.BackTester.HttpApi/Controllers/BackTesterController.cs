using NaniTrader.BackTester.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace NaniTrader.BackTester.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BackTesterController : AbpControllerBase
{
    protected BackTesterController()
    {
        LocalizationResource = typeof(BackTesterResource);
    }
}
