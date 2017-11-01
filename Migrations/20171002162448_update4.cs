using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkConfigurator.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hosts_Adapters_AdapterID",
                table: "Hosts");

            migrationBuilder.DropIndex(
                name: "IX_Hosts_AdapterID",
                table: "Hosts");

            migrationBuilder.DropColumn(
                name: "AdapterID",
                table: "Hosts");

            migrationBuilder.AddColumn<string>(
                name: "Adapter",
                table: "Hosts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adapter",
                table: "Hosts");

            migrationBuilder.AddColumn<int>(
                name: "AdapterID",
                table: "Hosts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hosts_AdapterID",
                table: "Hosts",
                column: "AdapterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hosts_Adapters_AdapterID",
                table: "Hosts",
                column: "AdapterID",
                principalTable: "Adapters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
