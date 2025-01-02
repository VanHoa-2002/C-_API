using Newtonsoft.Json;
using LabUtils;
using System.Text;
namespace usenpackage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product prd = new Product();
            prd.Name = "Test";
            prd.Description = "Test";
            prd.DateTime = DateTime.Now;
            prd.size = [1, 2, 5];
            string json = JsonConvert.SerializeObject(prd);
            Console.WriteLine(json);
            string jsonDecode = @"
            {""Name"":""Test"",""Description"":""Test"",""size"":[1,2,5],""DateTime"":""2024-12-19T10:23:08.2269292+07:00""}
";
            var prd2 = JsonConvert.DeserializeObject<Product>(jsonDecode);
            Console.WriteLine(prd2.DateTime.ToShortTimeString());
            Console.OutputEncoding = Encoding.Unicode;
           var rs =  ConvertMoneyToTextLib.ConvertMoneyToText(50000);
            Console.WriteLine(rs);
        }
    }
    class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int[] size { get; set; }
        public DateTime DateTime { get; set; }
        public Product() { }
    }

}
