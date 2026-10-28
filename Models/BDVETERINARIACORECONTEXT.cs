using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FinalWeb.Models;

public partial class BDVETERINARIACORECONTEXT : DbContext
{
    public BDVETERINARIACORECONTEXT()
    {
    }

    public BDVETERINARIACORECONTEXT(DbContextOptions<BDVETERINARIACORECONTEXT> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Mascota> Mascotas { get; set; }

    public virtual DbSet<Tratamiento> Tratamientos { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\BDveterinariaCore.mdf;Integrated Security=True");*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3214EC0749B291E4");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empleado__3214EC076AC58A78");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Cargo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Direccion ");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Mascotas__3214EC07EBC93834");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Animal)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Niup).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Peso)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Raza)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ClienteNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.Cliente)
                .HasConstraintName("FK_Mascotas_ToTable");

            entity.HasOne(d => d.TratamientoNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.Tratamiento)
                .HasConstraintName("FK_Mascotas_ToTable_1");

            entity.HasOne(d => d.VeterinarioNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.Veterinario)
                .HasConstraintName("FK_Mascotas_ToTable_2");
        });

        modelBuilder.Entity<Tratamiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tratamie__3214EC07819B8E0B");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descripción)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
