namespace SortedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList <string, string >  product = new SortedList<string, string> ();
            product.Add ("Iphone", "Iphone 6s");
            product.Add ("Samsung", "Samsung A30");
            product.Add ("Vivo", "Vivo 56s");
            product["Sony"] = "Sony v5";
            foreach (KeyValuePair<string, string> kvp in product)
            {
                Console.WriteLine($"{kvp.Key} --- {kvp.Value}");
            }
        }
    }
}
