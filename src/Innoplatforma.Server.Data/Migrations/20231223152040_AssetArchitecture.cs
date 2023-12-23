using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Innoplatforma.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AssetArchitecture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalData_Users_UserId",
                table: "PersonalData");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDataAssets_PersonalData_PersonalDataId",
                table: "PersonalDataAssets");

            migrationBuilder.DropTable(
                name: "ApplicationAssets");

            migrationBuilder.DropTable(
                name: "OrganizationDetailAssets");

            migrationBuilder.DropTable(
                name: "UserAssets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalData",
                table: "PersonalData");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "PersonalData",
                newName: "Asset");

            migrationBuilder.RenameIndex(
                name: "IX_PersonalData_UserId",
                table: "Asset",
                newName: "IX_Asset_UserId");

            migrationBuilder.AddColumn<long>(
                name: "AssetId",
                table: "PersonalDataAssets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AssetId",
                table: "OrganizationDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AssetId",
                table: "Applications",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Asset",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Asset",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "PassportSeria",
                table: "Asset",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "PassportNumber",
                table: "Asset",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PassportEndDate",
                table: "Asset",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Asset",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Asset",
                type: "character varying(34)",
                maxLength: 34,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Asset",
                table: "Asset",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDataAssets_AssetId",
                table: "PersonalDataAssets",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationDetails_AssetId",
                table: "OrganizationDetails",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_AssetId",
                table: "Applications",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Asset_AssetId",
                table: "Applications",
                column: "AssetId",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Users_UserId",
                table: "Asset",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationDetails_Asset_AssetId",
                table: "OrganizationDetails",
                column: "AssetId",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDataAssets_Asset_AssetId",
                table: "PersonalDataAssets",
                column: "AssetId",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDataAssets_Asset_PersonalDataId",
                table: "PersonalDataAssets",
                column: "PersonalDataId",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Asset_AssetId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Users_UserId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationDetails_Asset_AssetId",
                table: "OrganizationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDataAssets_Asset_AssetId",
                table: "PersonalDataAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDataAssets_Asset_PersonalDataId",
                table: "PersonalDataAssets");

            migrationBuilder.DropIndex(
                name: "IX_PersonalDataAssets_AssetId",
                table: "PersonalDataAssets");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationDetails_AssetId",
                table: "OrganizationDetails");

            migrationBuilder.DropIndex(
                name: "IX_Applications_AssetId",
                table: "Applications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Asset",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "PersonalDataAssets");

            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "OrganizationDetails");

            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Asset");

            migrationBuilder.RenameTable(
                name: "Asset",
                newName: "PersonalData");

            migrationBuilder.RenameIndex(
                name: "IX_Asset_UserId",
                table: "PersonalData",
                newName: "IX_PersonalData_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Roles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "PersonalData",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "PersonalData",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PassportSeria",
                table: "PersonalData",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PassportNumber",
                table: "PersonalData",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PassportEndDate",
                table: "PersonalData",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "PersonalData",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalData",
                table: "PersonalData",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ApplicationAssets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Extension = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationAssets_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationDetailAssets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganizationDetailId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Extension = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationDetailAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationDetailAssets_OrganizationDetails_OrganizationDe~",
                        column: x => x.OrganizationDetailId,
                        principalTable: "OrganizationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAssets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Extension = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAssets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationAssets_ApplicationId",
                table: "ApplicationAssets",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationDetailAssets_OrganizationDetailId",
                table: "OrganizationDetailAssets",
                column: "OrganizationDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAssets_UserId",
                table: "UserAssets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalData_Users_UserId",
                table: "PersonalData",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDataAssets_PersonalData_PersonalDataId",
                table: "PersonalDataAssets",
                column: "PersonalDataId",
                principalTable: "PersonalData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
