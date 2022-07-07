using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api_auction.Models
{
    public partial class JaspionDbContext : DbContext
    {
        public JaspionDbContext()
        {
        }

        public JaspionDbContext(DbContextOptions<JaspionDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAuctionFlow> TblAuctionFlow { get; set; }
        public virtual DbSet<TblOpportunity> TblOpportunity { get; set; }
        public virtual DbSet<TblRejectProposalsItem> TblRejectProposalsItem { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=" + Environment.GetEnvironmentVariable("DB_HOST") + ";Port=" + Environment.GetEnvironmentVariable("DB_PORT") + ";Database=" + Environment.GetEnvironmentVariable("DB_NAME") + ";Username=" + Environment.GetEnvironmentVariable("DB_USERNAME") +
                                         ";Password=" + Environment.GetEnvironmentVariable("DB_PASSWORD") + "");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pgcrypto")
                .HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<TblAuctionFlow>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_auction_flow", "auctions");

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("account");

                entity.Property(e => e.AltAuctionNumber)
                    .HasMaxLength(100)
                    .HasColumnName("alt_auction_number");

                entity.Property(e => e.AuctionConfig)
                    .HasColumnType("jsonb")
                    .HasColumnName("auction_config")
                    .HasDefaultValueSql("'[]'::jsonb");

                entity.Property(e => e.AuctionNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("auction_number");

                entity.Property(e => e.BuyerUnit)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("buyer_unit");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.LastUsernameModifier)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("last_username_modifier")
                    .HasDefaultValueSql("'robots@brasil317.com'::character varying");

                entity.Property(e => e.Portal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("portal")
                    .HasDefaultValueSql("'CN'::character varying");

                entity.Property(e => e.PublishAuctionStateInitials)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("publish_auction_state_initials");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("status_name")
                    .HasDefaultValueSql("'OPEN'::character varying");
            });

            modelBuilder.Entity<TblOpportunity>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_opportunity", "opportunity");

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("account");

                entity.Property(e => e.Answers)
                    .IsRequired()
                    .HasColumnType("json")
                    .HasColumnName("answers")
                    .HasDefaultValueSql("'[]'::json");

                entity.Property(e => e.AuctionDate).HasColumnName("auction_date");

                entity.Property(e => e.AuctionDescription)
                    .IsRequired()
                    .HasColumnName("auction_description");

                entity.Property(e => e.AuctionMode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("auction_mode");

                entity.Property(e => e.AuctionNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("auction_number");

                entity.Property(e => e.AuctionPropertiesOdin)
                    .IsRequired()
                    .HasColumnType("jsonb")
                    .HasColumnName("auction_properties_odin");

                entity.Property(e => e.AuctionType)
                    .HasMaxLength(100)
                    .HasColumnName("auction_type")
                    .HasDefaultValueSql("'open'::character varying");

                entity.Property(e => e.BuyerUnit)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("buyer_unit");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Declined).HasColumnName("declined");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.InitialTargetProposal)
                    .HasPrecision(0)
                    .HasColumnName("initial_target_proposal");

                entity.Property(e => e.ItemsOdin)
                    .IsRequired()
                    .HasColumnType("jsonb")
                    .HasColumnName("items_odin");

                entity.Property(e => e.Observatrion).HasColumnName("observatrion");

                entity.Property(e => e.Portal)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("portal");

                entity.Property(e => e.PublishDate).HasColumnName("publish_date");

                entity.Property(e => e.TargetClient).HasColumnName("target_client");

                entity.Property(e => e.TargetOperational).HasColumnName("target_operational");

                entity.Property(e => e.TargetProposal).HasColumnName("target_proposal");

                entity.Property(e => e.UpdateAt).HasColumnName("update_at");
            });

            modelBuilder.Entity<TblRejectProposalsItem>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_reject_proposals_items", "opportunity");

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("account");

                entity.Property(e => e.AuctionGroupNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("auction_group_number")
                    .HasDefaultValueSql("'NG'::character varying");

                entity.Property(e => e.AuctionItemNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("auction_item_number");

                entity.Property(e => e.AuctionNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("auction_number");

                entity.Property(e => e.BuyerUnit)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("buyer_unit");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Observation)
                    .IsRequired()
                    .HasColumnName("observation");

                entity.Property(e => e.Portal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("portal");

                entity.Property(e => e.RejectCategory)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("reject_category")
                    .HasDefaultValueSql("'OTHERS'::character varying");

                entity.Property(e => e.UserEmailReject)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("user_email_reject");

                entity.Property(e => e.WhoReject)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("who_reject")
                    .HasDefaultValueSql("'BRASIL317'::character varying");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_users", "users");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.DisabledAt).HasColumnName("disabled_at");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("email");

                entity.Property(e => e.Enabled)
                    .IsRequired()
                    .HasColumnName("enabled")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Identifier)
                    .HasColumnName("identifier")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Passwd)
                    .IsRequired()
                    .HasColumnName("passwd");

                entity.Property(e => e.PwdUpdatedAt)
                    .HasColumnName("pwd_updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ResetToken)
                    .HasMaxLength(255)
                    .HasColumnName("reset_token");

                entity.Property(e => e.Token)
                    .HasMaxLength(255)
                    .HasColumnName("token");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
