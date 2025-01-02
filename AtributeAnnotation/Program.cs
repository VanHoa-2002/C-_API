using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AtributeAnnotation
{
    internal class Program
    {
        [MetaAttribute("Show des")]
        [Required(ErrorMessage = "{0} cần thiết lập")]
        public int ID { get; set; }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Method)]
        public class MetaAttribute : Attribute
    {
        public string Description { get; set; }
        public MetaAttribute(string s) => Description = s;
    }
}
