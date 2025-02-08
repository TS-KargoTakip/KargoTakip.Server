using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KargoTakip.Server.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class i_added_kargo_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kargolarim",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Gonderen_FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Gonderen_LastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Gonderen_TCNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gonderen_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gonderen_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alici_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alici_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alici_TCNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alici_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alici_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeslimAdresi_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeslimAdresi_Town = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeslimAdresi_Mahalle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeslimAdresi_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeslimAdresi_FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KargoInformation_KargoTipi = table.Column<int>(type: "int", nullable: false),
                    KargoInformation_Agirlik = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeleteUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kargolarim", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kargolarim");
        }
    }
}
