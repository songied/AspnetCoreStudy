using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspnetCoreStudy.Migrations
{
    public partial class SecondMigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Members_UserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Members_UserId",
                table: "Replies");

            migrationBuilder.DropIndex(
                name: "IX_Replies_UserId",
                table: "Replies");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "ReplyNum",
                table: "Replies",
                newName: "ReplyNo");

            migrationBuilder.RenameColumn(
                name: "PostNum",
                table: "Posts",
                newName: "PostNo");

            migrationBuilder.AddColumn<int>(
                name: "UserNo",
                table: "Replies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserNo",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Members",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "UserNo",
                table: "Members",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "UserNo");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_UserNo",
                table: "Replies",
                column: "UserNo");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserNo",
                table: "Posts",
                column: "UserNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Members_UserNo",
                table: "Posts",
                column: "UserNo",
                principalTable: "Members",
                principalColumn: "UserNo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Members_UserNo",
                table: "Replies",
                column: "UserNo",
                principalTable: "Members",
                principalColumn: "UserNo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Members_UserNo",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Members_UserNo",
                table: "Replies");

            migrationBuilder.DropIndex(
                name: "IX_Replies_UserNo",
                table: "Replies");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserNo",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UserNo",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "UserNo",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserNo",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "ReplyNo",
                table: "Replies",
                newName: "ReplyNum");

            migrationBuilder.RenameColumn(
                name: "PostNo",
                table: "Posts",
                newName: "PostNum");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Replies",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Posts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Members",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_UserId",
                table: "Replies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Members_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Members",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Members_UserId",
                table: "Replies",
                column: "UserId",
                principalTable: "Members",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
