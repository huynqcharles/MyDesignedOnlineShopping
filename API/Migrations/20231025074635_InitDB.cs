using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    property_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    property_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.property_id);
                });

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    variant_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    inventory = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.variant_id);
                    table.ForeignKey(
                        name: "FK_Variants_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProperties",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false),
                    property_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProperties", x => new { x.product_id, x.property_id });
                    table.ForeignKey(
                        name: "FK_ProductProperties_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProperties_Properties_property_id",
                        column: x => x.property_id,
                        principalTable: "Properties",
                        principalColumn: "property_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyValues",
                columns: table => new
                {
                    property_value_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    property_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyValues", x => x.property_value_id);
                    table.ForeignKey(
                        name: "FK_PropertyValues_Properties_property_id",
                        column: x => x.property_id,
                        principalTable: "Properties",
                        principalColumn: "property_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VariantPropertyValues",
                columns: table => new
                {
                    property_value_id = table.Column<int>(type: "int", nullable: false),
                    variant_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariantPropertyValues", x => new { x.property_value_id, x.variant_id });
                    table.ForeignKey(
                        name: "FK_VariantPropertyValues_PropertyValues_property_value_id",
                        column: x => x.property_value_id,
                        principalTable: "PropertyValues",
                        principalColumn: "property_value_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VariantPropertyValues_Variants_variant_id",
                        column: x => x.variant_id,
                        principalTable: "Variants",
                        principalColumn: "variant_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_property_id",
                table: "ProductProperties",
                column: "property_id");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyValues_property_id",
                table: "PropertyValues",
                column: "property_id");

            migrationBuilder.CreateIndex(
                name: "IX_VariantPropertyValues_variant_id",
                table: "VariantPropertyValues",
                column: "variant_id");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_product_id",
                table: "Variants",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProperties");

            migrationBuilder.DropTable(
                name: "VariantPropertyValues");

            migrationBuilder.DropTable(
                name: "PropertyValues");

            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
