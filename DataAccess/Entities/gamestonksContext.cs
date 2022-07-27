using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Entities
{
    public partial class gamestonksContext : DbContext
    {
        public gamestonksContext()
        {
        }

        public gamestonksContext(DbContextOptions<gamestonksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Currency> Currencies { get; set; } = null!;
        public virtual DbSet<Profile> Profiles { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Wallet> Wallets { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("Currency");

                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");

                entity.Property(e => e.CurrencyCurrentPrice)
                    .HasColumnType("decimal(15, 15)")
                    .HasColumnName("currency_current_price");

                entity.Property(e => e.CurrencySymbol)
                    .HasMaxLength(10)
                    .HasColumnName("currency_symbol");

                entity.Property(e => e.CurrencyTime)
                    .HasColumnType("datetime")
                    .HasColumnName("currency_time");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.UserIdFk).HasColumnName("user_id_fk");

                entity.HasOne(d => d.UserIdFkNavigation)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.UserIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Profiles__user_i__71D1E811");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

                entity.Property(e => e.CurrencyIdFk).HasColumnName("currency_id_fk");

                entity.Property(e => e.TransactionTime)
                    .HasColumnType("datetime")
                    .HasColumnName("transaction_time")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(4)
                    .HasColumnName("transaction_type");

                entity.Property(e => e.TransactionValue)
                    .HasColumnType("decimal(15, 15)")
                    .HasColumnName("transaction_value");

                entity.Property(e => e.WalletIdFk).HasColumnName("wallet_id_fk");

                entity.HasOne(d => d.CurrencyIdFkNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.CurrencyIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__curre__25518C17");

                entity.HasOne(d => d.WalletIdFkNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.WalletIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__walle__245D67DE");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__AB6E61649ED387D0")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.Property(e => e.WalletId).HasColumnName("wallet_id");

                entity.Property(e => e.AmountCurrency)
                    .HasColumnType("decimal(15, 15)")
                    .HasColumnName("amount_currency");

                entity.Property(e => e.CurrencyIdFk).HasColumnName("currency_id_fk");

                entity.Property(e => e.UserIdFk).HasColumnName("user_id_fk");

                entity.HasOne(d => d.CurrencyIdFkNavigation)
                    .WithMany(p => p.Wallets)
                    .HasForeignKey(d => d.CurrencyIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Wallets__currenc__778AC167");

                entity.HasOne(d => d.UserIdFkNavigation)
                    .WithMany(p => p.Wallets)
                    .HasForeignKey(d => d.UserIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Wallets__user_id__76969D2E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
