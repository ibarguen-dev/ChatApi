using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Models;

public partial class DbChatContext : DbContext
{
    public DbChatContext()
    {
    }

    public DbChatContext(DbContextOptions<DbChatContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Server> Servers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.IdChat).HasName("PK__Chat__8307BCB37FCDDC0F");

            entity.ToTable("Chat");

            entity.Property(e => e.IdChat).HasColumnName("idChat");
            entity.Property(e => e.Chat1)
                .HasColumnType("text")
                .HasColumnName("chat");
            entity.Property(e => e.IdServer).HasColumnName("idServer");
            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.HasOne(d => d.IdServerNavigation).WithMany(p => p.Chats)
                .HasForeignKey(d => d.IdServer)
                .HasConstraintName("FK__Chat__idServer__3C69FB99");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Chats)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Chat__idServer__3B75D760");
        });

        modelBuilder.Entity<Server>(entity =>
        {
            entity.HasKey(e => e.IdServer).HasName("PK__Server__1B7398A8174C3AB5");

            entity.ToTable("Server");

            entity.Property(e => e.IdServer).HasColumnName("idServer");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
            entity.Property(e => e.Photo)
                .HasColumnType("text")
                .HasColumnName("photo");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Users__3717C98288A6FBD1");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
