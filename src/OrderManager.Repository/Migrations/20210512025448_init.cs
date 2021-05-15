using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManager.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_category_product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    Created_At = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_category_product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_city",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    uf = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    Created_At = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_city", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_image",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    name_file = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    mai = table.Column<bool>(type: "boolean", nullable: false),
                    Created_At = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_image", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "numeric(17,2)", precision: 17, scale: 2, nullable: false),
                    id_category = table.Column<Guid>(type: "uuid", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    Created_At = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_product_tb_category_product_id_category",
                        column: x => x.id_category,
                        principalTable: "tb_category_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Address",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<byte>(type: "smallint", nullable: false),
                    public_place = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    district = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    number = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    complement = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    postal_code = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    id_City = table.Column<Guid>(type: "uuid", nullable: false),
                    Created_At = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Address", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_Address_tb_city_id_City",
                        column: x => x.id_City,
                        principalTable: "tb_city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_combo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "numeric(17,2)", precision: 17, scale: 2, nullable: false),
                    id_image = table.Column<Guid>(type: "uuid", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    Created_At = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_combo", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_combo_tb_image_id_image",
                        column: x => x.id_image,
                        principalTable: "tb_image",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_image_product",
                columns: table => new
                {
                    id_image = table.Column<Guid>(type: "uuid", nullable: false),
                    id_product = table.Column<Guid>(type: "uuid", nullable: false),
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Created_At = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_image_product", x => new { x.id_image, x.id_product });
                    table.ForeignKey(
                        name: "FK_tb_image_product_tb_image_id_image",
                        column: x => x.id_image,
                        principalTable: "tb_image",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_image_product_tb_product_id_product",
                        column: x => x.id_product,
                        principalTable: "tb_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_promotion_product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "numeric(17,2)", precision: 17, scale: 2, nullable: false),
                    id_image = table.Column<Guid>(type: "uuid", nullable: false),
                    id_product = table.Column<Guid>(type: "uuid", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    Created_At = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_promotion_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_promotion_product_tb_image_id_image",
                        column: x => x.id_image,
                        principalTable: "tb_image",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_promotion_product_tb_product_id_product",
                        column: x => x.id_product,
                        principalTable: "tb_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_client",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    IdAddress = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Created_At = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_client", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_client_tb_Address_IdAddress",
                        column: x => x.IdAddress,
                        principalTable: "tb_Address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_product_combo",
                columns: table => new
                {
                    id_product = table.Column<Guid>(type: "uuid", nullable: false),
                    id_combo = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_product_combo", x => new { x.id_product, x.id_combo });
                    table.ForeignKey(
                        name: "FK_tb_product_combo_tb_combo_id_combo",
                        column: x => x.id_combo,
                        principalTable: "tb_combo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_product_combo_tb_product_id_product",
                        column: x => x.id_product,
                        principalTable: "tb_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_order",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderNumber = table.Column<Guid>(type: "uuid", maxLength: 10, nullable: false),
                    amount = table.Column<decimal>(type: "numeric(17,2)", precision: 17, scale: 2, nullable: false),
                    Delivery = table.Column<TimeSpan>(type: "interval", nullable: false),
                    id_client = table.Column<Guid>(type: "uuid", nullable: false),
                    Created_At = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_order_tb_client_id_client",
                        column: x => x.id_client,
                        principalTable: "tb_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_order_product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", precision: 2, nullable: false),
                    price = table.Column<decimal>(type: "numeric(17,2)", precision: 17, scale: 2, nullable: false),
                    id_product = table.Column<Guid>(type: "uuid", nullable: false),
                    id_order = table.Column<Guid>(type: "uuid", nullable: false),
                    Created_At = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_order_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_order_product_tb_order_id_order",
                        column: x => x.id_order,
                        principalTable: "tb_order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_order_product_tb_product_id_product",
                        column: x => x.id_product,
                        principalTable: "tb_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Address_id_City",
                table: "tb_Address",
                column: "id_City");

            migrationBuilder.CreateIndex(
                name: "IX_tb_client_IdAddress",
                table: "tb_client",
                column: "IdAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_combo_id_image",
                table: "tb_combo",
                column: "id_image");

            migrationBuilder.CreateIndex(
                name: "IX_tb_image_product_id_product",
                table: "tb_image_product",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_id_client",
                table: "tb_order",
                column: "id_client");

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_product_id_order",
                table: "tb_order_product",
                column: "id_order");

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_product_id_product",
                table: "tb_order_product",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_id_category",
                table: "tb_product",
                column: "id_category");

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_combo_id_combo",
                table: "tb_product_combo",
                column: "id_combo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_promotion_product_id_image",
                table: "tb_promotion_product",
                column: "id_image");

            migrationBuilder.CreateIndex(
                name: "IX_tb_promotion_product_id_product",
                table: "tb_promotion_product",
                column: "id_product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_image_product");

            migrationBuilder.DropTable(
                name: "tb_order_product");

            migrationBuilder.DropTable(
                name: "tb_product_combo");

            migrationBuilder.DropTable(
                name: "tb_promotion_product");

            migrationBuilder.DropTable(
                name: "tb_order");

            migrationBuilder.DropTable(
                name: "tb_combo");

            migrationBuilder.DropTable(
                name: "tb_product");

            migrationBuilder.DropTable(
                name: "tb_client");

            migrationBuilder.DropTable(
                name: "tb_image");

            migrationBuilder.DropTable(
                name: "tb_category_product");

            migrationBuilder.DropTable(
                name: "tb_Address");

            migrationBuilder.DropTable(
                name: "tb_city");
        }
    }
}
