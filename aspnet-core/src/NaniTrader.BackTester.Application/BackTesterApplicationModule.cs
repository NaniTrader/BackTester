using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NaniTrader.BackTester.NSEWebScraper;
using Refit;
using System;
using System.Net.Http;
using System.Net;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Polly.Extensions.Http;
using Polly.Retry;
using Polly.Timeout;
using Polly;
using System.Net.Http.Headers;

namespace NaniTrader.BackTester;

[DependsOn(
    typeof(BackTesterDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(BackTesterApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class BackTesterApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<BackTesterApplicationModule>();
        });

        AsyncRetryPolicy<HttpResponseMessage> retryPolicy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .Or<TimeoutRejectedException>() // Thrown by Polly's TimeoutPolicy if the inner call gets timeout.
            .WaitAndRetryAsync(2, dp => TimeSpan.FromMilliseconds(500));

        AsyncTimeoutPolicy<HttpResponseMessage> timeoutPolicy = Policy
            .TimeoutAsync<HttpResponseMessage>(TimeSpan.FromMilliseconds(500));

        context.Services.AddRefitClient<INSEWebScraper>()
            .ConfigureHttpClient((sp, httpClient) =>
            {
                httpClient.BaseAddress = new Uri("https://www.nseindia.com");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
                httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
                httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
                httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en-US"));
                httpClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true };
            })
            .SetHandlerLifetime(TimeSpan.FromMinutes(5))
            .ConfigurePrimaryHttpMessageHandler(sp =>
            {
                HttpClientHandler handler = new HttpClientHandler();
                CookieContainer cookies = new CookieContainer();
                handler.CookieContainer = cookies;
                return handler;
            })
            .AddPolicyHandler(retryPolicy)
            .AddPolicyHandler(timeoutPolicy);
    }
}
