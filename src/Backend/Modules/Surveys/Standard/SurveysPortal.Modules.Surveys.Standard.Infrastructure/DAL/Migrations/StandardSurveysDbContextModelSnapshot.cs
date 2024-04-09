﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SurveysPortal.Modules.Surveys.Standard.Infrastructure.DAL;

#nullable disable

namespace SurveysPortal.Modules.Surveys.Standard.Infrastructure.DAL.Migrations
{
    [DbContext(typeof(StandardSurveysDbContext))]
    partial class StandardSurveysDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("standardSurveys")
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("AnsweredAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StandardQuestionId")
                        .HasColumnType("integer");

                    b.Property<int>("StandardSurveyUserId")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StandardQuestionId");

                    b.HasIndex("StandardSurveyUserId");

                    b.ToTable("StandardAnswers", "standardSurveys");
                });

            modelBuilder.Entity("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsOfferedAnswers")
                        .HasColumnType("boolean");

                    b.Property<string>("OfferedAnswers")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Required")
                        .HasColumnType("boolean");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("StandardQuestion", "standardSurveys");
                });

            modelBuilder.Entity("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardQuestionOrder", b =>
                {
                    b.Property<int>("Index")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Index"));

                    b.Property<int?>("QuestionId")
                        .HasColumnType("integer");

                    b.HasKey("Index");

                    b.HasIndex("QuestionId");

                    b.ToTable("StandardQuestionOrders", "standardSurveys");
                });

            modelBuilder.Entity("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardSurvey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Introduction")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("StandardSurveys", "standardSurveys");
                });

            modelBuilder.Entity("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardSurveyQuestion", b =>
                {
                    b.Property<int>("StandardSurveyId")
                        .HasColumnType("integer");

                    b.Property<int>("StandardQuestionId")
                        .HasColumnType("integer");

                    b.Property<int>("StandardQuestionOrder")
                        .HasColumnType("integer");

                    b.HasKey("StandardSurveyId", "StandardQuestionId");

                    b.HasIndex("StandardQuestionId");

                    b.ToTable("StandardSurveyQuestion", "standardSurveys");
                });

            modelBuilder.Entity("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardSurveyUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Completion")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StandardSurveyId")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StandardSurveyId");

                    b.HasIndex("UserId");

                    b.ToTable("StandardSurveyUsers", "standardSurveys");
                });

            modelBuilder.Entity("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("StandardUser", "standardSurveys");
                });

            modelBuilder.Entity("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardAnswer", b =>
                {
                    b.HasOne("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardQuestion", "StandardQuestion")
                        .WithMany()
                        .HasForeignKey("StandardQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardSurveyUser", "StandardSurveyUser")
                        .WithMany("Answers")
                        .HasForeignKey("StandardSurveyUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StandardQuestion");

                    b.Navigation("StandardSurveyUser");
                });

            modelBuilder.Entity("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardQuestionOrder", b =>
                {
                    b.HasOne("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardQuestion", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardSurveyQuestion", b =>
                {
                    b.HasOne("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardQuestion", "StandardQuestion")
                        .WithMany("StandardSurveyQuestions")
                        .HasForeignKey("StandardQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardSurvey", "StandardSurvey")
                        .WithMany("StandardSurveyQuestions")
                        .HasForeignKey("StandardSurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StandardQuestion");

                    b.Navigation("StandardSurvey");
                });

            modelBuilder.Entity("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardSurveyUser", b =>
                {
                    b.HasOne("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardSurvey", "StandardSurvey")
                        .WithMany("StandardSurveyParticipants")
                        .HasForeignKey("StandardSurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardUser", "User")
                        .WithMany("StandardSurveyParticipants")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StandardSurvey");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardQuestion", b =>
                {
                    b.Navigation("StandardSurveyQuestions");
                });

            modelBuilder.Entity("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardSurvey", b =>
                {
                    b.Navigation("StandardSurveyParticipants");

                    b.Navigation("StandardSurveyQuestions");
                });

            modelBuilder.Entity("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardSurveyUser", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("SurveysPortal.Modules.Surveys.Standard.Core.Entities.StandardUser", b =>
                {
                    b.Navigation("StandardSurveyParticipants");
                });
#pragma warning restore 612, 618
        }
    }
}