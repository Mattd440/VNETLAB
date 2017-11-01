using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NetworkConfigurator.DataManager;

namespace NetworkConfigurator.Migrations
{
    [DbContext(typeof(PeopleContext))]
    [Migration("20170925031026_createModels2")]
    partial class createModels2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NetworkConfigurator.Model.Adapter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("HostID");

                    b.Property<string>("IPAddress");

                    b.Property<int?>("SwitchID");

                    b.HasKey("ID");

                    b.HasIndex("HostID");

                    b.HasIndex("SwitchID");

                    b.ToTable("Adapter");
                });

            modelBuilder.Entity("NetworkConfigurator.Model.Host", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("SwitchID");

                    b.HasKey("ID");

                    b.HasIndex("SwitchID");

                    b.ToTable("hosts");
                });

            modelBuilder.Entity("NetworkConfigurator.Model.Switch", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("ports");

                    b.HasKey("ID");

                    b.ToTable("switchs");
                });

            modelBuilder.Entity("NetworkConfigurator.Model.Adapter", b =>
                {
                    b.HasOne("NetworkConfigurator.Model.Host")
                        .WithMany("networkAdapters")
                        .HasForeignKey("HostID");

                    b.HasOne("NetworkConfigurator.Model.Switch")
                        .WithMany("networkAdapters")
                        .HasForeignKey("SwitchID");
                });

            modelBuilder.Entity("NetworkConfigurator.Model.Host", b =>
                {
                    b.HasOne("NetworkConfigurator.Model.Switch", "Switch")
                        .WithMany("connectedHosts")
                        .HasForeignKey("SwitchID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
