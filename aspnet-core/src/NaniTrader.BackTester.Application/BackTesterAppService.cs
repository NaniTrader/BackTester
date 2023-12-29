using System;
using System.Collections.Generic;
using System.Text;
using NaniTrader.BackTester.Localization;
using Volo.Abp.Application.Services;

namespace NaniTrader.BackTester;

/* Inherit your application services from this class.
 */
public abstract class BackTesterAppService : ApplicationService
{
    protected BackTesterAppService()
    {
        LocalizationResource = typeof(BackTesterResource);
    }
}
