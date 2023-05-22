using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace receptek_backend.Models;

public partial class ReceptContext : DbContext
{
    public ReceptContext()
    {
    }

    public ReceptContext(DbContextOptions<ReceptContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kategoriak> Kategoriaks { get; set; }

    public virtual DbSet<Receptek> Recepteks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=recept;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kategoriak>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__kategori__3213E83F6968877E");

            entity.ToTable("kategoriak");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nev)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nev");
        });

        modelBuilder.Entity<Receptek>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__receptek__3213E83FB8ED4774");

            entity.ToTable("receptek");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.KatId).HasColumnName("kat_id");
            entity.Property(e => e.KepEleresiUt)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("kep_eleresi_ut");
            entity.Property(e => e.Leiras)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("leiras");
            entity.Property(e => e.Nev)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nev");

            entity.HasOne(d => d.Kat).WithMany(p => p.Recepteks)
                .HasForeignKey(d => d.KatId)
                .HasConstraintName("FK__receptek__leiras__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
