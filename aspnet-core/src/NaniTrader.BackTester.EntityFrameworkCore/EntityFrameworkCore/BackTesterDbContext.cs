using Microsoft.EntityFrameworkCore;
using NaniTrader.BackTester.Exchanges;
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

    public DbSet<Exchange> Exchanges { get; set; }
    public DbSet<EquitySecurity> EquitySecurities { get; set; }
    public DbSet<EquityFutureSecurity> EquityFutureSecurities { get; set; }
    public DbSet<EquityOptionSecurity> EquityOptionSecurities { get; set; }
    public DbSet<IndexSecurity> IndexSecurities { get; set; }
    public DbSet<IndexFutureSecurity> IndexFutureSecurities { get; set; }
    public DbSet<IndexOptionSecurity> IndexOptionSecurities { get; set; }

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

        builder.Entity<Exchange>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(Exchanges), BackTesterConsts.DbSchemaExch);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(ExchangeConsts.MaxNameLength);
            b.Property(x => x.Description).IsRequired().HasMaxLength(ExchangeConsts.MaxDescriptionLength);
            b.HasMany(e => e.EquitySecurities).WithOne(e => e.Exchange).HasForeignKey(e => e.ExchangeId).IsRequired();
            b.HasMany(e => e.EquityFutureSecurities).WithOne(e => e.Exchange).HasForeignKey(e => e.ExchangeId).IsRequired();
            b.HasMany(e => e.EquityOptionSecurities).WithOne(e => e.Exchange).HasForeignKey(e => e.ExchangeId).IsRequired();
            b.HasMany(e => e.IndexSecurities).WithOne(e => e.Exchange).HasForeignKey(e => e.ExchangeId).IsRequired();
            b.HasMany(e => e.IndexFutureSecurities).WithOne(e => e.Exchange).HasForeignKey(e => e.ExchangeId).IsRequired();
            b.HasMany(e => e.IndexOptionSecurities).WithOne(e => e.Exchange).HasForeignKey(e => e.ExchangeId).IsRequired();
        });

        builder.Entity<EquitySecurity>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(EquitySecurities), BackTesterConsts.DbSchemaExch);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(ExchangeConsts.MaxNameLength);
            b.Property(x => x.Description).IsRequired().HasMaxLength(ExchangeConsts.MaxDescriptionLength);
            b.Property(x => x.ISIN).IsRequired().HasMaxLength(ExchangeConsts.MaxISINLength);
            b.Property(x => x.TickerSymbol).IsRequired().HasMaxLength(ExchangeConsts.MaxTickerSymbolLength);
        });

        builder.Entity<EquityFutureSecurity>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(EquityFutureSecurities), BackTesterConsts.DbSchemaExch);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(ExchangeConsts.MaxNameLength);
            b.Property(x => x.Description).IsRequired().HasMaxLength(ExchangeConsts.MaxDescriptionLength);
        });

        builder.Entity<EquityOptionSecurity>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(EquityOptionSecurities), BackTesterConsts.DbSchemaExch);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(ExchangeConsts.MaxNameLength);
            b.Property(x => x.Description).IsRequired().HasMaxLength(ExchangeConsts.MaxDescriptionLength);
        });

        builder.Entity<IndexSecurity>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(IndexSecurities), BackTesterConsts.DbSchemaExch);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(ExchangeConsts.MaxNameLength);
            b.Property(x => x.Description).IsRequired().HasMaxLength(ExchangeConsts.MaxDescriptionLength);
        });

        builder.Entity<IndexFutureSecurity>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(IndexFutureSecurities), BackTesterConsts.DbSchemaExch);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(ExchangeConsts.MaxNameLength);
            b.Property(x => x.Description).IsRequired().HasMaxLength(ExchangeConsts.MaxDescriptionLength);
        });

        builder.Entity<IndexOptionSecurity>(b =>
        {
            b.ToTable(BackTesterConsts.DbTablePrefix + nameof(IndexOptionSecurities), BackTesterConsts.DbSchemaExch);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(ExchangeConsts.MaxNameLength);
            b.Property(x => x.Description).IsRequired().HasMaxLength(ExchangeConsts.MaxDescriptionLength);
        });
    }
}
