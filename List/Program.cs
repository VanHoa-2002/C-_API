using System.Text;

namespace List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            List<Product> products = new List<Product>();
            var arrPrd = new Product[]
            {
                new Product(2,"Cá Hồi", "Japan",252),
                new Product(2,"Cá Trap", "USA",25858),
            };
            products.Add(new Product(1, "Máy tính", "VN", 500000000));
            products.AddRange(arrPrd);
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ToString("E_NAME"));
            //}
            // using delegate to find product 
            Product findName1 = products.Find(((Product prd) => prd.Name == "Cá Hồi"));
            //if (findName1 != null)
            //{
            //    Console.WriteLine(findName1.ToString("E_ORIGIN"));
            //}
            int ifound = products.FindIndex(x => x.Origin == "USA");
            List<Product> lstPrd = products.FindAll(prd =>
            {
                if (prd.Price > 100) return true;
                return false;
            }
            );
            //Console.WriteLine(products[ifound]);

            //foreach (var x in lstPrd)
            //{
            //    Console.WriteLine(x.ToString("E_NAME"));
            //}
            products.Sort();
            products.ForEach(x =>
            {
                Console.WriteLine(x.ToString("E_NAME"));
            });
        }
    }
}
public class Product : IComparable<Product>, IFormattable
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Origin { get; set; }
    public double Price { get; set; }

    // constructor 
    public Product(int id, string name, string origin, double price)
    {
        ID = id; Name = name; Origin = origin; Price = price;
    }
    public int CompareTo(Product product)
    {
        double delta = this.Price - product.Price;
        if (delta > 0) // Product have less price 
        {
            return -1;
        }
        else if (delta < 0)
        {
            return 1;
        }
        return 0;
    }
    public string ToString(string format, IFormatProvider formatProvider)
    {
        if (format == null) format = "E_ORIGIN";
        switch (format.ToUpper())
        {

            case "E_ORIGIN":
                return $"Xuất xứ : {Origin} - Tên : {Name} - Giá : {Price} - ID: {ID}";
            case "E_NAME":
                return $"Name : {Name} - Xuất xứ : {Origin} -  Giá : {Price} - ID: {ID}";
            default:
                throw new FormatException("Lỗi không hỗ trợ format này");
        }
    }
    public override string ToString()
    {
        return $"{Name} - {Price}";
    }
    public string ToString(string format) => this.ToString(format, null);
}

