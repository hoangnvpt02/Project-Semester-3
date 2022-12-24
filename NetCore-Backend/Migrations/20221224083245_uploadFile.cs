using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCoreBackend.Migrations
{
    /// <inheritdoc />
    public partial class uploadFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FileDetailsId",
                table: "Product",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FileDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDetails", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileDetails");

            migrationBuilder.DropColumn(
                name: "FileDetailsId",
                table: "Product");
        }
    }
}
