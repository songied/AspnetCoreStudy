using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspnetCoreStudy.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    UserPw = table.Column<string>(nullable: false),
                    UserEmail = table.Column<string>(nullable: false),
                    UserGender = table.Column<string>(nullable: false),
                    UserNm = table.Column<string>(nullable: false),
                    UserPhoto = table.Column<string>(nullable: true),
                    UserReg = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostNum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostTittle = table.Column<string>(nullable: false),
                    PostContent = table.Column<string>(nullable: false),
                    PostViews = table.Column<int>(nullable: false),
                    PostGroup = table.Column<int>(nullable: false),
                    PostReg = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostNum);
                    table.ForeignKey(
                        name: "FK_Posts_Members_UserId",
                        column: x => x.UserId,
                        principalTable: "Members",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    ReplyNum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReplyContent = table.Column<string>(nullable: false),
                    ReplyReg = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.ReplyNum);
                    table.ForeignKey(
                        name: "FK_Replies_Members_UserId",
                        column: x => x.UserId,
                        principalTable: "Members",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_UserId",
                table: "Replies",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
