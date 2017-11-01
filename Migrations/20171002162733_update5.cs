using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NetworkConfigurator.Migrations
{
    public partial class update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adapters");

            migrationBuilder.AddColumn<string>(
                name: "Adapter",
                table: "Switch",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adapter",
                table: "Switch");

            migrationBuilder.CreateTable(
                name: "Adapters",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IPAddress = table.Column<string>(nullable: true),
                    SwitchID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adapters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Adapters_Switch_SwitchID",
                        column: x => x.SwitchID,
                        principalTable: "Switch",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adapters_SwitchID",
                table: "Adapters",
                column: "SwitchID");
        }
    }
}
