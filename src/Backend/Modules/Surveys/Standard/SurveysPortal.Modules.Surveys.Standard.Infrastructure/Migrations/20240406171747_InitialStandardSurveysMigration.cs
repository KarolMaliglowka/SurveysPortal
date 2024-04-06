using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SurveysPortal.Modules.Surveys.Standard.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialStandardSurveysMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "standardSurveys");

            migrationBuilder.CreateTable(
                name: "StandardQuestion",
                schema: "standardSurveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Required = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsOfferedAnswers = table.Column<bool>(type: "boolean", nullable: false),
                    OfferedAnswers = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardQuestion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StandardSurveys",
                schema: "standardSurveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Introduction = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardSurveys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StandardQuestionOrders",
                schema: "standardSurveys",
                columns: table => new
                {
                    Index = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardQuestionOrders", x => x.Index);
                    table.ForeignKey(
                        name: "FK_StandardQuestionOrders_StandardQuestion_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "standardSurveys",
                        principalTable: "StandardQuestion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StandardSurveyQuestion",
                schema: "standardSurveys",
                columns: table => new
                {
                    StandardQuestionId = table.Column<int>(type: "integer", nullable: false),
                    StandardSurveyId = table.Column<int>(type: "integer", nullable: false),
                    StandardQuestionOrder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardSurveyQuestion", x => new { x.StandardSurveyId, x.StandardQuestionId });
                    table.ForeignKey(
                        name: "FK_StandardSurveyQuestion_StandardQuestion_StandardQuestionId",
                        column: x => x.StandardQuestionId,
                        principalSchema: "standardSurveys",
                        principalTable: "StandardQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StandardSurveyQuestion_StandardSurveys_StandardSurveyId",
                        column: x => x.StandardSurveyId,
                        principalSchema: "standardSurveys",
                        principalTable: "StandardSurveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardSurveyUsers",
                schema: "standardSurveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StandardSurveyId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Completion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardSurveyUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandardSurveyUsers_StandardSurveys_StandardSurveyId",
                        column: x => x.StandardSurveyId,
                        principalSchema: "standardSurveys",
                        principalTable: "StandardSurveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardAnswers",
                schema: "standardSurveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    StandardSurveyUserId = table.Column<int>(type: "integer", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: false),
                    AnsweredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandardAnswers_StandardSurveyUsers_StandardSurveyUserId",
                        column: x => x.StandardSurveyUserId,
                        principalSchema: "standardSurveys",
                        principalTable: "StandardSurveyUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StandardAnswers_StandardSurveyUserId",
                schema: "standardSurveys",
                table: "StandardAnswers",
                column: "StandardSurveyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardQuestionOrders_QuestionId",
                schema: "standardSurveys",
                table: "StandardQuestionOrders",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardSurveyQuestion_StandardQuestionId",
                schema: "standardSurveys",
                table: "StandardSurveyQuestion",
                column: "StandardQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardSurveyUsers_StandardSurveyId",
                schema: "standardSurveys",
                table: "StandardSurveyUsers",
                column: "StandardSurveyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StandardAnswers",
                schema: "standardSurveys");

            migrationBuilder.DropTable(
                name: "StandardQuestionOrders",
                schema: "standardSurveys");

            migrationBuilder.DropTable(
                name: "StandardSurveyQuestion",
                schema: "standardSurveys");

            migrationBuilder.DropTable(
                name: "StandardSurveyUsers",
                schema: "standardSurveys");

            migrationBuilder.DropTable(
                name: "StandardQuestion",
                schema: "standardSurveys");

            migrationBuilder.DropTable(
                name: "StandardSurveys",
                schema: "standardSurveys");
        }
    }
}
