using Microsoft.EntityFrameworkCore;
using NaniTrader.BackTester.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace NaniTrader.BackTester.EntityFrameworkCore
{
    internal static class BackTesterDbContextModelCreatingExtensions
    {
        public static void ConfigureBackTester(this ModelBuilder builder, BackTesterDbContext backTesterDbContext)
        {
            builder.Entity<Country>(b =>
            {
                b.ToTable(BackTesterConsts.DbTablePrefix + nameof(backTesterDbContext.Countries), BackTesterConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(CountryConsts.MaxNameLength);
            });
        }

        public static void ConfigureBackTesterExchanges(this ModelBuilder builder, BackTesterDbContext backTesterDbContext)
        {
            builder.Entity<Exchanges.Exchange>(b =>
            {
                b.ToTable(BackTesterConsts.DbTablePrefix + nameof(backTesterDbContext.Exchanges), BackTesterConsts.DbSchemaExch);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxNameLength);
                b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxDescriptionLength);
            });

            builder.Entity<Exchanges.Securities.EquitySecurity>(b =>
            {
                b.ToTable(BackTesterConsts.DbTablePrefix + nameof(backTesterDbContext.ExchangeEquitySecurities), BackTesterConsts.DbSchemaExch);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxNameLength);
                b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxDescriptionLength);
                b.Property(x => x.ISIN).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxISINLength);
                b.Property(x => x.TickerSymbol).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxTickerSymbolLength);
            });

            builder.Entity<Exchanges.Securities.EquityFutureSecurity>(b =>
            {
                b.ToTable(BackTesterConsts.DbTablePrefix + nameof(backTesterDbContext.ExchangeEquityFutureSecurities), BackTesterConsts.DbSchemaExch);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxNameLength);
                b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxDescriptionLength);
            });

            builder.Entity<Exchanges.Securities.EquityOptionSecurity>(b =>
            {
                b.ToTable(BackTesterConsts.DbTablePrefix + nameof(backTesterDbContext.ExchangeEquityOptionSecurities), BackTesterConsts.DbSchemaExch);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxNameLength);
                b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxDescriptionLength);
            });

            builder.Entity<Exchanges.Securities.IndexSecurity>(b =>
            {
                b.ToTable(BackTesterConsts.DbTablePrefix + nameof(backTesterDbContext.ExchangeIndexSecurities), BackTesterConsts.DbSchemaExch);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxNameLength);
                b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxDescriptionLength);
            });

            builder.Entity<Exchanges.Securities.IndexFutureSecurity>(b =>
            {
                b.ToTable(BackTesterConsts.DbTablePrefix + nameof(backTesterDbContext.ExchangeIndexFutureSecurities), BackTesterConsts.DbSchemaExch);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxNameLength);
                b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxDescriptionLength);
            });

            builder.Entity<Exchanges.Securities.IndexOptionSecurity>(b =>
            {
                b.ToTable(BackTesterConsts.DbTablePrefix + nameof(backTesterDbContext.ExchangeIndexOptionSecurities), BackTesterConsts.DbSchemaExch);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxNameLength);
                b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.Exchanges.ExchangeConsts.MaxDescriptionLength);
            });
        }

        public static void ConfigureBackTesterMarketDataProviders(this ModelBuilder builder, BackTesterDbContext backTesterDbContext)
        {
            builder.Entity<MarketDataProviders.MarketDataProvider>(b =>
            {
                b.ToTable(BackTesterConsts.DbTablePrefix + nameof(backTesterDbContext.MarketDataProviders), BackTesterConsts.DbSchemaMDP);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxNameLength);
                b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxDescriptionLength);
            });

            builder.Entity<MarketDataProviders.Securities.EquitySecurity>(b =>
            {
                b.ToTable(BackTesterConsts.DbTablePrefix + nameof(backTesterDbContext.MarketDataProviderEquitySecurities), BackTesterConsts.DbSchemaMDP);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxNameLength);
                b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxDescriptionLength);
            });

            builder.Entity<MarketDataProviders.Securities.EquityFutureSecurity>(b =>
            {
                b.ToTable(BackTesterConsts.DbTablePrefix + nameof(backTesterDbContext.MarketDataProviderEquityFutureSecurities), BackTesterConsts.DbSchemaMDP);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxNameLength);
                b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxDescriptionLength);
            });

            builder.Entity<MarketDataProviders.Securities.EquityOptionSecurity>(b =>
            {
                b.ToTable(BackTesterConsts.DbTablePrefix + nameof(backTesterDbContext.MarketDataProviderEquityOptionSecurities), BackTesterConsts.DbSchemaMDP);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxNameLength);
                b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxDescriptionLength);
            });

            builder.Entity<MarketDataProviders.Securities.IndexSecurity>(b =>
            {
                b.ToTable(BackTesterConsts.DbTablePrefix + nameof(backTesterDbContext.MarketDataProviderIndexSecurities), BackTesterConsts.DbSchemaMDP);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxNameLength);
                b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxDescriptionLength);
            });

            builder.Entity<MarketDataProviders.Securities.IndexFutureSecurity>(b =>
            {
                b.ToTable(BackTesterConsts.DbTablePrefix + nameof(backTesterDbContext.MarketDataProviderIndexFutureSecurities), BackTesterConsts.DbSchemaMDP);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxNameLength);
                b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxDescriptionLength);
            });

            builder.Entity<MarketDataProviders.Securities.IndexOptionSecurity>(b =>
            {
                b.ToTable(BackTesterConsts.DbTablePrefix + nameof(backTesterDbContext.MarketDataProviderIndexOptionSecurities), BackTesterConsts.DbSchemaMDP);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxNameLength);
                b.Property(x => x.Description).IsRequired().HasMaxLength(BackTester.MarketDataProviders.MarketDataProviderConsts.MaxDescriptionLength);
            });
        }

        public static void ConfigureBackTesterNavigations(this ModelBuilder builder)
        {
            builder.Entity<Exchanges.Securities.EquitySecurity>(b =>
            {
                b.HasOne(e => e.Exchange).WithMany(e => e.EquitySecurities).HasForeignKey("ExchangeId").IsRequired().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Exchanges.Securities.EquityFutureSecurity>(b =>
            {
                b.HasOne(e => e.Exchange).WithMany(e => e.EquityFutureSecurities).HasForeignKey("ExchangeId").IsRequired().OnDelete(DeleteBehavior.NoAction);
                b.HasOne(e => e.Underlying).WithMany(e => e.Futures).HasForeignKey("UnderlyingId").IsRequired().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Exchanges.Securities.EquityOptionSecurity>(b =>
            {
                b.HasOne(e => e.Exchange).WithMany(e => e.EquityOptionSecurities).HasForeignKey("ExchangeId").IsRequired().OnDelete(DeleteBehavior.NoAction);
                b.HasOne(e => e.Underlying).WithMany(e => e.Options).HasForeignKey("UnderlyingId").IsRequired().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Exchanges.Securities.IndexSecurity>(b =>
            {
                b.HasOne(e => e.Exchange).WithMany(e => e.IndexSecurities).HasForeignKey("ExchangeId").IsRequired().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Exchanges.Securities.IndexFutureSecurity>(b =>
            {
                b.HasOne(e => e.Exchange).WithMany(e => e.IndexFutureSecurities).HasForeignKey("ExchangeId").IsRequired().OnDelete(DeleteBehavior.NoAction);
                b.HasOne(e => e.Underlying).WithMany(e => e.Futures).HasForeignKey("UnderlyingId").IsRequired().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Exchanges.Securities.IndexOptionSecurity>(b =>
            {
                b.HasOne(e => e.Exchange).WithMany(e => e.IndexOptionSecurities).HasForeignKey("ExchangeId").IsRequired().OnDelete(DeleteBehavior.NoAction);
                b.HasOne(e => e.Underlying).WithMany(e => e.Options).HasForeignKey("UnderlyingId").IsRequired().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<MarketDataProviders.Securities.EquitySecurity>(b =>
            {
                b.HasOne(e => e.MarketDataProvider).WithMany(e => e.EquitySecurities).HasForeignKey("MarketDataProviderId").IsRequired().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<MarketDataProviders.Securities.EquityFutureSecurity>(b =>
            {
                b.HasOne(e => e.MarketDataProvider).WithMany(e => e.EquityFutureSecurities).HasForeignKey("MarketDataProviderId").IsRequired().OnDelete(DeleteBehavior.NoAction);
                b.HasOne(e => e.Underlying).WithMany(e => e.Futures).HasForeignKey("UnderlyingId").IsRequired().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<MarketDataProviders.Securities.EquityOptionSecurity>(b =>
            {
                b.HasOne(e => e.MarketDataProvider).WithMany(e => e.EquityOptionSecurities).HasForeignKey("MarketDataProviderId").IsRequired().OnDelete(DeleteBehavior.NoAction);
                b.HasOne(e => e.Underlying).WithMany(e => e.Options).HasForeignKey("UnderlyingId").IsRequired().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<MarketDataProviders.Securities.IndexSecurity>(b =>
            {
                b.HasOne(e => e.MarketDataProvider).WithMany(e => e.IndexSecurities).HasForeignKey("MarketDataProviderId").IsRequired().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<MarketDataProviders.Securities.IndexFutureSecurity>(b =>
            {
                b.HasOne(e => e.MarketDataProvider).WithMany(e => e.IndexFutureSecurities).HasForeignKey("MarketDataProviderId").IsRequired().OnDelete(DeleteBehavior.NoAction);
                b.HasOne(e => e.Underlying).WithMany(e => e.Futures).HasForeignKey("UnderlyingId").IsRequired().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<MarketDataProviders.Securities.IndexOptionSecurity>(b =>
            {
                b.HasOne(e => e.MarketDataProvider).WithMany(e => e.IndexOptionSecurities).HasForeignKey("MarketDataProviderId").IsRequired().OnDelete(DeleteBehavior.NoAction);
                b.HasOne(e => e.Underlying).WithMany(e => e.Options).HasForeignKey("UnderlyingId").IsRequired().OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
