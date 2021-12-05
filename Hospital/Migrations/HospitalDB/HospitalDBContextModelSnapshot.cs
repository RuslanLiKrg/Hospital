﻿// <auto-generated />
using System;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hospital.Migrations.HospitalDB
{
    [DbContext(typeof(HospitalDBContext))]
    partial class HospitalDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DiagnozListDoctor", b =>
                {
                    b.Property<int>("DiagnozListsId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorsId")
                        .HasColumnType("int");

                    b.HasKey("DiagnozListsId", "DoctorsId");

                    b.HasIndex("DoctorsId");

                    b.ToTable("DiagnozListDoctor");
                });

            modelBuilder.Entity("DiagnozListPatient", b =>
                {
                    b.Property<int>("DiagnozListsId")
                        .HasColumnType("int");

                    b.Property<int>("PatientsId")
                        .HasColumnType("int");

                    b.HasKey("DiagnozListsId", "PatientsId");

                    b.HasIndex("PatientsId");

                    b.ToTable("DiagnozListPatient");
                });

            modelBuilder.Entity("DoctorPatient", b =>
                {
                    b.Property<int>("DoctorsId")
                        .HasColumnType("int");

                    b.Property<int>("PatientsId")
                        .HasColumnType("int");

                    b.HasKey("DoctorsId", "PatientsId");

                    b.HasIndex("PatientsId");

                    b.ToTable("DoctorPatient");
                });

            modelBuilder.Entity("Hospital.Models.DiagnozList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DiagnozLists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ангина"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Аппендицит"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Артроз"
                        });
                });

            modelBuilder.Entity("Hospital.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecialityId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SpecialityId");

                    b.ToTable("DoctorLists");
                });

            modelBuilder.Entity("Hospital.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AppartmentNumber")
                        .HasColumnType("int");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("IIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StreetId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Hospital.Models.Speciality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SpecialistLists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Терапевт"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Окулист"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Невропатолог"
                        });
                });

            modelBuilder.Entity("Hospital.Models.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Streets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Гоголя"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Гулдер-1"
                        },
                        new
                        {
                            Id = 3,
                            Name = "14 мкр"
                        });
                });

            modelBuilder.Entity("Hospital.Models.VisitHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Complaints")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiagnozListId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiagnozListId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("VisitHistories");
                });

            modelBuilder.Entity("DiagnozListDoctor", b =>
                {
                    b.HasOne("Hospital.Models.DiagnozList", null)
                        .WithMany()
                        .HasForeignKey("DiagnozListsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.Models.Doctor", null)
                        .WithMany()
                        .HasForeignKey("DoctorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiagnozListPatient", b =>
                {
                    b.HasOne("Hospital.Models.DiagnozList", null)
                        .WithMany()
                        .HasForeignKey("DiagnozListsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.Models.Patient", null)
                        .WithMany()
                        .HasForeignKey("PatientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoctorPatient", b =>
                {
                    b.HasOne("Hospital.Models.Doctor", null)
                        .WithMany()
                        .HasForeignKey("DoctorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.Models.Patient", null)
                        .WithMany()
                        .HasForeignKey("PatientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hospital.Models.Doctor", b =>
                {
                    b.HasOne("Hospital.Models.Speciality", "Speciality")
                        .WithMany("DoctorLists")
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Speciality");
                });

            modelBuilder.Entity("Hospital.Models.Patient", b =>
                {
                    b.HasOne("Hospital.Models.Street", "Street")
                        .WithMany("Patients")
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Street");
                });

            modelBuilder.Entity("Hospital.Models.VisitHistory", b =>
                {
                    b.HasOne("Hospital.Models.DiagnozList", "DiagnozList")
                        .WithMany()
                        .HasForeignKey("DiagnozListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.Models.Doctor", "DoctorList")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiagnozList");

                    b.Navigation("DoctorList");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Hospital.Models.Speciality", b =>
                {
                    b.Navigation("DoctorLists");
                });

            modelBuilder.Entity("Hospital.Models.Street", b =>
                {
                    b.Navigation("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
