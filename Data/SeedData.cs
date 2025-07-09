using Microsoft.EntityFrameworkCore;
using item_management.Models;
using System.Collections.Generic;

namespace item_management.Data
{
    public static class SeedData
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {
            // Seed OUOM (Đơn vị tính)
            var uoms = new List<OUOM>
            {
                new() { Id = 1, Code = "UOM001", Name = "Cái" },
                new() { Id = 2, Code = "UOM002", Name = "Hộp" },
                new OUOM { Id = 3, Code = "UOM003", Name = "Bộ" },
                new OUOM { Id = 4, Code = "UOM004", Name = "Thùng" },
                new OUOM { Id = 5, Code = "UOM005", Name = "Kilogram" },
                new OUOM { Id = 6, Code = "UOM006", Name = "Chiếc" },
                new OUOM { Id = 7, Code = "UOM007", Name = "Gói" }
            };
            modelBuilder.Entity<OUOM>().HasData(uoms);

            // Seed OUGP (Nhóm đơn vị tính)
            var unitGroups = new List<OUGP>
            {
                new OUGP { Id = 1, Code = "ELEC001", Name = "Điện tử", BaseUom = 1 },
                new OUGP { Id = 2, Code = "FURN001", Name = "Nội thất", BaseUom = 1 },
                new OUGP { Id = 3, Code = "HOME001", Name = "Gia dụng", BaseUom = 1 },
                new OUGP { Id = 4, Code = "BOOK001", Name = "Sách văn phòng phẩm", BaseUom = 1 },
                new OUGP { Id = 5, Code = "CLTH001", Name = "Quần áo", BaseUom = 6 }
            };
            modelBuilder.Entity<OUGP>().HasData(unitGroups);

            // Seed UGP1 (Quy đổi đơn vị tính)
            var conversions = new List<UGP1>
            {
                // Quy đổi cho nhóm Điện tử (ELEC001)
                new UGP1 { Id = 1, FatherId = 1, AlternateUoM = 2, AltQty = 1, BaseQty = 10 }, // 1 hộp = 10 cái
                new UGP1 { Id = 2, FatherId = 1, AlternateUoM = 3, AltQty = 1, BaseQty = 5 },  // 1 bộ = 5 cái
                new UGP1 { Id = 3, FatherId = 1, AlternateUoM = 4, AltQty = 1, BaseQty = 50 }, // 1 thùng = 50 cái
                
                // Quy đổi cho nhóm Nội thất (FURN001)
                new UGP1 { Id = 4, FatherId = 2, AlternateUoM = 3, AltQty = 1, BaseQty = 2 },  // 1 bộ = 2 cái
                new UGP1 { Id = 5, FatherId = 2, AlternateUoM = 4, AltQty = 1, BaseQty = 20 }, // 1 thùng = 20 cái
                
                // Quy đổi cho nhóm Gia dụng (HOME001)
                new UGP1 { Id = 6, FatherId = 3, AlternateUoM = 2, AltQty = 1, BaseQty = 8 },  // 1 hộp = 8 cái
                new UGP1 { Id = 7, FatherId = 3, AlternateUoM = 4, AltQty = 1, BaseQty = 30 }, // 1 thùng = 30 cái
                
                // Quy đổi cho nhóm Sách văn phòng phẩm (BOOK001)
                new UGP1 { Id = 8, FatherId = 4, AlternateUoM = 7, AltQty = 1, BaseQty = 12 }, // 1 gói = 12 cái
                new UGP1 { Id = 9, FatherId = 4, AlternateUoM = 4, AltQty = 1, BaseQty = 100 }, // 1 thùng = 100 cái
                
                // Quy đổi cho nhóm Quần áo (CLTH001)
                new UGP1 { Id = 10, FatherId = 5, AlternateUoM = 7, AltQty = 1, BaseQty = 3 }, // 1 gói = 3 chiếc
                new UGP1 { Id = 11, FatherId = 5, AlternateUoM = 4, AltQty = 1, BaseQty = 50 } // 1 thùng = 50 chiếc
            };
            modelBuilder.Entity<UGP1>().HasData(conversions);

            // Seed OWHS (Kho hàng)
            var warehouses = new List<OWHS>
            {
                new OWHS { Id = 1, WhsCode = "WH-HN", WhsName = "Kho Hà Nội" },
                new OWHS { Id = 2, WhsCode = "WH-HCM", WhsName = "Kho TP.HCM" },
                new OWHS { Id = 3, WhsCode = "WH-DN", WhsName = "Kho Đà Nẵng" },
                new OWHS { Id = 4, WhsCode = "WH-BD", WhsName = "Kho Bình Dương" },
                new OWHS { Id = 5, WhsCode = "WH-CT", WhsName = "Kho Cần Thơ" }
            };
            modelBuilder.Entity<OWHS>().HasData(warehouses);

            // Seed OITM (Mặt hàng) - 20 items
            var items = new List<OITM>
            {
                // Điện tử (ELEC001)
                new OITM { Id = 1, ItemCode = "SP001", ItemName = "iPhone 15 Pro Max 256GB", ItemGroup = "Điện tử - Smartphone", OUGPId = "ELEC001", Price = 29999000m, IsActive = true },
                new OITM { Id = 2, ItemCode = "SP002", ItemName = "MacBook Air M2 13 inch", ItemGroup = "Điện tử - Laptop", OUGPId = "ELEC001", Price = 27999000m, IsActive = true },
                new OITM { Id = 3, ItemCode = "SP003", ItemName = "Samsung Galaxy S24 Ultra", ItemGroup = "Điện tử - Smartphone", OUGPId = "ELEC001", Price = 26999000m, IsActive = true },
                new OITM { Id = 4, ItemCode = "SP004", ItemName = "Dell XPS 13 Plus", ItemGroup = "Điện tử - Laptop", OUGPId = "ELEC001", Price = 35999000m, IsActive = true },
                new OITM { Id = 5, ItemCode = "SP005", ItemName = "iPad Pro 12.9 inch M2", ItemGroup = "Điện tử - Tablet", OUGPId = "ELEC001", Price = 25999000m, IsActive = true },
                new OITM { Id = 6, ItemCode = "SP006", ItemName = "AirPods Pro 2", ItemGroup = "Điện tử - Tai nghe", OUGPId = "ELEC001", Price = 5999000m, IsActive = true },
                new OITM { Id = 7, ItemCode = "SP007", ItemName = "Apple Watch Series 9", ItemGroup = "Điện tử - Đồng hồ thông minh", OUGPId = "ELEC001", Price = 8999000m, IsActive = true },
                
                // Nội thất (FURN001)
                new OITM { Id = 8, ItemCode = "SP008", ItemName = "Bàn làm việc gỗ Oak", ItemGroup = "Nội thất - Bàn", OUGPId = "FURN001", Price = 4500000m, IsActive = true },
                new OITM { Id = 9, ItemCode = "SP009", ItemName = "Ghế ergonomic Herman Miller", ItemGroup = "Nội thất - Ghế", OUGPId = "FURN001", Price = 12000000m, IsActive = true },
                new OITM { Id = 10, ItemCode = "SP010", ItemName = "Kệ sách gỗ tự nhiên", ItemGroup = "Nội thất - Kệ", OUGPId = "FURN001", Price = 2800000m, IsActive = true },
                new OITM { Id = 11, ItemCode = "SP011", ItemName = "Tủ quần áo 3 cửa", ItemGroup = "Nội thất - Tủ", OUGPId = "FURN001", Price = 8500000m, IsActive = true },
                new OITM { Id = 12, ItemCode = "SP012", ItemName = "Sofa da 3 chỗ ngồi", ItemGroup = "Nội thất - Sofa", OUGPId = "FURN001", Price = 15000000m, IsActive = true },
                
                // Gia dụng (HOME001)
                new OITM { Id = 13, ItemCode = "SP013", ItemName = "Tủ lạnh Samsung 360L", ItemGroup = "Gia dụng - Tủ lạnh", OUGPId = "HOME001", Price = 15500000m, IsActive = true },
                new OITM { Id = 14, ItemCode = "SP014", ItemName = "Máy giặt LG 9kg", ItemGroup = "Gia dụng - Máy giặt", OUGPId = "HOME001", Price = 8999000m, IsActive = true },
                new OITM { Id = 15, ItemCode = "SP015", ItemName = "Điều hòa Daikin 12000 BTU", ItemGroup = "Gia dụng - Điều hòa", OUGPId = "HOME001", Price = 12500000m, IsActive = true },
                new OITM { Id = 16, ItemCode = "SP016", ItemName = "Lò vi sóng Panasonic 25L", ItemGroup = "Gia dụng - Lò vi sóng", OUGPId = "HOME001", Price = 3500000m, IsActive = true },
                
                // Sách văn phòng phẩm (BOOK001)
                new OITM { Id = 17, ItemCode = "SP017", ItemName = "Bộ sách lập trình C#", ItemGroup = "Sách - Công nghệ", OUGPId = "BOOK001", Price = 850000m, IsActive = true },
                new OITM { Id = 18, ItemCode = "SP018", ItemName = "Bút bi Parker", ItemGroup = "Văn phòng phẩm - Bút", OUGPId = "BOOK001", Price = 250000m, IsActive = true },
                
                // Quần áo (CLTH001)
                new OITM { Id = 19, ItemCode = "SP019", ItemName = "Áo sơ mi nam công sở", ItemGroup = "Thời trang - Áo sơ mi", OUGPId = "CLTH001", Price = 450000m, IsActive = true },
                new OITM { Id = 20, ItemCode = "SP020", ItemName = "Quần jean nữ skinny", ItemGroup = "Thời trang - Quần", OUGPId = "CLTH001", Price = 680000m, IsActive = false } // Inactive item
            };
            modelBuilder.Entity<OITM>().HasData(items);

            // Seed OITW (Tồn kho) - 15 records với sự phân bố có ý nghĩa
            var warehouseStocks = new List<OITW>
            {
                // iPhone 15 Pro Max - phân bố nhiều kho do nhu cầu cao
                new OITW { Id = 1, ItemId = 1, WarehouseCode = "WH-HN", QuantityOnHand = 45m },
                new OITW { Id = 2, ItemId = 1, WarehouseCode = "WH-HCM", QuantityOnHand = 62m },
                new OITW { Id = 3, ItemId = 1, WarehouseCode = "WH-DN", QuantityOnHand = 28m },
                
                // MacBook Air M2 - chỉ ở các kho lớn
                new OITW { Id = 4, ItemId = 2, WarehouseCode = "WH-HN", QuantityOnHand = 32m },
                new OITW { Id = 5, ItemId = 2, WarehouseCode = "WH-HCM", QuantityOnHand = 28m },
                
                // Samsung Galaxy S24 - phân bố rộng
                new OITW { Id = 6, ItemId = 3, WarehouseCode = "WH-HN", QuantityOnHand = 38m },
                new OITW { Id = 7, ItemId = 3, WarehouseCode = "WH-HCM", QuantityOnHand = 55m },
                
                // Bàn làm việc gỗ Oak - tập trung ở kho gần nhà máy
                new OITW { Id = 8, ItemId = 8, WarehouseCode = "WH-BD", QuantityOnHand = 25m },
                new OITW { Id = 9, ItemId = 8, WarehouseCode = "WH-HN", QuantityOnHand = 15m },
                
                // Ghế ergonomic - hàng cao cấp, ít kho
                new OITW { Id = 10, ItemId = 9, WarehouseCode = "WH-HN", QuantityOnHand = 8m },
                new OITW { Id = 11, ItemId = 9, WarehouseCode = "WH-HCM", QuantityOnHand = 12m },
                
                // Tủ lạnh Samsung - phân bố đều
                new OITW { Id = 12, ItemId = 13, WarehouseCode = "WH-HN", QuantityOnHand = 35m },
                new OITW { Id = 13, ItemId = 13, WarehouseCode = "WH-HCM", QuantityOnHand = 42m },
                
                // Bộ sách lập trình - tập trung ở kho miền Bắc
                new OITW { Id = 14, ItemId = 17, WarehouseCode = "WH-HN", QuantityOnHand = 150m },
                
                // Áo sơ mi nam - hàng thời trang, nhiều kho
                new OITW { Id = 15, ItemId = 19, WarehouseCode = "WH-HCM", QuantityOnHand = 200m }
            };
            modelBuilder.Entity<OITW>().HasData(warehouseStocks);
        }
    }
}