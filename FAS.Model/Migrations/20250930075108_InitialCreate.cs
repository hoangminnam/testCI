using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FAS.Model.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AwardCategory",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    ParentCategory = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AwardCat__3213E83FD3F90307", x => x.id);
                    table.ForeignKey(
                        name: "FK__AwardCate__Paren__6383C8BA",
                        column: x => x.ParentCategory,
                        principalTable: "AwardCategory",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "EvaluationCriteria",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaxScore = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Evaluati__3213E83FB305C922", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Role = table.Column<byte>(type: "tinyint", nullable: true),
                    FapId = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    VoteStatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__3213E83F4AB77DCF", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Award",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Award__3213E83F3BDEEB17", x => x.id);
                    table.ForeignKey(
                        name: "FK__Award__CategoryI__5DCAEF64",
                        column: x => x.CategoryId,
                        principalTable: "AwardCategory",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AdminActionLog",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PerformedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TargetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AdminAct__3213E83F7A9CAFA1", x => x.id);
                    table.ForeignKey(
                        name: "FK__AdminActionL__id__60A75C0F",
                        column: x => x.id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CouncilMember",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CouncilM__3213E83FD0498D1E", x => x.id);
                    table.ForeignKey(
                        name: "FK__CouncilMembe__id__66603565",
                        column: x => x.id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Nominee",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubmittedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    VideoUrl = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RelatedInfo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Nominee__3213E83F2715F9C0", x => x.id);
                    table.ForeignKey(
                        name: "FK__Nominee__Categor__656C112C",
                        column: x => x.CategoryId,
                        principalTable: "AwardCategory",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Nominee__Submitt__5FB337D6",
                        column: x => x.SubmittedById,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AwardPeriod",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AwardPer__3213E83F270BACB7", x => x.id);
                    table.ForeignKey(
                        name: "FK__AwardPeriod__id__5EBF139D",
                        column: x => x.id,
                        principalTable: "Award",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Blog__3213E83F141A6B93", x => x.id);
                    table.ForeignKey(
                        name: "FK__Blog__CreatedBy__6A30C649",
                        column: x => x.CreatedBy,
                        principalTable: "AdminActionLog",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TargetUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__3213E83F6F4D47AF", x => x.id);
                    table.ForeignKey(
                        name: "FK__Notificat__Creat__6D0D32F4",
                        column: x => x.CreatedBy,
                        principalTable: "AdminActionLog",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Notificat__Targe__6E01572D",
                        column: x => x.TargetUser,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CommentNominee",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CommentN__3213E83F5FD7C052", x => x.id);
                    table.ForeignKey(
                        name: "FK__CommentNo__Creat__6C190EBB",
                        column: x => x.CreatedBy,
                        principalTable: "AdminActionLog",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__CommentNomin__id__6B24EA82",
                        column: x => x.id,
                        principalTable: "Nominee",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Evaluation",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CouncilMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NomineeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CriteriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Evaluati__3213E83F965D3AFC", x => x.id);
                    table.ForeignKey(
                        name: "FK__Evaluatio__Counc__6754599E",
                        column: x => x.CouncilMemberId,
                        principalTable: "CouncilMember",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Evaluatio__Crite__68487DD7",
                        column: x => x.CriteriaId,
                        principalTable: "EvaluationCriteria",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Evaluatio__Nomin__693CA210",
                        column: x => x.NomineeId,
                        principalTable: "Nominee",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "NominateActionLog",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomineeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ActionType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Nominate__3213E83F057877EB", x => x.id);
                    table.ForeignKey(
                        name: "FK__NominateA__Nomin__6EF57B66",
                        column: x => x.NomineeId,
                        principalTable: "Nominee",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__NominateA__UserI__6FE99F9F",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NomineeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vote__3213E83FD93E9124", x => x.id);
                    table.ForeignKey(
                        name: "FK__Vote__CategoryId__6477ECF3",
                        column: x => x.CategoryId,
                        principalTable: "AwardCategory",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Vote__NomineeId__628FA481",
                        column: x => x.NomineeId,
                        principalTable: "Nominee",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Vote__UserId__619B8048",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__AdminAct__3213E83E42988AEA",
                table: "AdminActionLog",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Award_CategoryId",
                table: "Award",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "UQ__Award__3213E83ED73AD8EE",
                table: "Award",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AwardCategory_ParentCategory",
                table: "AwardCategory",
                column: "ParentCategory");

            migrationBuilder.CreateIndex(
                name: "UQ__AwardCat__3213E83EAAAAD18F",
                table: "AwardCategory",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__AwardPer__3213E83E585E425B",
                table: "AwardPeriod",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blog_CreatedBy",
                table: "Blog",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "UQ__Blog__3213E83E7D05D484",
                table: "Blog",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentNominee_CreatedBy",
                table: "CommentNominee",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "UQ__CommentN__3213E83ECA8964CD",
                table: "CommentNominee",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__CouncilM__3213E83E0EBE96D0",
                table: "CouncilMember",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_CouncilMemberId",
                table: "Evaluation",
                column: "CouncilMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_CriteriaId",
                table: "Evaluation",
                column: "CriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_NomineeId",
                table: "Evaluation",
                column: "NomineeId");

            migrationBuilder.CreateIndex(
                name: "UQ__Evaluati__3213E83E49B00C01",
                table: "Evaluation",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Evaluati__3213E83EF651AA92",
                table: "EvaluationCriteria",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NominateActionLog_NomineeId",
                table: "NominateActionLog",
                column: "NomineeId");

            migrationBuilder.CreateIndex(
                name: "IX_NominateActionLog_UserId",
                table: "NominateActionLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UQ__Nominate__3213E83E5828620A",
                table: "NominateActionLog",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nominee_CategoryId",
                table: "Nominee",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Nominee_SubmittedById",
                table: "Nominee",
                column: "SubmittedById");

            migrationBuilder.CreateIndex(
                name: "UQ__Nominee__3213E83E538B9919",
                table: "Nominee",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notification_CreatedBy",
                table: "Notification",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_TargetUser",
                table: "Notification",
                column: "TargetUser");

            migrationBuilder.CreateIndex(
                name: "UQ__Notifica__3213E83E427741B6",
                table: "Notification",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__User__3213E83E347A65C7",
                table: "User",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vote_CategoryId",
                table: "Vote",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_NomineeId",
                table: "Vote",
                column: "NomineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_UserId",
                table: "Vote",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UQ__Vote__3213E83E1BC43205",
                table: "Vote",
                column: "id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AwardPeriod");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "CommentNominee");

            migrationBuilder.DropTable(
                name: "Evaluation");

            migrationBuilder.DropTable(
                name: "NominateActionLog");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Vote");

            migrationBuilder.DropTable(
                name: "Award");

            migrationBuilder.DropTable(
                name: "CouncilMember");

            migrationBuilder.DropTable(
                name: "EvaluationCriteria");

            migrationBuilder.DropTable(
                name: "AdminActionLog");

            migrationBuilder.DropTable(
                name: "Nominee");

            migrationBuilder.DropTable(
                name: "AwardCategory");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
