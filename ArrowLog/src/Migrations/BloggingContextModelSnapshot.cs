﻿// <auto-generated />
using System;
using ArrowLog.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArrowLog.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class BloggingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("ArrowLog.Database.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Code")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParcoursId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RulesetId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ParcoursId");

                    b.HasIndex("RulesetId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("ArrowLog.Database.Models.HitType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RulesetId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("Values")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RulesetId");

                    b.ToTable("HitType");
                });

            modelBuilder.Entity("ArrowLog.Database.Models.Parcours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnimalCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Parcours");
                });

            modelBuilder.Entity("ArrowLog.Database.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("ArrowLog.Database.Models.Ruleset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Rulesets");
                });

            modelBuilder.Entity("ArrowLog.Database.Models.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PersonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RulesetId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PersonId");

                    b.HasIndex("RulesetId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("ArrowLog.Database.Models.Shot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AttemptNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ScoreId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ValueHit")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ScoreId");

                    b.ToTable("ShotsAtTargets");
                });

            modelBuilder.Entity("ArrowLog.Features.Login.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GamePerson", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GamesId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("GamePerson");
                });

            modelBuilder.Entity("ArrowLog.Database.Models.Game", b =>
                {
                    b.HasOne("ArrowLog.Database.Models.Person", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ArrowLog.Database.Models.Parcours", "Parcours")
                        .WithMany("Games")
                        .HasForeignKey("ParcoursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArrowLog.Database.Models.Ruleset", "Ruleset")
                        .WithMany()
                        .HasForeignKey("RulesetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Parcours");

                    b.Navigation("Ruleset");
                });

            modelBuilder.Entity("ArrowLog.Database.Models.HitType", b =>
                {
                    b.HasOne("ArrowLog.Database.Models.Ruleset", null)
                        .WithMany("HitTypes")
                        .HasForeignKey("RulesetId");
                });

            modelBuilder.Entity("ArrowLog.Database.Models.Person", b =>
                {
                    b.HasOne("ArrowLog.Database.Models.Game", null)
                        .WithMany("activePlayers")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ArrowLog.Database.Models.Ruleset", b =>
                {
                    b.HasOne("ArrowLog.Database.Models.Person", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("ArrowLog.Database.Models.Score", b =>
                {
                    b.HasOne("ArrowLog.Database.Models.Game", null)
                        .WithMany("Scores")
                        .HasForeignKey("GameId");

                    b.HasOne("ArrowLog.Database.Models.Person", null)
                        .WithMany("Scores")
                        .HasForeignKey("PersonId");

                    b.HasOne("ArrowLog.Database.Models.Ruleset", "Ruleset")
                        .WithMany()
                        .HasForeignKey("RulesetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ruleset");
                });

            modelBuilder.Entity("ArrowLog.Database.Models.Shot", b =>
                {
                    b.HasOne("ArrowLog.Database.Models.Score", null)
                        .WithMany("Results")
                        .HasForeignKey("ScoreId");
                });

            modelBuilder.Entity("GamePerson", b =>
                {
                    b.HasOne("ArrowLog.Database.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArrowLog.Database.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArrowLog.Database.Models.Game", b =>
                {
                    b.Navigation("Scores");

                    b.Navigation("activePlayers");
                });

            modelBuilder.Entity("ArrowLog.Database.Models.Parcours", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("ArrowLog.Database.Models.Person", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("ArrowLog.Database.Models.Ruleset", b =>
                {
                    b.Navigation("HitTypes");
                });

            modelBuilder.Entity("ArrowLog.Database.Models.Score", b =>
                {
                    b.Navigation("Results");
                });
#pragma warning restore 612, 618
        }
    }
}
