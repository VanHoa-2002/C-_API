using System.Reflection;

namespace TypeLearn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ABC a = new ABC() { ID = 1 , Name ="Yrach"};
            a.GetMess("áddd");
            foreach (PropertyInfo proper in a.GetType().GetProperties())
            {
                string property_name = proper.Name;
                Object value = proper.GetValue(a);
                Console.WriteLine($"Key : {property_name}, Value : {value}");
            }
        }
        public class ABC
        {
            public int ID { get; set; }
            public string Name { get; set; }
            [Obsolete("That methd is deprecate do not using")]
            public string GetMess(string mess)
            {
                return mess;
            }
        }
    }
}
