using Microsoft.EntityFrameworkCore.Migrations;

namespace AuditManagementPortalClientMVC.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "storeAuditResponses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: true),
                    ProjectManagerName = table.Column<string>(nullable: true),
                    ApplicationOwnerName = table.Column<string>(nullable: true),
                    AuditType = table.Column<string>(nullable: true),
                    AuditDate = table.Column<string>(nullable: true),
                    AuditId = table.Column<int>(nullable: false),
                    ProjectExecutionStatus = table.Column<string>(nullable: true),
                    RemedialActionDuration = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storeAuditResponses", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "storeAuditResponses");
        }
    }
}
