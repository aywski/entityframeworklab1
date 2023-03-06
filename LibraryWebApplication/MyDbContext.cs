using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApplication;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Mode> Modes { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= DESKTOP-DUE0M8T\\SQLEXPRESS; Database=myDB; Trusted_Connection=True; Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Games_1");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.GameCreationDate).HasColumnType("date");
            entity.Property(e => e.GameId).ValueGeneratedOnAdd();
            entity.Property(e => e.GameLogo).HasColumnType("image");
            entity.Property(e => e.GameName).HasMaxLength(50);

            entity.HasOne(d => d.GamePriceNavigation).WithMany(p => p.Games)
                .HasForeignKey(d => d.GamePrice)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Games_Prices");

            entity.HasOne(d => d.GamePublisherNavigation).WithMany(p => p.Games)
                .HasForeignKey(d => d.GamePublisher)
                .HasConstraintName("FK_Games_Publishers");

            entity.HasOne(d => d.GameTagsNavigation).WithMany(p => p.Games)
                .HasForeignKey(d => d.GameTags)
                .HasConstraintName("FK_Games_Tags");
        });

        modelBuilder.Entity<Mode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Modes_1");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ModeId).HasColumnName("ModeID");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.PriceInEur)
                .HasColumnType("money")
                .HasColumnName("PriceInEUR");
            entity.Property(e => e.PriceInUah)
                .HasColumnType("money")
                .HasColumnName("PriceInUAH");
            entity.Property(e => e.PriceInUsd)
                .HasColumnType("money")
                .HasColumnName("PriceInUSD");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Publishers_1");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.PublisherName).HasMaxLength(50);
            entity.Property(e => e.PublisherReview).HasMaxLength(50);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TagId).ValueGeneratedOnAdd();
            entity.Property(e => e.TagRpg).HasColumnName("TagRPG");

            entity.HasOne(d => d.TagModeNavigation).WithMany(p => p.Tags)
                .HasForeignKey(d => d.TagMode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tags_Modes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
