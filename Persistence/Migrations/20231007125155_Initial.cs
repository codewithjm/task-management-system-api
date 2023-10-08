using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TASK",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TITLE = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BODY_PATH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATED_UTC_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_UTC_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    LEVEL = table.Column<int>(type: "int", nullable: false),
                    DUE_UTC_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    REQUESTOR = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TASK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TASK_FILE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TASK_REF = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FILE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PATH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATED_UTC_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TASK_FILE", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TASK");

            migrationBuilder.DropTable(
                name: "TASK_FILE");
        }
    }
}
