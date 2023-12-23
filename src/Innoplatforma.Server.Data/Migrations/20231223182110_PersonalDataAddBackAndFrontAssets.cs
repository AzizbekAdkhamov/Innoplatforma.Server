using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Innoplatforma.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class PersonalDataAddBackAndFrontAssets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDataAssets_PersonalData_PersonalDataId",
                table: "PersonalDataAssets");

            migrationBuilder.DropIndex(
                name: "IX_PersonalDataAssets_PersonalDataId",
                table: "PersonalDataAssets");

            migrationBuilder.DropColumn(
                name: "PersonalDataId",
                table: "PersonalDataAssets");

            migrationBuilder.AddColumn<long>(
                name: "PassportAssetFrontId",
                table: "PersonalData",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PassportAssetsBackId",
                table: "PersonalData",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PersonalDataAssetBacktIdId",
                table: "PersonalData",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PersonalDataAssetFrontIdId",
                table: "PersonalData",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalData_PersonalDataAssetBacktIdId",
                table: "PersonalData",
                column: "PersonalDataAssetBacktIdId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalData_PersonalDataAssetFrontIdId",
                table: "PersonalData",
                column: "PersonalDataAssetFrontIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalData_PersonalDataAssets_PersonalDataAssetBacktIdId",
                table: "PersonalData",
                column: "PersonalDataAssetBacktIdId",
                principalTable: "PersonalDataAssets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalData_PersonalDataAssets_PersonalDataAssetFrontIdId",
                table: "PersonalData",
                column: "PersonalDataAssetFrontIdId",
                principalTable: "PersonalDataAssets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalData_PersonalDataAssets_PersonalDataAssetBacktIdId",
                table: "PersonalData");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalData_PersonalDataAssets_PersonalDataAssetFrontIdId",
                table: "PersonalData");

            migrationBuilder.DropIndex(
                name: "IX_PersonalData_PersonalDataAssetBacktIdId",
                table: "PersonalData");

            migrationBuilder.DropIndex(
                name: "IX_PersonalData_PersonalDataAssetFrontIdId",
                table: "PersonalData");

            migrationBuilder.DropColumn(
                name: "PassportAssetFrontId",
                table: "PersonalData");

            migrationBuilder.DropColumn(
                name: "PassportAssetsBackId",
                table: "PersonalData");

            migrationBuilder.DropColumn(
                name: "PersonalDataAssetBacktIdId",
                table: "PersonalData");

            migrationBuilder.DropColumn(
                name: "PersonalDataAssetFrontIdId",
                table: "PersonalData");

            migrationBuilder.AddColumn<long>(
                name: "PersonalDataId",
                table: "PersonalDataAssets",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDataAssets_PersonalDataId",
                table: "PersonalDataAssets",
                column: "PersonalDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDataAssets_PersonalData_PersonalDataId",
                table: "PersonalDataAssets",
                column: "PersonalDataId",
                principalTable: "PersonalData",
                principalColumn: "Id");
        }
    }
}
