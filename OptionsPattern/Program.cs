namespace OptionsPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public class PositionOptions
    {
        public const string Position = "Position";
        public string Title { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
    }
    public class Tess22Model : PageModel
    {
        private readonly IConfiguration Configuration;
        public PositionOptions? positionOptions { get; set; }
        public Test21Model (IConfiguration configuration){
            Configuration = configuration;
        } 

        public ContentResult OnGet()
        {
            var myKeyValue = Configuration["MyKey"];
            var title = Configuration["Position:Title"];
            var name = Configuration["Position:Name"];
            var defaultLogLevel = Configuration["Logging:LogLevel:Default"];


            return Content($"MyKey value: {myKeyValue} \n" +
                           $"Title: {title} \n" +
                           $"Name: {name} \n" +
                           $"Default Log Level: {defaultLogLevel}");
        }
    }
}

