using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NetworkConfigurator.Migrations
{
    public partial class addNetworkClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adapter_hosts_HostID",
                table: "Adapter");

            migrationBuilder.DropForeignKey(
                name: "FK_Adapter_switchs_SwitchID",
                table: "Adapter");

            migrationBuilder.DropForeignKey(
                name: "FK_hosts_switchs_SwitchID",
                table: "hosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_switchs",
                table: "switchs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hosts",
                table: "hosts");

            migrationBuilder.RenameTable(
                name: "switchs",
                newName: "Switch");

            migrationBuilder.RenameTable(
                name: "hosts",
                newName: "Host");

            migrationBuilder.RenameIndex(
                name: "IX_hosts_SwitchID",
                table: "Host",
                newName: "IX_Host_SwitchID");

            migrationBuilder.AddColumn<int>(
                name: "NetworkID",
                table: "Switch",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SwitchID",
                table: "Host",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Host",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NetworkID",
                table: "Host",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Switch",
                table: "Switch",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Host",
                table: "Host",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Network",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Network", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Switch_NetworkID",
                table: "Switch",
                column: "NetworkID");

            migrationBuilder.CreateIndex(
                name: "IX_Host_NetworkID",
                table: "Host",
                column: "NetworkID");

            migrationBuilder.AddForeignKey(
                name: "FK_Adapter_Host_HostID",
                table: "Adapter",
                column: "HostID",
                principalTable: "Host",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Adapter_Switch_SwitchID",
                table: "Adapter",
                column: "SwitchID",
                principalTable: "Switch",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Switch_Network_NetworkID",
                table: "Switch",
                column: "NetworkID",
                principalTable: "Network",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adapter_Host_HostID",
                table: "Adapter");

            migrationBuilder.DropForeignKey(
                name: "FK_Adapter_Switch_SwitchID",
                table: "Adapter");

            migrationBuilder.DropForeignKey(
                name: "FK_Host_Network_NetworkID",
                table: "Host");

            migrationBuilder.DropForeignKey(
                name: "FK_Host_Switch_SwitchID",
                table: "Host");

            migrationBuilder.DropForeignKey(
                name: "FK_Switch_Network_NetworkID",
                table: "Switch");

            migrationBuilder.DropTable(
                name: "Network");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Switch",
                table: "Switch");

            migrationBuilder.DropIndex(
                name: "IX_Switch_NetworkID",
                table: "Switch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Host",
                table: "Host");

            migrationBuilder.DropIndex(
                name: "IX_Host_NetworkID",
                table: "Host");

            migrationBuilder.DropColumn(
                name: "NetworkID",
                table: "Switch");

            migrationBuilder.DropColumn(
                name: "NetworkID",
                table: "Host");

            migrationBuilder.RenameTable(
                name: "Switch",
                newName: "switchs");

            migrationBuilder.RenameTable(
                name: "Host",
                newName: "hosts");

            migrationBuilder.RenameIndex(
                name: "IX_Host_SwitchID",
                table: "hosts",
                newName: "IX_hosts_SwitchID");

            migrationBuilder.AlterColumn<int>(
                name: "SwitchID",
                table: "hosts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "hosts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_switchs",
                table: "switchs",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hosts",
                table: "hosts",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Adapter_hosts_HostID",
                table: "Adapter",
                column: "HostID",
                principalTable: "hosts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Adapter_switchs_SwitchID",
                table: "Adapter",
                column: "SwitchID",
                principalTable: "switchs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_hosts_switchs_SwitchID",
                table: "hosts",
                column: "SwitchID",
                principalTable: "switchs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
