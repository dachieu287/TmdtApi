using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tmdt.Domain.Entities;

namespace Tmdt.Infrastructure.Persistence.Data
{
    public static class ApplicationContextSeed
    {
        public static async Task SeedAsync(IServiceProvider service)
        {
            var context = service.GetRequiredService<ApplicationContext>();

            await context.Database.EnsureCreatedAsync();
            if (!context.Products.Any())
            {
                context.Products.AddRange(GetProducts());
                await context.SaveChangesAsync();
            }
        }

        private static IEnumerable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Name = "Samsung Galaxy A32",
                    Price = 6690000,
                    ImageUrl = "samsung-galaxy-a32-4g-thumb-tim-600x600-600x600.jpg",
                    Description = "Samsung Galaxy A32 4G là chiếc điện thoại thuộc phân khúc tầm trung nhưng sở hữu nhiều ưu điểm vượt trội về màn hình lớn sắc nét, bộ bốn camera 64 MP cùng vi xử lý hiệu năng cao và được bán ra với mức giá vô cùng tốt."
                },
                new Product
                {
                    Name = "iPhone 12 64GB",
                    Price = 22990000,
                    ImageUrl = "iphone-12-xanh-duong-new-600x600-600x600.jpg",
                    Description = "Trong những tháng cuối năm 2020 Apple đã chính thức giới thiệu đến người dùng cũng như iFan thế hệ iPhone 12 series mới với hàng loạt tính năng bức phá, thiết kế được lột xác hoàn toàn, hiệu năng đầy mạnh mẽ và một trong số đó chính là iPhone 12 64GB."
                },
                new Product
                {
                    Name = "Xiaomi Redmi Note 10 (6GB/128GB)",
                    Price = 5490000,
                    ImageUrl = "xiaomi-redmi-note-10-thumb-green-600x600-1-600x600.jpg",
                    Description = "Xiaomi đã trình làng chiếc điện thoại mang tên gọi là Xiaomi Redmi Note 10 với điểm nhấn chính là cụm 4 camera 48 MP, chip rồng Snapdragon 678 mạnh mẽ cùng nhiều nâng cấp như dung lượng pin 5.000 mAh và hỗ trợ sạc nhanh 33 W tiện lợi."
                },
                new Product
                {
                    Name = "Samsung Galaxy A72",
                    Price = 11490000,
                    ImageUrl = "samsung-galaxy-a72-thumb-balck-600x600-600x600.jpg",
                    Description = "Sau khi thành công ở phân khúc smartphone cao cấp với Galaxy S21 series, Samsung tiếp tục tấn công phân khúc tầm trung với sự ra mắt của Samsung Galaxy A72 thuộc Galaxy A series, sở hữu nhiều màu sắc trẻ trung, hệ thống camera nhiều tính năng cũng như nâng cấp hiệu năng vô cùng lớn mang đến những trải nghiệm hoàn toàn mới."
                }
            };
        }
    }
}
