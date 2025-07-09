using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace item_management.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OUOM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OUOM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OWHS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WhsCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WhsName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OWHS", x => x.Id);
                    table.UniqueConstraint("AK_OWHS_WhsCode", x => x.WhsCode);
                });

            migrationBuilder.CreateTable(
                name: "OUGP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUom = table.Column<int>(type: "int", nullable: false),
                    BaseUnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OUGP", x => x.Id);
                    table.UniqueConstraint("AK_OUGP_Code", x => x.Code);
                    table.ForeignKey(
                        name: "FK_OUGP_OUOM_BaseUnitId",
                        column: x => x.BaseUnitId,
                        principalTable: "OUOM",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OUGP_OUOM_BaseUom",
                        column: x => x.BaseUom,
                        principalTable: "OUOM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OITM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ItemGroup = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OUGPId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OITM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OITM_OUGP_OUGPId",
                        column: x => x.OUGPId,
                        principalTable: "OUGP",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UGP1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FatherId = table.Column<int>(type: "int", nullable: false),
                    AlternateUoM = table.Column<int>(type: "int", nullable: false),
                    AltQty = table.Column<double>(type: "float", nullable: false),
                    BaseQty = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UGP1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UGP1_OUGP_FatherId",
                        column: x => x.FatherId,
                        principalTable: "OUGP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UGP1_OUOM_AlternateUoM",
                        column: x => x.AlternateUoM,
                        principalTable: "OUOM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OITW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    WarehouseCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    QuantityOnHand = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    OWHSId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OITW", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OITW_OITM_ItemId",
                        column: x => x.ItemId,
                        principalTable: "OITM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OITW_OWHS_OWHSId",
                        column: x => x.OWHSId,
                        principalTable: "OWHS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OITW_OWHS_WarehouseCode",
                        column: x => x.WarehouseCode,
                        principalTable: "OWHS",
                        principalColumn: "WhsCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "OUOM",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "UOM001", "Cái" },
                    { 2, "UOM002", "Hộp" },
                    { 3, "UOM003", "Bộ" },
                    { 4, "UOM004", "Thùng" },
                    { 5, "UOM005", "Kilogram" },
                    { 6, "UOM006", "Chiếc" },
                    { 7, "UOM007", "Gói" }
                });

            migrationBuilder.InsertData(
                table: "OWHS",
                columns: new[] { "Id", "WhsCode", "WhsName" },
                values: new object[,]
                {
                    { 1, "WH-HN", "Kho Hà Nội" },
                    { 2, "WH-HCM", "Kho TP.HCM" },
                    { 3, "WH-DN", "Kho Đà Nẵng" },
                    { 4, "WH-BD", "Kho Bình Dương" },
                    { 5, "WH-CT", "Kho Cần Thơ" }
                });

            migrationBuilder.InsertData(
                table: "OUGP",
                columns: new[] { "Id", "BaseUnitId", "BaseUom", "Code", "Name" },
                values: new object[,]
                {
                    { 1, null, 1, "ELEC001", "Điện tử" },
                    { 2, null, 1, "FURN001", "Nội thất" },
                    { 3, null, 1, "HOME001", "Gia dụng" },
                    { 4, null, 1, "BOOK001", "Sách văn phòng phẩm" },
                    { 5, null, 6, "CLTH001", "Quần áo" }
                });

            migrationBuilder.InsertData(
                table: "OITM",
                columns: new[] { "Id", "IsActive", "ItemCode", "ItemGroup", "ItemName", "OUGPId", "Price" },
                values: new object[,]
                {
                    { 1, true, "SP001", "Điện tử - Smartphone", "iPhone 15 Pro Max 256GB", "ELEC001", 29999000m },
                    { 2, true, "SP002", "Điện tử - Laptop", "MacBook Air M2 13 inch", "ELEC001", 27999000m },
                    { 3, true, "SP003", "Điện tử - Smartphone", "Samsung Galaxy S24 Ultra", "ELEC001", 26999000m },
                    { 4, true, "SP004", "Điện tử - Laptop", "Dell XPS 13 Plus", "ELEC001", 35999000m },
                    { 5, true, "SP005", "Điện tử - Tablet", "iPad Pro 12.9 inch M2", "ELEC001", 25999000m },
                    { 6, true, "SP006", "Điện tử - Tai nghe", "AirPods Pro 2", "ELEC001", 5999000m },
                    { 7, true, "SP007", "Điện tử - Đồng hồ thông minh", "Apple Watch Series 9", "ELEC001", 8999000m },
                    { 8, true, "SP008", "Nội thất - Bàn", "Bàn làm việc gỗ Oak", "FURN001", 4500000m },
                    { 9, true, "SP009", "Nội thất - Ghế", "Ghế ergonomic Herman Miller", "FURN001", 12000000m },
                    { 10, true, "SP010", "Nội thất - Kệ", "Kệ sách gỗ tự nhiên", "FURN001", 2800000m },
                    { 11, true, "SP011", "Nội thất - Tủ", "Tủ quần áo 3 cửa", "FURN001", 8500000m },
                    { 12, true, "SP012", "Nội thất - Sofa", "Sofa da 3 chỗ ngồi", "FURN001", 15000000m },
                    { 13, true, "SP013", "Gia dụng - Tủ lạnh", "Tủ lạnh Samsung 360L", "HOME001", 15500000m },
                    { 14, true, "SP014", "Gia dụng - Máy giặt", "Máy giặt LG 9kg", "HOME001", 8999000m },
                    { 15, true, "SP015", "Gia dụng - Điều hòa", "Điều hòa Daikin 12000 BTU", "HOME001", 12500000m },
                    { 16, true, "SP016", "Gia dụng - Lò vi sóng", "Lò vi sóng Panasonic 25L", "HOME001", 3500000m },
                    { 17, true, "SP017", "Sách - Công nghệ", "Bộ sách lập trình C#", "BOOK001", 850000m },
                    { 18, true, "SP018", "Văn phòng phẩm - Bút", "Bút bi Parker", "BOOK001", 250000m },
                    { 19, true, "SP019", "Thời trang - Áo sơ mi", "Áo sơ mi nam công sở", "CLTH001", 450000m },
                    { 20, false, "SP020", "Thời trang - Quần", "Quần jean nữ skinny", "CLTH001", 680000m }
                });

            migrationBuilder.InsertData(
                table: "UGP1",
                columns: new[] { "Id", "AltQty", "AlternateUoM", "BaseQty", "FatherId" },
                values: new object[,]
                {
                    { 1, 1.0, 2, 10.0, 1 },
                    { 2, 1.0, 3, 5.0, 1 },
                    { 3, 1.0, 4, 50.0, 1 },
                    { 4, 1.0, 3, 2.0, 2 },
                    { 5, 1.0, 4, 20.0, 2 },
                    { 6, 1.0, 2, 8.0, 3 },
                    { 7, 1.0, 4, 30.0, 3 },
                    { 8, 1.0, 7, 12.0, 4 },
                    { 9, 1.0, 4, 100.0, 4 },
                    { 10, 1.0, 7, 3.0, 5 },
                    { 11, 1.0, 4, 50.0, 5 }
                });

            migrationBuilder.InsertData(
                table: "OITW",
                columns: new[] { "Id", "ItemId", "OWHSId", "QuantityOnHand", "WarehouseCode" },
                values: new object[,]
                {
                    { 1, 1, null, 45m, "WH-HN" },
                    { 2, 1, null, 62m, "WH-HCM" },
                    { 3, 1, null, 28m, "WH-DN" },
                    { 4, 2, null, 32m, "WH-HN" },
                    { 5, 2, null, 28m, "WH-HCM" },
                    { 6, 3, null, 38m, "WH-HN" },
                    { 7, 3, null, 55m, "WH-HCM" },
                    { 8, 8, null, 25m, "WH-BD" },
                    { 9, 8, null, 15m, "WH-HN" },
                    { 10, 9, null, 8m, "WH-HN" },
                    { 11, 9, null, 12m, "WH-HCM" },
                    { 12, 13, null, 35m, "WH-HN" },
                    { 13, 13, null, 42m, "WH-HCM" },
                    { 14, 17, null, 150m, "WH-HN" },
                    { 15, 19, null, 200m, "WH-HCM" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OITM_ItemCode",
                table: "OITM",
                column: "ItemCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OITM_OUGPId",
                table: "OITM",
                column: "OUGPId");

            migrationBuilder.CreateIndex(
                name: "IX_OITW_ItemId_WarehouseCode",
                table: "OITW",
                columns: new[] { "ItemId", "WarehouseCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OITW_OWHSId",
                table: "OITW",
                column: "OWHSId");

            migrationBuilder.CreateIndex(
                name: "IX_OITW_WarehouseCode",
                table: "OITW",
                column: "WarehouseCode");

            migrationBuilder.CreateIndex(
                name: "IX_OUGP_BaseUnitId",
                table: "OUGP",
                column: "BaseUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_OUGP_BaseUom",
                table: "OUGP",
                column: "BaseUom");

            migrationBuilder.CreateIndex(
                name: "IX_OUGP_Code",
                table: "OUGP",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OUOM_Code",
                table: "OUOM",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OWHS_WhsCode",
                table: "OWHS",
                column: "WhsCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UGP1_AlternateUoM",
                table: "UGP1",
                column: "AlternateUoM");

            migrationBuilder.CreateIndex(
                name: "IX_UGP1_FatherId_AlternateUoM",
                table: "UGP1",
                columns: new[] { "FatherId", "AlternateUoM" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OITW");

            migrationBuilder.DropTable(
                name: "UGP1");

            migrationBuilder.DropTable(
                name: "OITM");

            migrationBuilder.DropTable(
                name: "OWHS");

            migrationBuilder.DropTable(
                name: "OUGP");

            migrationBuilder.DropTable(
                name: "OUOM");
        }
    }
}
