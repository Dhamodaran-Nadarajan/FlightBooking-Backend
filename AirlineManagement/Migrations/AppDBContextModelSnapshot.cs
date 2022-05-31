﻿// <auto-generated />
using AirlineManagement.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirlineManagement.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AirlineManagement.Models.Airline", b =>
                {
                    b.Property<int>("AirlineId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AirlineName");

                    b.Property<string>("ContactAddress");

                    b.Property<string>("ContactLogo");

                    b.Property<int>("ContactNumber");

                    b.Property<bool>("IsActive");

                    b.HasKey("AirlineId");

                    b.ToTable("Airlines");
                });
#pragma warning restore 612, 618
        }
    }
}