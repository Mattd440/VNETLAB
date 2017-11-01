using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NetworkConfigurator.Migrations
{
    public partial class createModels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.CreateTable(
                name: "switchs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ports = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_switchs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "hosts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SwitchID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hosts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_hosts_switchs_SwitchID",
                        column: x => x.SwitchID,
                        principalTable: "switchs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adapter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HostID = table.Column<int>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    SwitchID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adapter", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Adapter_hosts_HostID",
                        column: x => x.HostID,
                        principalTable: "hosts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adapter_switchs_SwitchID",
                        column: x => x.SwitchID,
                        principalTable: "switchs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adapter_HostID",
                table: "Adapter",
                column: "HostID");

            migrationBuilder.CreateIndex(
                name: "IX_Adapter_SwitchID",
                table: "Adapter",
                column: "SwitchID");

            migrationBuilder.CreateIndex(
                name: "IX_hosts_SwitchID",
                table: "hosts",
                column: "SwitchID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adapter");

            migrationBuilder.DropTable(
                name: "hosts");

            migrationBuilder.DropTable(
                name: "switchs");

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.ID);
                });
        }
    }
}
