using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class EditIIN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiagnozLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnozLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialistLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialistLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorLists_SpecialistLists_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "SpecialistLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetId = table.Column<int>(type: "int", nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    AppartmentNumber = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Streets_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiagnozListDoctor",
                columns: table => new
                {
                    DiagnozListsId = table.Column<int>(type: "int", nullable: false),
                    DoctorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnozListDoctor", x => new { x.DiagnozListsId, x.DoctorsId });
                    table.ForeignKey(
                        name: "FK_DiagnozListDoctor_DiagnozLists_DiagnozListsId",
                        column: x => x.DiagnozListsId,
                        principalTable: "DiagnozLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiagnozListDoctor_DoctorLists_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "DoctorLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiagnozListPatient",
                columns: table => new
                {
                    DiagnozListsId = table.Column<int>(type: "int", nullable: false),
                    PatientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnozListPatient", x => new { x.DiagnozListsId, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_DiagnozListPatient_DiagnozLists_DiagnozListsId",
                        column: x => x.DiagnozListsId,
                        principalTable: "DiagnozLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiagnozListPatient_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorPatient",
                columns: table => new
                {
                    DoctorsId = table.Column<int>(type: "int", nullable: false),
                    PatientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPatient", x => new { x.DoctorsId, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_DoctorPatient_DoctorLists_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "DoctorLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorPatient_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    DiagnozListId = table.Column<int>(type: "int", nullable: false),
                    Complaints = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitHistories_DiagnozLists_DiagnozListId",
                        column: x => x.DiagnozListId,
                        principalTable: "DiagnozLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitHistories_DoctorLists_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "DoctorLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitHistories_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DiagnozLists",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ангина" },
                    { 2, "Аппендицит" },
                    { 3, "Артроз" }
                });

            migrationBuilder.InsertData(
                table: "SpecialistLists",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Терапевт" },
                    { 2, "Окулист" },
                    { 3, "Невропатолог" }
                });

            migrationBuilder.InsertData(
                table: "Streets",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Гоголя" },
                    { 2, "Гулдер-1" },
                    { 3, "14 мкр" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiagnozListDoctor_DoctorsId",
                table: "DiagnozListDoctor",
                column: "DoctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnozListPatient_PatientsId",
                table: "DiagnozListPatient",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorLists_SpecialityId",
                table: "DoctorLists",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPatient_PatientsId",
                table: "DoctorPatient",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_StreetId",
                table: "Patients",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitHistories_DiagnozListId",
                table: "VisitHistories",
                column: "DiagnozListId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitHistories_DoctorId",
                table: "VisitHistories",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitHistories_PatientId",
                table: "VisitHistories",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiagnozListDoctor");

            migrationBuilder.DropTable(
                name: "DiagnozListPatient");

            migrationBuilder.DropTable(
                name: "DoctorPatient");

            migrationBuilder.DropTable(
                name: "VisitHistories");

            migrationBuilder.DropTable(
                name: "DiagnozLists");

            migrationBuilder.DropTable(
                name: "DoctorLists");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "SpecialistLists");

            migrationBuilder.DropTable(
                name: "Streets");
        }
    }
}
