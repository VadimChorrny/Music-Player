﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220304132948_change collections")]
    partial class changecollections
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Core.Entities.Ganre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ganres");
                });

            modelBuilder.Entity("Core.Entities.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Playlist");
                });

            modelBuilder.Entity("Core.Entities.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("AudioFile")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("GanreId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlaylistId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GanreId");

                    b.HasIndex("PlaylistId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("Core.Entities.Playlist", b =>
                {
                    b.HasOne("Core.Entities.Author", "Author")
                        .WithMany("Playlists")
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Core.Entities.Track", b =>
                {
                    b.HasOne("Core.Entities.Author", "Author")
                        .WithMany("Tracks")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Core.Entities.Ganre", "Ganre")
                        .WithMany("Tracks")
                        .HasForeignKey("GanreId");

                    b.HasOne("Core.Entities.Playlist", "Playlist")
                        .WithMany("Tracks")
                        .HasForeignKey("PlaylistId");

                    b.Navigation("Author");

                    b.Navigation("Ganre");

                    b.Navigation("Playlist");
                });

            modelBuilder.Entity("Core.Entities.Author", b =>
                {
                    b.Navigation("Playlists");

                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Core.Entities.Ganre", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Core.Entities.Playlist", b =>
                {
                    b.Navigation("Tracks");
                });
#pragma warning restore 612, 618
        }
    }
}
