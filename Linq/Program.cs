using System.Text;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            List<Brand> brand = new List<Brand>()
            {
               new Brand {ID  = 1, Name="FPT" },
               new Brand {ID  = 2, Name="FGL" },
               new Brand {ID  = 3, Name="TPC" },
            };
            var products = new List<Product>()
            {
                new Product(1, "Bàn trà", 400, new string[] { "Xám", "Xanh" }, 2),
                new Product(2, "Ghế sofa", 1200, new string[] { "Đen", "Xám", "Be" }, 1),
                new Product(3, "Tủ quần áo", 2500, new string[] { "Trắng", "Nâu", "Xanh" }, 1),
                new Product(4, "Giường ngủ", 1800, new string[] { "Gỗ tự nhiên", "Trắng" }, 3),
                new Product(5, "Kệ sách", 750, new string[] { "Nâu", "Đen" }, 2),
                new Product(6, "Bàn làm việc", 1200, new string[] { "Trắng", "Nâu nhạt" }, 2),
                new Product(7, "Ghế xoay", 500, new string[] { "Đỏ", "Đen", "Xám" }, 3),
                new Product(8, "Tủ lạnh mini", 2300, new string[] { "Trắng", "Xám bạc" }, 2),
                new Product(9, "Đèn bàn", 300, new string[] { "Vàng", "Trắng" }, 2),
                new Product(10, "Máy lọc không khí", 3200, new string[] { "Trắng", "Đen" }, 5),

            };
            //Product.ProductPrice400(products);
            Product.QueryWithJoin(products,brand);


        }
        class Product
        {
            private int ID { get; set; }
            private string Name { get; set; }
            private double Price { get; set; }
            public string[] Colors { get; set; }
            public int Brand { get; set; }
            public Product(int id, string name, double price, string[] colors, int brand)
            {
                ID = id;
                Name = name;
                Price = price;
                Colors = colors;
                Brand = brand;
            }
            public override string ToString()
            {
                return $"{ID,3} {Price,3} {Brand,3} {String.Join(",", Colors),3} {Name,3}";
            }
            public static void ProductPrice400(List<Product> products)
            {
                var result = from product in products
                             where product.Price > 500
                             //where product.Name.StartsWith("Đèn")
                             //orderby product.ID descending, product.Price ascending
                             group product by product.Price into gr
                             let count = gr.Count()
                             orderby gr.Key descending
                             select new
                             {
                                 price = gr.Key,
                                 number_product = count
                             };


                //select new
                //{
                //    ID = product.ID,
                //    Mau = String.Join(",", product.Colors),
                //    Name = product.Name,
                //    Price = product.Price,

                //};

                //foreach (var gr in result)
                //{
                //    Console.WriteLine(gr.Key);
                //    foreach (var product in gr)
                //    {
                //        Console.WriteLine(product.ToString());
                //    }
                //}


                foreach (var product in result)
                {
                    Console.WriteLine(product.ToString());
                }

            }
            public static void QueryWithJoin(List<Product> products, List<Brand> brands)
            {
                // if not contain brand of product in brands array it will ignore that product or return default of left join 
                var result = from product in products
                             join brand in brands on product.Brand equals (brand.ID) into temp
                             from brand in temp.DefaultIfEmpty()
                             where product.Price > 500
                             select new
                             {
                                 Name = product.Name,
                                 Price = product.Price,
                                 Brand = (brand == null)? "Default no brand" : brand.Name,
                             };
                foreach (var item in result)
                {
                    Console.WriteLine(item.ToString());
                }
            }    
        }
        public class Brand
        {
            public string Name { get; set; }
            public int ID { get; set; }

        }
    }
}
