using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessControl.Migrations;

/// <inheritdoc />
public partial class CriandoTabeladeAcessos : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterDatabase()
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Pessoas",
            columns: table => new
            {
                Documento = table.Column<string>(type: "varchar(11)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Nome = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Categoria = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Pessoas", x => x.Documento);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Acessos",
            columns: table => new
            {
                IdDeAcesso = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Documento = table.Column<string>(type: "varchar(11)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Tipo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Data = table.Column<string>(type: "varchar(11)", nullable: false),
                Hora = table.Column<string>(type: "varchar(11)", nullable: false),
                Sala = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Acessos", x => x.IdDeAcesso);
                table.ForeignKey(
                    name: "FK_Acessos_Pessoas_Documento",
                    column: x => x.Documento,
                    principalTable: "Pessoas",
                    principalColumn: "Documento",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateIndex(
            name: "IX_Acessos_Documento",
            table: "Acessos",
            column: "Documento");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Acessos");

        migrationBuilder.DropTable(
            name: "Pessoas");
    }
}
