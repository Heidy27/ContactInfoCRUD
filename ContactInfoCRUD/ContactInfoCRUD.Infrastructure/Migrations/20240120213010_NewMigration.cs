using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactInfoCRUD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PERSONA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cedula = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PERSONACONTACTO",
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
                    table.PrimaryKey("PK_PERSONACONTACTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PERSONACONTACTO_PERSONA_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "PERSONA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PERSONA",
                columns: new[] { "Id", "Cedula", "Nombre" },
                values: new object[] { 2, "002-1234567-8", "Laura" });

            migrationBuilder.InsertData(
                table: "PERSONACONTACTO",
                columns: new[] { "Id", "Celular", "Correo", "Dirección", "PersonaId", "Telefono" },
                values: new object[] { 2, "823-000-0000", "juan@example.com", "Calle Ejemplo 123", 2, "829-030-0000" });

            migrationBuilder.CreateIndex(
                name: "IX_PERSONACONTACTO_PersonaId",
                table: "PERSONACONTACTO",
                column: "PersonaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PERSONACONTACTO");

            migrationBuilder.DropTable(
                name: "PERSONA");
        }
    }
}
