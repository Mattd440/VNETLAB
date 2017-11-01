using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NetworkConfigurator.DataManager;

namespace NetworkConfigurator.Migrations
{
    [DbContext(typeof(PeopleContext))]
    [Migration("20170926012614_abcd")]
    partial class abcd
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("NetworkID");

                    b.Property<int?>("SwitchID");

                    b.HasKey("ID");

                    b.HasIndex("NetworkID");

                    b.HasIndex("SwitchID");

                    b.ToTable("Host");
                });

            modelBuilder.Entity("NetworkConfigurator.Model.Network", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Network");
                });

            modelBuilder.Entity("NetworkConfigurator.Model.Switch", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("NetworkID");

                    b.Property<int>("ports");

                    b.HasKey("ID");

                    b.HasIndex("NetworkID");

                    b.ToTable("Switch");
                });

            modelBuilder.Entity("NetworkConfigurator.Model.Adapter", b =>
                {
                    b.HasOne("NetworkConfigurator.Model.Host")
                        .WithMany("NetworkAdapters")
                        .HasForeignKey("HostID");

                    b.HasOne("NetworkConfigurator.Model.Switch")
                        .WithMany("networkAdapters")
                        .HasForeignKey("SwitchID");
                });

            modelBuilder.Entity("NetworkConfigurator.Model.Host", b =>
                {
                    b.HasOne("NetworkConfigurator.Model.Network", "Network")
                        .WithMany("Hosts")
                        .HasForeignKey("NetworkID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetworkConfigurator.Model.Switch", "Switch")
                        .WithMany("connectedHosts")
                        .HasForeignKey("SwitchID");
                });

            modelBuilder.Entity("NetworkConfigurator.Model.Switch", b =>
                {
                    b.HasOne("NetworkConfigurator.Model.Network")
                        .WithMany("Switchs")
                        .HasForeignKey("NetworkID");
                });
        }
    }
}
