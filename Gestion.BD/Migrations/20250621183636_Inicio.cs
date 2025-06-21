using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion.BD.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreC = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    FechaNac = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CorreoElec = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreRol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    Legajo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_rols_RolId",
                        column: x => x.RolId,
                        principalTable: "rols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstudiantesCarreras",
                columns: table => new
                {
                    EstudiantesID = table.Column<int>(type: "int", nullable: false),
                    CarrerasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudiantesCarreras", x => new { x.EstudiantesID, x.CarrerasId });
                    table.ForeignKey(
                        name: "FK_EstudiantesCarreras_Carreras_CarrerasId",
                        column: x => x.CarrerasId,
                        principalTable: "Carreras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstudiantesCarreras_Estudiantes_EstudiantesID",
                        column: x => x.EstudiantesID,
                        principalTable: "Estudiantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "NombreCarrera_UQ",
                table: "Carreras",
                column: "NombreC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_PersonaId",
                table: "Estudiantes",
                column: "PersonaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Legajo_UQ",
                table: "Estudiantes",
                column: "Legajo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstudiantesCarreras_CarrerasId",
                table: "EstudiantesCarreras",
                column: "CarrerasId");

            migrationBuilder.CreateIndex(
                name: "CorreoElectronico_UQ",
                table: "Personas",
                column: "CorreoElec",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "DNI_UQ",
                table: "Personas",
                column: "DNI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Telefono_UQ",
                table: "Personas",
                column: "Telefono",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PersonaId",
                table: "Usuarios",
                column: "PersonaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "NombreUsuario_UQ",
                table: "Usuarios",
                column: "NombreUsuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstudiantesCarreras");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Carreras");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "rols");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
