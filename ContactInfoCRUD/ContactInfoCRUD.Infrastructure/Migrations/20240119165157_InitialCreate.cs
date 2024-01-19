using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactInfoCRUD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cedula = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonaContactos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Celular = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    Telefono = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    Correo = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Dirección = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    PersonaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaContactos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonaContactos_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Cedula", "Nombre" },
                values: new object[] { 1, "001-1234567-8", "Juan Perez" });

            migrationBuilder.InsertData(
                table: "PersonaContactos",
                columns: new[] { "Id", "Celular", "Correo", "Dirección", "PersonaId", "Telefono" },
                values: new object[] { 1, "800-000-0000", "juan@example.com", "Calle Ejemplo 123", 1, "829-000-0000" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonaContactos_PersonaId",
                table: "PersonaContactos",
                column: "PersonaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonaContactos");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
