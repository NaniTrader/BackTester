using Microsoft.EntityFrameworkCore;
using NaniTrader.BackTester.Countries;
using NaniTrader.BackTester.Exchanges.Securities;
using NaniTrader.BackTester.MarketDataProviders.Securities;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace NaniTrader.BackTester.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class BackTesterDbContext :
    AbpDbContext<BackTesterDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    public DbSet<Exchanges.Exchange> Exchanges { get; set; }
    public DbSet<Exchanges.Securities.EquitySecurity> ExchangeEquitySecurities { get; set; }
    public DbSet<Exchanges.Securities.EquityFutureSecurity> ExchangeEquityFutureSecurities { get; set; }
    public DbSet<Exchanges.Securities.EquityOptionSecurity> ExchangeEquityOptionSecurities { get; set; }
    public DbSet<Exchanges.Securities.IndexSecurity> ExchangeIndexSecurities { get; set; }
    public DbSet<Exchanges.Securities.IndexFutureSecurity> ExchangeIndexFutureSecurities { get; set; }
    public DbSet<Exchanges.Securities.IndexOptionSecurity> ExchangeIndexOptionSecurities { get; set; }
    public DbSet<MarketDataProviders.MarketDataProvider> MarketDataProviders { get; set; }
    public DbSet<MarketDataProviders.Securities.EquitySecurity> MarketDataProviderEquitySecurities { get; set; }
    public DbSet<MarketDataProviders.Securities.EquityFutureSecurity> MarketDataProviderEquityFutureSecurities { get; set; }
    public DbSet<MarketDataProviders.Securities.EquityOptionSecurity> MarketDataProviderEquityOptionSecurities { get; set; }
    public DbSet<MarketDataProviders.Securities.IndexSecurity> MarketDataProviderIndexSecurities { get; set; }
    public DbSet<MarketDataProviders.Securities.IndexFutureSecurity> MarketDataProviderIndexFutureSecurities { get; set; }
    public DbSet<MarketDataProviders.Securities.IndexOptionSecurity> MarketDataProviderIndexOptionSecurities { get; set; }
    public DbSet<Country> Countries { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public BackTesterDbContext(DbContextOptions<BackTesterDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        builder.Entity<Exchanges.Exchange>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(Exchanges), BackTesterConsts.DbSchemaExch);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxNameLength);
            b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxDescriptionLength);
            b.HasMany(e => e.EquitySecurities).WithOne(e => e.Exchange).HasForeignKey(e => e.ExchangeId).IsRequired();
            b.HasMany(e => e.EquityFutureSecurities).WithOne(e => e.Exchange).HasForeignKey(e => e.ExchangeId).IsRequired();
            b.HasMany(e => e.EquityOptionSecurities).WithOne(e => e.Exchange).HasForeignKey(e => e.ExchangeId).IsRequired();
            b.HasMany(e => e.IndexSecurities).WithOne(e => e.Exchange).HasForeignKey(e => e.ExchangeId).IsRequired();
            b.HasMany(e => e.IndexFutureSecurities).WithOne(e => e.Exchange).HasForeignKey(e => e.ExchangeId).IsRequired();
            b.HasMany(e => e.IndexOptionSecurities).WithOne(e => e.Exchange).HasForeignKey(e => e.ExchangeId).IsRequired();
        });

        builder.Entity<Exchanges.Securities.EquitySecurity>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(ExchangeEquitySecurities), BackTesterConsts.DbSchemaExch);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxNameLength);
            b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxDescriptionLength);
            b.Property(x => x.ISIN).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxISINLength);
            b.Property(x => x.TickerSymbol).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxTickerSymbolLength);
        });

        builder.Entity<Exchanges.Securities.EquityFutureSecurity>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(ExchangeEquityFutureSecurities), BackTesterConsts.DbSchemaExch);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxNameLength);
            b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxDescriptionLength);
        });

        builder.Entity<Exchanges.Securities.EquityOptionSecurity>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(ExchangeEquityOptionSecurities), BackTesterConsts.DbSchemaExch);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxNameLength);
            b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxDescriptionLength);
        });

        builder.Entity<Exchanges.Securities.IndexSecurity>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(ExchangeIndexSecurities), BackTesterConsts.DbSchemaExch);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxNameLength);
            b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxDescriptionLength);
        });

        builder.Entity<Exchanges.Securities.IndexFutureSecurity>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(ExchangeIndexFutureSecurities), BackTesterConsts.DbSchemaExch);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxNameLength);
            b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxDescriptionLength);
        });

        builder.Entity<Exchanges.Securities.IndexOptionSecurity>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(ExchangeIndexOptionSecurities), BackTesterConsts.DbSchemaExch);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxNameLength);
            b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxDescriptionLength);
        });

        builder.Entity<Country>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(Countries), BackTesterConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(CountryConsts.MaxNameLength);
        });

        builder.Entity<MarketDataProviders.MarketDataProvider>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(MarketDataProviders), BackTesterConsts.DbSchemaMDP);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxNameLength);
            b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxDescriptionLength);
            b.HasMany(e => e.EquitySecurities).WithOne(e => e.MarketDataProvider).HasForeignKey(e => e.MarketDataProviderId).IsRequired();
            b.HasMany(e => e.EquityFutureSecurities).WithOne(e => e.MarketDataProvider).HasForeignKey(e => e.MarketDataProviderId).IsRequired();
            b.HasMany(e => e.EquityOptionSecurities).WithOne(e => e.MarketDataProvider).HasForeignKey(e => e.MarketDataProviderId).IsRequired();
            b.HasMany(e => e.IndexSecurities).WithOne(e => e.MarketDataProvider).HasForeignKey(e => e.MarketDataProviderId).IsRequired();
            b.HasMany(e => e.IndexFutureSecurities).WithOne(e => e.MarketDataProvider).HasForeignKey(e => e.MarketDataProviderId).IsRequired();
            b.HasMany(e => e.IndexOptionSecurities).WithOne(e => e.MarketDataProvider).HasForeignKey(e => e.MarketDataProviderId).IsRequired();
        });

        builder.Entity<MarketDataProviders.Securities.EquitySecurity>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(MarketDataProviderEquitySecurities), BackTesterConsts.DbSchemaMDP);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxNameLength);
            b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxDescriptionLength);
            b.Property(x => x.ISIN).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxISINLength);
            b.Property(x => x.TickerSymbol).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxTickerSymbolLength);
        });

        builder.Entity<MarketDataProviders.Securities.EquityFutureSecurity>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(MarketDataProviderEquityFutureSecurities), BackTesterConsts.DbSchemaMDP);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxNameLength);
            b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxDescriptionLength);
        });

        builder.Entity<MarketDataProviders.Securities.EquityOptionSecurity>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(MarketDataProviderEquityOptionSecurities), BackTesterConsts.DbSchemaMDP);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxNameLength);
            b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxDescriptionLength);
        });

        builder.Entity<MarketDataProviders.Securities.IndexSecurity>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(MarketDataProviderIndexSecurities), BackTesterConsts.DbSchemaMDP);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxNameLength);
            b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxDescriptionLength);
        });

        builder.Entity<MarketDataProviders.Securities.IndexFutureSecurity>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(MarketDataProviderIndexFutureSecurities), BackTesterConsts.DbSchemaMDP);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxNameLength);
            b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxDescriptionLength);
        });

        builder.Entity<MarketDataProviders.Securities.IndexOptionSecurity>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(MarketDataProviderIndexOptionSecurities), BackTesterConsts.DbSchemaMDP);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxNameLength);
            b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxDescriptionLength);
        });
    }
}
