﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NetCoreAspTodoApi.Models;
using NetCoreAspTodoApi.Data;

namespace NetCoreAspTodoApi.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160925182455_Start")]
    partial class Start
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NetCoreAspTodoApi.Models.Movies.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.Property<decimal>("Price");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 5);

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 60);

                    b.HasKey("ID");

                    b.ToTable("Movie");
                });
        }
    }
}
