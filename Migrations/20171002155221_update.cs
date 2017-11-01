using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkConfigurator.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adapter_Host_HostID",
                table: "Adapter");

            migrationBuilder.DropForeignKey(
                name: "FK_Host_Network_NetworkID",
                table: "Host");

            migrationBuilder.DropForeignKey(
                name: "FK_Host_Switch_SwitchID",
                table: "Host");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Host",
                table: "Host");

            migrationBuilder.DropIndex(
                name: "IX_Adapter_HostID",
                table: "Adapter");

            migrationBuilder.DropColumn(
                name: "HostID",
                table: "Adapter");

            migrationBuilder.RenameTable(
                name: "Host",
                newName: "Hosts");

            migrationBuilder.RenameIndex(
                name: "IX_Host_SwitchID",
                table: "Hosts",
                newName: "IX_Hosts_SwitchID");

            migrationBuilder.RenameIndex(
                name: "IX_Host_NetworkID",
                table: "Hosts",
                newName: "IX_Hosts_NetworkID");

            migrationBuilder.AlterColumn<int>(
                name: "NetworkID",
                table: "Hosts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AdapterID",
                table: "Hosts",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hosts",
                table: "Hosts",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Hosts_AdapterID",
                table: "Hosts",
                column: "AdapterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hosts_Adapter_AdapterID",
                table: "Hosts",
                column: "AdapterID",
                principalTable: "Adapter",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hosts_Network_NetworkID",
                table: "Hosts",
                column: "NetworkID",
                principalTable: "Network",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hosts_Switch_SwitchID",
                table: "Hosts",
                column: "SwitchID",
                principalTable: "Switch",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hosts_Adapter_AdapterID",
                table: "Hosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Hosts_Network_NetworkID",
                table: "Hosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Hosts_Switch_SwitchID",
                table: "Hosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hosts",
                table: "Hosts");

            migrationBuilder.DropIndex(
                name: "IX_Hosts_AdapterID",
                table: "Hosts");

            migrationBuilder.DropColumn(
                name: "AdapterID",
                table: "Hosts");

            migrationBuilder.RenameTable(
                name: "Hosts",
                newName: "Host");

            migrationBuilder.RenameIndex(
                name: "IX_Hosts_SwitchID",
                table: "Host",
                newName: "IX_Host_SwitchID");

            migrationBuilder.RenameIndex(
                name: "IX_Hosts_NetworkID",
                table: "Host",
                newName: "IX_Host_NetworkID");

            migrationBuilder.AlterColumn<int>(
                name: "NetworkID",
                table: "Host",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HostID",
                table: "Adapter",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Host",
                table: "Host",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Adapter_HostID",
                table: "Adapter",
                column: "HostID");

            migrationBuilder.AddForeignKey(
                name: "FK_Adapter_Host_HostID",
                table: "Adapter",
                column: "HostID",
                principalTable: "Host",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Host_Network_NetworkID",
                table: "Host",
                column: "NetworkID",
                principalTable: "Network",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Host_Switch_SwitchID",
                table: "Host",
                column: "SwitchID",
                principalTable: "Switch",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
