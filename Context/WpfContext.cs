using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SteamDesktop.Models;

namespace SteamDesktop.Context;

public partial class WpfContext : DbContext
{
    public WpfContext()
    {
    }

    public WpfContext(DbContextOptions<WpfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Developer> Developers { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameCategory> GameCategories { get; set; }

    public virtual DbSet<GameDeveloper> GameDevelopers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("comment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GameId).HasColumnName("gameId");
            entity.Property(e => e.Text)
                .HasColumnType("text")
                .HasColumnName("text");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Game).WithMany(p => p.Comments)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_comment_game");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_comment_Users");
        });

        modelBuilder.Entity<Developer>(entity =>
        {
            entity.ToTable("developer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.ToTable("game");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<GameCategory>(entity =>
        {
            entity.ToTable("gameCategory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.GameId).HasColumnName("gameId");

            entity.HasOne(d => d.Category).WithMany(p => p.GameCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_gameCategory_category");

            entity.HasOne(d => d.Game).WithMany(p => p.GameCategories)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_gameCategory_game");
        });

        modelBuilder.Entity<GameDeveloper>(entity =>
        {
            entity.ToTable("gameDeveloper");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DeveloperId).HasColumnName("developerId");
            entity.Property(e => e.GameId).HasColumnName("gameId");

            entity.HasOne(d => d.Developer).WithMany(p => p.GameDevelopers)
                .HasForeignKey(d => d.DeveloperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_gameDeveloper_developer");

            entity.HasOne(d => d.Game).WithMany(p => p.GameDevelopers)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_gameDeveloper_game");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3213E83FC0F2A7CE");

            entity.ToTable("Role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83FA15CE3A6");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("fullName");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Photo)
                .HasColumnType("text")
                .HasColumnName("photo");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("userName");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
