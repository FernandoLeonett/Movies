using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APi.Migrations
{
    /// <inheritdoc />
    public partial class Nacionalidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNac = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Naciolanidad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Naciolanidad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pelicula",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnioLanzamiento = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Naciolanidad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personaje",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombrePersonaje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Naciolanidad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personaje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneroPelicula",
                columns: table => new
                {
                    GeneroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeliculasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroPelicula", x => new { x.GeneroId, x.PeliculasId });
                    table.ForeignKey(
                        name: "FK_GeneroPelicula_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneroPelicula_Pelicula_PeliculasId",
                        column: x => x.PeliculasId,
                        principalTable: "Pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorPersonaje",
                columns: table => new
                {
                    ActoresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonajesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorPersonaje", x => new { x.ActoresId, x.PersonajesId });
                    table.ForeignKey(
                        name: "FK_ActorPersonaje_Actors_ActoresId",
                        column: x => x.ActoresId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorPersonaje_Personaje_PersonajesId",
                        column: x => x.PersonajesId,
                        principalTable: "Personaje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeliculaPersonaje",
                columns: table => new
                {
                    PeliculasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonajesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaPersonaje", x => new { x.PeliculasId, x.PersonajesId });
                    table.ForeignKey(
                        name: "FK_PeliculaPersonaje_Pelicula_PeliculasId",
                        column: x => x.PeliculasId,
                        principalTable: "Pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaPersonaje_Personaje_PersonajesId",
                        column: x => x.PersonajesId,
                        principalTable: "Personaje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "CreatedOn", "FechaNac", "IsDeleted", "Naciolanidad", "Nombre" },
                values: new object[,]
                {
                    { new Guid("0bc88250-093d-4064-a636-ef8646f60221"), new DateTime(2023, 11, 28, 17, 18, 38, 158, DateTimeKind.Utc).AddTicks(9203), new DateOnly(1, 1, 1), false, "n/d", "Scarlett Johansson" },
                    { new Guid("12bd485e-8de8-4d90-82c2-4b5c37e20a4b"), new DateTime(2023, 11, 28, 17, 18, 38, 158, DateTimeKind.Utc).AddTicks(9219), new DateOnly(1, 1, 1), false, "n/d", "Robert Downey Jr." },
                    { new Guid("85ac628b-d3f6-4854-a572-7f3a45e1416c"), new DateTime(2023, 11, 28, 17, 18, 38, 158, DateTimeKind.Utc).AddTicks(9200), new DateOnly(1, 1, 1), false, "n/d", "Tom Hanks" }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Id", "CreatedOn", "IsDeleted", "Naciolanidad", "Nombre" },
                values: new object[,]
                {
                    { new Guid("54b3578e-9bc1-414b-a65b-f066aa9cdbb7"), new DateTime(2023, 11, 28, 17, 18, 38, 158, DateTimeKind.Utc).AddTicks(9122), false, "n/d", "Comedia" },
                    { new Guid("cfec501c-cc98-46be-9950-7ef36525bf2f"), new DateTime(2023, 11, 28, 17, 18, 38, 158, DateTimeKind.Utc).AddTicks(9120), false, "n/d", "Drama" },
                    { new Guid("e871da67-dad5-402a-b259-974a1ef931ec"), new DateTime(2023, 11, 28, 17, 18, 38, 158, DateTimeKind.Utc).AddTicks(9090), false, "n/d", "Acción" }
                });

            migrationBuilder.InsertData(
                table: "Pelicula",
                columns: new[] { "Id", "AnioLanzamiento", "CreatedOn", "IsDeleted", "Naciolanidad", "Titulo" },
                values: new object[,]
                {
                    { new Guid("a2f5b4f3-38a7-4547-b65a-4ded5f6fb615"), 1994, new DateTime(2023, 11, 28, 17, 18, 38, 158, DateTimeKind.Utc).AddTicks(9303), false, "n/d", "Forrest Gump" },
                    { new Guid("aa1ad74f-5f83-4602-90c5-617e9acef494"), 2019, new DateTime(2023, 11, 28, 17, 18, 38, 158, DateTimeKind.Utc).AddTicks(9250), false, "n/d", "Avengers: Endgame" }
                });

            migrationBuilder.InsertData(
                table: "Personaje",
                columns: new[] { "Id", "CreatedOn", "Descripcion", "IsDeleted", "Naciolanidad", "NombrePersonaje" },
                values: new object[,]
                {
                    { new Guid("6ccb00ce-3207-4d23-8e08-b8f3e9702ca1"), new DateTime(2023, 11, 28, 17, 18, 38, 158, DateTimeKind.Utc).AddTicks(9341), "", false, "n/d", "Black Widow" },
                    { new Guid("81034819-47bd-4d8f-8574-d837f9949f87"), new DateTime(2023, 11, 28, 17, 18, 38, 158, DateTimeKind.Utc).AddTicks(9337), "", false, "n/d", "Iron Man" },
                    { new Guid("b34428e3-657f-469f-99ef-f0e6406cfb13"), new DateTime(2023, 11, 28, 17, 18, 38, 158, DateTimeKind.Utc).AddTicks(9339), "", false, "n/d", "Forrest Gump" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorPersonaje_PersonajesId",
                table: "ActorPersonaje",
                column: "PersonajesId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneroPelicula_PeliculasId",
                table: "GeneroPelicula",
                column: "PeliculasId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaPersonaje_PersonajesId",
                table: "PeliculaPersonaje",
                column: "PersonajesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorPersonaje");

            migrationBuilder.DropTable(
                name: "GeneroPelicula");

            migrationBuilder.DropTable(
                name: "PeliculaPersonaje");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Pelicula");

            migrationBuilder.DropTable(
                name: "Personaje");
        }
    }
}
