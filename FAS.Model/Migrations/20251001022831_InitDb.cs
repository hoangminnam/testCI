using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FAS.Model.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "award_category_id",
                table: "EvaluationCriteria",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCriteria_award_category_id",
                table: "EvaluationCriteria",
                column: "award_category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationCriterion_AwardCategory",
                table: "EvaluationCriteria",
                column: "award_category_id",
                principalTable: "AwardCategory",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationCriterion_AwardCategory",
                table: "EvaluationCriteria");

            migrationBuilder.DropIndex(
                name: "IX_EvaluationCriteria_award_category_id",
                table: "EvaluationCriteria");

            migrationBuilder.DropColumn(
                name: "award_category_id",
                table: "EvaluationCriteria");
        }
    }
}
