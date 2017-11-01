using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkConfigurator.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameIndex(
                name: "IX_Hosts_AdapterID",
                table: "Host",
                newName: "IX_Host_AdapterID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Host",
                table: "Host",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Host_Adapter_AdapterID",
                table: "Host",
                column: "AdapterID",
                principalTable: "Adapter",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Host_Network_NetworkID",
                table: "Host",
                column: "NetworkID",
                principalTable: "Network",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Host_Switch_SwitchID",
                table: "Host",
                column: "SwitchID",
                principalTable: "Switch",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Host_Adapter_AdapterID",
                table: "Host");

            migrationBuilder.DropForeignKey(
                name: "FK_Host_Network_NetworkID",
                table: "Host");

            migrationBuilder.DropForeignKey(
                name: "FK_Host_Switch_SwitchID",
                table: "Host");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Host",
                table: "Host");

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

            migrationBuilder.RenameIndex(
                name: "IX_Host_AdapterID",
                table: "Hosts",
                newName: "IX_Hosts_AdapterID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hosts",
                table: "Hosts",
                column: "ID");

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
    }
}
