using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApiApp.Migrations
{
    /// <inheritdoc />
    public partial class AddKhachHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonHangCT_HangHoa",
                table: "ChiTietDonHang");

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKH);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHang_HangHoa_MaHH",
                table: "ChiTietDonHang",
                column: "MaHH",
                principalTable: "HangHoa",
                principalColumn: "MaHH",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHang_HangHoa_MaHH",
                table: "ChiTietDonHang");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.AddForeignKey(
                name: "FK_DonHangCT_HangHoa",
                table: "ChiTietDonHang",
                column: "MaHH",
                principalTable: "HangHoa",
                principalColumn: "MaHH",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
