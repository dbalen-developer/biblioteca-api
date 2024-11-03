﻿// <auto-generated />
using Biblioteca.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biblioteca.Infrastructure.Migrations
{
    [DbContext(typeof(BibliotecaDbContext))]
    partial class BibliotecaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Biblioteca.Domain.Entities.Assunto", b =>
                {
                    b.Property<int>("CodAs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodAs"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("CodAs");

                    b.ToTable("Assunto");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Autor", b =>
                {
                    b.Property<int>("CodAu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodAu"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(40)");

                    b.HasKey("CodAu");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.FormaCompra", b =>
                {
                    b.Property<int>("CodFo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodFo"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.HasKey("CodFo");

                    b.ToTable("FormaCompra");

                    b.HasData(
                        new
                        {
                            CodFo = 1,
                            Descricao = "Balcão"
                        },
                        new
                        {
                            CodFo = 2,
                            Descricao = "Self-Service"
                        },
                        new
                        {
                            CodFo = 3,
                            Descricao = "Internet"
                        },
                        new
                        {
                            CodFo = 4,
                            Descricao = "Evento"
                        });
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Livro", b =>
                {
                    b.Property<int>("Codl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codl"));

                    b.Property<string>("AnoPublicacao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(4)");

                    b.Property<int>("Edicao")
                        .HasColumnType("int");

                    b.Property<string>("Editora")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(40)");

                    b.HasKey("Codl");

                    b.ToTable("Livro");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Livro_Assunto", b =>
                {
                    b.Property<int>("Livro_Codl")
                        .HasColumnType("int");

                    b.Property<int>("Assunto_CodAs")
                        .HasColumnType("int");

                    b.HasKey("Livro_Codl", "Assunto_CodAs");

                    b.HasIndex("Assunto_CodAs");

                    b.ToTable("Livro_Assunto");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Livro_Autor", b =>
                {
                    b.Property<int>("Livro_Codl")
                        .HasColumnType("int");

                    b.Property<int>("Autor_CodAu")
                        .HasColumnType("int");

                    b.HasKey("Livro_Codl", "Autor_CodAu");

                    b.HasIndex("Autor_CodAu");

                    b.ToTable("Livro_Autor");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Livro_FormaCompra", b =>
                {
                    b.Property<int>("LivroCodL")
                        .HasColumnType("int");

                    b.Property<int>("FormaCompra_CodFo")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasColumnType("DECIMAL(18,2)");

                    b.HasKey("LivroCodL", "FormaCompra_CodFo");

                    b.HasIndex("FormaCompra_CodFo");

                    b.ToTable("Livro_FormaCompra");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Livro_Assunto", b =>
                {
                    b.HasOne("Biblioteca.Domain.Entities.Assunto", "Assunto")
                        .WithMany("Livro_Assuntos")
                        .HasForeignKey("Assunto_CodAs")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Biblioteca.Domain.Entities.Livro", "Livro")
                        .WithMany("Livro_Assuntos")
                        .HasForeignKey("Livro_Codl")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Assunto");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Livro_Autor", b =>
                {
                    b.HasOne("Biblioteca.Domain.Entities.Autor", "Autor")
                        .WithMany("Livro_Autores")
                        .HasForeignKey("Autor_CodAu")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Biblioteca.Domain.Entities.Livro", "Livro")
                        .WithMany("Livro_Autores")
                        .HasForeignKey("Livro_Codl")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Livro_FormaCompra", b =>
                {
                    b.HasOne("Biblioteca.Domain.Entities.FormaCompra", "FormaCompra")
                        .WithMany("Livro_FormaCompras")
                        .HasForeignKey("FormaCompra_CodFo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Biblioteca.Domain.Entities.Livro", "Livro")
                        .WithMany("Livro_FormaCompras")
                        .HasForeignKey("LivroCodL")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FormaCompra");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Assunto", b =>
                {
                    b.Navigation("Livro_Assuntos");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Autor", b =>
                {
                    b.Navigation("Livro_Autores");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.FormaCompra", b =>
                {
                    b.Navigation("Livro_FormaCompras");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Livro", b =>
                {
                    b.Navigation("Livro_Assuntos");

                    b.Navigation("Livro_Autores");

                    b.Navigation("Livro_FormaCompras");
                });
#pragma warning restore 612, 618
        }
    }
}
