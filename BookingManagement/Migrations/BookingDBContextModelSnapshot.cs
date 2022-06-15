﻿// <auto-generated />
using BookingManagement.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookingManagement.Migrations
{
    [DbContext(typeof(BookingDBContext))]
    partial class BookingDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookingManagement.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<string>("MealPreferrence");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("NoOfPassengers");

                    b.Property<int>("PNR");

                    b.Property<int>("ScheduleId");

                    b.Property<string>("SeatNumbers");

                    b.HasKey("BookingId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BookingManagement.Models.Passenger", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<int>("BookingId");

                    b.Property<string>("Gender")
                        .HasMaxLength(1);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("PassengerId");

                    b.HasIndex("BookingId");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("BookingManagement.Models.Passenger", b =>
                {
                    b.HasOne("BookingManagement.Models.Booking")
                        .WithMany("Passengers")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
