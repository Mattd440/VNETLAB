using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkConfigurator.Migrations
{
    public partial class update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adapter_Switch_SwitchID",
                table: "Adapter");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adapter",
                table: "Adapter");

            migrationBuilder.RenameTable(
                name: "Host",
                newName: "Hosts");

            migrationBuilder.RenameTable(
                name: "Adapter",
                newName: "Adapters");

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

            migrationBuilder.RenameIndex(
                name: "IX_Adapter_SwitchID",
                table: "Adapters",
                newName: "IX_Adapters_SwitchID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hosts",
                table: "Hosts",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adapters",
                table: "Adapters",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Adapters_Switch_SwitchID",
                table: "Adapters",
                column: "SwitchID",
                principalTable: "Switch",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hosts_Adapters_AdapterID",
                table: "Hosts",
                column: "AdapterID",
                principalTable: "Adapters",
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
                name: "FK_Adapters_Switch_SwitchID",
                table: "Adapters");

            migrationBuilder.DropForeignKey(
                name: "FK_Hosts_Adapters_AdapterID",
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adapters",
                table: "Adapters");

            migrationBuilder.RenameTable(
                name: "Hosts",
                newName: "Host");

            migrationBuilder.RenameTable(
                name: "Adapters",
                newName: "Adapter");

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

            migrationBuilder.RenameIndex(
                name: "IX_Adapters_SwitchID",
                table: "Adapter",
                newName: "IX_Adapter_SwitchID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Host",
                table: "Host",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adapter",
                table: "Adapter",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Adapter_Switch_SwitchID",
                table: "Adapter",
                column: "SwitchID",
                principalTable: "Switch",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

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
    }
}
