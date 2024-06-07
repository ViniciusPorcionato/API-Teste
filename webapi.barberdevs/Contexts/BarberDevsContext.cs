using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.barberdevs.Domains;

namespace webapi.barberdevs.Contexts;

public partial class BarberDevsContext : DbContext
{
    public BarberDevsContext()
    {
    }

    public BarberDevsContext(DbContextOptions<BarberDevsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agendamento> Agendamentos { get; set; }

    public virtual DbSet<Barbearium> Barbearia { get; set; }

    public virtual DbSet<Barbeiro> Barbeiros { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-RIHPD9E\\SQLEXPRESS; initial catalog=BarberDevs; User Id = sa; pwd = senhavinip140805; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agendamento>(entity =>
        {
            entity.HasKey(e => e.IdAgendamento).HasName("PK__Agendame__DC0823C9B74F7BB2");

            entity.ToTable("Agendamento");

            entity.Property(e => e.IdAgendamento).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DataAgendamento).HasColumnType("datetime");

            entity.HasOne(d => d.IdBarbeiroNavigation).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.IdBarbeiro)
                .HasConstraintName("FK__Agendamen__IdBar__5DCAEF64");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Agendamen__IdCli__5EBF139D");
        });

        modelBuilder.Entity<Barbearium>(entity =>
        {
            entity.HasKey(e => e.IdBarbearia).HasName("PK__Barbeari__05AE5EFF422D7607");

            entity.Property(e => e.IdBarbearia).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Bairro)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cep)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cnpj)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CNPJ");
            entity.Property(e => e.Latitude).HasColumnType("decimal(8, 6)");
            entity.Property(e => e.Logradouro)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.NomeFantasia)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Barbeiro>(entity =>
        {
            entity.HasKey(e => e.IdBarbeiro).HasName("PK__Barbeiro__E29F357CDF398A5B");

            entity.ToTable("Barbeiro");

            entity.Property(e => e.IdBarbeiro).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Descricao).HasColumnType("text");

            entity.HasOne(d => d.IdBarbeariaNavigation).WithMany(p => p.Barbeiros)
                .HasForeignKey(d => d.IdBarbearia)
                .HasConstraintName("FK__Barbeiro__IdBarb__5629CD9C");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Barbeiros)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Barbeiro__IdUsua__5535A963");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__D5946642F0AF9427");

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Cliente__IdUsuar__59FA5E80");
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoUsuario).HasName("PK__TipoUsua__CA04062B2736B868");

            entity.ToTable("TipoUsuario");

            entity.Property(e => e.IdTipoUsuario).HasDefaultValueSql("(newid())");
            entity.Property(e => e.NomeTipoUsuario)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97DA3D61D7");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534A82DDF67").IsUnique();

            entity.Property(e => e.IdUsuario).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Cpf)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Foto).HasColumnType("text");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Rg)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipoUsuario)
                .HasConstraintName("FK__Usuario__IdTipoU__5165187F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
