using ThreadDemo;
namespace ExtensionMethod
{
    static class Abc
    {
        public static void Print(this string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string m = "Xin chao";
            m.Print(ConsoleColor.Red);
            "Hoa".Print(ConsoleColor.Magenta);
            int numer = 52;
            numer.binhPhuong();
            Console.WriteLine(numer.binhPhuong());
            Indexer idx = new Indexer();
            idx[0] = "hahahaha";
            float a = 56;
            var b = 0;
            var c = a / b;
            Console.WriteLine(c);
            try
            {
            Console.WriteLine(idx[0]);

            } catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            using (var dipose = new A())
            {
                Console.WriteLine("hello");
            }
        }

    }
    class Indexer
    {
        string name = "Hoa";
        string ho = "Tran";
        public string this[int index]
        {
            get
            {
                if (index == 0)
                {
                    return ho;
                }
                else if (index == 1)
                {
                    return name;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index == 0)
                {
                    ho = value;
                }
                else if (index == 1)
                {
                    name = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
      
    }
    class A : IDisposable
    {
        bool resource = true;
        public void Dispose()
        {
            Console.WriteLine("Goi khi ket thuc using");
            resource = false;
        }
    }
}
