using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionsTech.MVC.Migrations
{
    /// <inheritdoc />
    public partial class SolutionsTech : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    IdBrand = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.IdBrand);
                });

            migrationBuilder.CreateTable(
                name: "FormPayment",
                columns: table => new
                {
                    IdFormPayment = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormPayment", x => x.IdFormPayment);
                });

            migrationBuilder.CreateTable(
                name: "TypeProcedure",
                columns: table => new
                {
                    IdTypeProcedure = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeProcedure", x => x.IdTypeProcedure);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DtDeactivation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserType = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    IdUserType = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.IdUserType);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    IdProduct = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    BrandIdBrand = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.IdProduct);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandIdBrand",
                        column: x => x.BrandIdBrand,
                        principalTable: "Brand",
                        principalColumn: "IdBrand",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scheduling",
                columns: table => new
                {
                    IdScheduling = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    IdFormPayment = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scheduling", x => x.IdScheduling);
                    table.ForeignKey(
                        name: "FK_Scheduling_FormPayment_IdFormPayment",
                        column: x => x.IdFormPayment,
                        principalTable: "FormPayment",
                        principalColumn: "IdFormPayment",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scheduling_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchedulingProcedure",
                columns: table => new
                {
                    IdSchedulingProcedure = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchedulingIdScheduling = table.Column<long>(type: "bigint", nullable: false),
                    TypeProcedureIdTypeProcedure = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulingProcedure", x => x.IdSchedulingProcedure);
                    table.ForeignKey(
                        name: "FK_SchedulingProcedure_Scheduling_SchedulingIdScheduling",
                        column: x => x.SchedulingIdScheduling,
                        principalTable: "Scheduling",
                        principalColumn: "IdScheduling",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchedulingProcedure_TypeProcedure_TypeProcedureIdTypeProcedure",
                        column: x => x.TypeProcedureIdTypeProcedure,
                        principalTable: "TypeProcedure",
                        principalColumn: "IdTypeProcedure",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchedulingProduct",
                columns: table => new
                {
                    IdSchedulingProduct = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchedulingIdScheduling = table.Column<long>(type: "bigint", nullable: false),
                    ProductIdProduct = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulingProduct", x => x.IdSchedulingProduct);
                    table.ForeignKey(
                        name: "FK_SchedulingProduct_Product_ProductIdProduct",
                        column: x => x.ProductIdProduct,
                        principalTable: "Product",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchedulingProduct_Scheduling_SchedulingIdScheduling",
                        column: x => x.SchedulingIdScheduling,
                        principalTable: "Scheduling",
                        principalColumn: "IdScheduling",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandIdBrand",
                table: "Product",
                column: "BrandIdBrand");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_IdFormPayment",
                table: "Scheduling",
                column: "IdFormPayment");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_IdUser",
                table: "Scheduling",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulingProcedure_SchedulingIdScheduling",
                table: "SchedulingProcedure",
                column: "SchedulingIdScheduling");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulingProcedure_TypeProcedureIdTypeProcedure",
                table: "SchedulingProcedure",
                column: "TypeProcedureIdTypeProcedure");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulingProduct_ProductIdProduct",
                table: "SchedulingProduct",
                column: "ProductIdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulingProduct_SchedulingIdScheduling",
                table: "SchedulingProduct",
                column: "SchedulingIdScheduling");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchedulingProcedure");

            migrationBuilder.DropTable(
                name: "SchedulingProduct");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "TypeProcedure");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Scheduling");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "FormPayment");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
