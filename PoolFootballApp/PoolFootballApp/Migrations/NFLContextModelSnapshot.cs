﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PoolFootballApp.Models;

namespace PoolFootballApp.Migrations
{
    [DbContext(typeof(NFLContext))]
    partial class NFLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PoolFootballApp.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwayScore");

                    b.Property<string>("AwayTeamId");

                    b.Property<int>("HomeScore");

                    b.Property<string>("HomeTeamId");

                    b.Property<int>("Season");

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("Week");

                    b.Property<int>("WeekDay");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("PoolFootballApp.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("PostTime");

                    b.Property<string>("Signature");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("PoolFootballApp.Models.Pick", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Choice");

                    b.Property<int>("MatchId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("Picks");
                });

            modelBuilder.Entity("PoolFootballApp.Models.Pool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PoolName");

                    b.Property<string>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Pools");
                });

            modelBuilder.Entity("PoolFootballApp.Models.Team", b =>
                {
                    b.Property<string>("ShortName");

                    b.Property<string>("City");

                    b.Property<int>("Conf");

                    b.Property<int>("Div");

                    b.Property<string>("Name");

                    b.HasKey("ShortName");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("PoolFootballApp.Models.Match", b =>
                {
                    b.HasOne("PoolFootballApp.Models.Team", "AwayTeam")
                        .WithMany("AwayMatches")
                        .HasForeignKey("AwayTeamId");

                    b.HasOne("PoolFootballApp.Models.Team", "HomeTeam")
                        .WithMany("HomeMatches")
                        .HasForeignKey("HomeTeamId");
                });

            modelBuilder.Entity("PoolFootballApp.Models.Pick", b =>
                {
                    b.HasOne("PoolFootballApp.Models.Match", "Match")
                        .WithMany("Picks")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
