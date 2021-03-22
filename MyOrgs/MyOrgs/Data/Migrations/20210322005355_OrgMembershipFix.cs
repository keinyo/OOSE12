using Microsoft.EntityFrameworkCore.Migrations;

namespace MyOrgs.Data.Migrations
{
    public partial class OrgMembershipFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrgMembership",
                columns: table => new
                {
                    Org = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgMembership", x => new { x.Org, x.User });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrgMembership");
        }
    }
}
