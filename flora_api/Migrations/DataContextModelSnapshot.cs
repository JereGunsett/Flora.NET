﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_flora.Data;

#nullable disable

namespace api_flora.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("api_flora.Entities.Categorias.Categoria", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("api_flora.Entities.Contacto.Contacto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Contactos");
                });

            modelBuilder.Entity("api_flora.Entities.Noticia.HipervinculoNoticia", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("NoticiaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Str")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("NoticiaId");

                    b.ToTable("HipervinculoNoticia");
                });

            modelBuilder.Entity("api_flora.Entities.Noticia.ImagenNoticia", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("NoticiaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Str")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("NoticiaId");

                    b.ToTable("ImagenNoticia");
                });

            modelBuilder.Entity("api_flora.Entities.Noticia.Noticia", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Cuerpo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Noticias");
                });

            modelBuilder.Entity("api_flora.Entities.Producto.Producto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<long?>("CategoriaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Precio")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("api_flora.Entities.Noticia.HipervinculoNoticia", b =>
                {
                    b.HasOne("api_flora.Entities.Noticia.Noticia", null)
                        .WithMany("Hipervinculos")
                        .HasForeignKey("NoticiaId");
                });

            modelBuilder.Entity("api_flora.Entities.Noticia.ImagenNoticia", b =>
                {
                    b.HasOne("api_flora.Entities.Noticia.Noticia", null)
                        .WithMany("Imagenes")
                        .HasForeignKey("NoticiaId");
                });

            modelBuilder.Entity("api_flora.Entities.Producto.Producto", b =>
                {
                    b.HasOne("api_flora.Entities.Categorias.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("api_flora.Entities.Noticia.Noticia", b =>
                {
                    b.Navigation("Hipervinculos");

                    b.Navigation("Imagenes");
                });
#pragma warning restore 612, 618
        }
    }
}
