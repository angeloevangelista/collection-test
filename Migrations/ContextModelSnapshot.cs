﻿// <auto-generated />
using CollectionTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CollectionTest.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CollectionTest.Entities.Apelido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Conteudo")
                        .HasColumnType("TEXT");

                    b.Property<int>("HumanoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("HumanoId");

                    b.ToTable("Apelidos");
                });

            modelBuilder.Entity("CollectionTest.Entities.Humano", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Humanos");
                });

            modelBuilder.Entity("CollectionTest.Entities.Apelido", b =>
                {
                    b.HasOne("CollectionTest.Entities.Humano", "Humano")
                        .WithMany("Apelidos")
                        .HasForeignKey("HumanoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Humano");
                });

            modelBuilder.Entity("CollectionTest.Entities.Humano", b =>
                {
                    b.Navigation("Apelidos");
                });
#pragma warning restore 612, 618
        }
    }
}
