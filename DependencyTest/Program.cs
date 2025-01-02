using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
namespace DependencyTest
{
    internal class Program
    {
        public static IClassB CreateB2(IServiceProvider provider)
        {
            var b2 = new ClassB2(
                provider.GetService<IClassC>()
                , "Run in class B2"
                );
            return b2;
        }
        public IConfiguration Configuration { get; }
        static void Main(string[] args)
        {
            IConfigurationRoot configurationRoot;
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName);
            configurationBuilder.AddJsonFile("config.json");
            configurationRoot = configurationBuilder.Build();
            var sectionMyServiceOpt = configurationRoot.GetSection(nameof(MyServiceOpt));

            var data1 = configurationRoot.GetSection("MyServiceOpt").GetSection("data1").Value;
            var data2 = configurationRoot.GetSection("MyServiceOpt").GetSection("data1").Value;
            Console.WriteLine(data1);
            // singleton 0
            //services.AddSingleton<IclassC, ClassC>();
            //transiont
            //services.AddTransient<IclassC, ClassC>();
            //scoped
            //services.AddScoped<IclassC, ClassC>();


            //var provider = services.BuildServiceProvider();

            //for(int i = 0; i < 5 ; i++)
            //{
            //    IclassC c = provider.GetService<IclassC>();
            //    Console.WriteLine(c.GetHashCode()); 
            //}

            //using (var scope = provider.CreateScope())
            //{
            //    var provider1 = scope.ServiceProvider;

            //    for (int i = 0; i < 5; i++)
            //    {
            //        IclassC c = provider1.GetService<IclassC>();
            //        Console.WriteLine(c.GetHashCode());
            //    }
            //}

            //services.AddSingleton<ClassA, ClassA>();
            //services.AddSingleton<IClassB, ClassB>();
            //services.AddSingleton<IClassC, ClassC>();
            //services.AddSingleton<IClassB>(CreateB2);
            //var provider = services.BuildServiceProvider();
            //ClassA a = provider.GetService<ClassA>();
            //ClassB b = provider.GetService<ClassB>();
            //ClassC c = provider.GetService<ClassC>();
            //a.ActionA();
            var services = new ServiceCollection();

            //services.Configure<MyServiceOpt>(sectionMyServiceOpt); // Đúng cách
            services.AddSingleton<MyService>();
            var provider = services.BuildServiceProvider();

            var myService = provider.GetService<MyService>();
            myService.Print();
        }
    }
    interface IClassB
    {
        public void ActionB();
    }
    interface IClassC
    {
        public void ActionC();
    }
    public class MyServiceOpt
    {
        public string data1 { get; set; }
        public int data2 { get; set; }
    }
    public class MyService
    {
        public string data1 { get; set; }
        public int data2 { get; set; }
        public MyService(IOptions<MyServiceOpt> opt)
        {
            var opts = opt.Value;
            data1 = opts.data1;
            data2 = opts.data2;
        }
        public void Print()
        {
            Console.WriteLine($"{data1} --- {data2}");
        }
    }
    class ClassC : IClassC
    {
        public ClassC() => Console.WriteLine("ClassC is created");
        public void ActionC() => Console.WriteLine("Action in ClassC");
    }

    class ClassB : IClassB
    {
        IClassC c_dependency;
        public ClassB(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB is created");
        }
        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }


    class ClassA
    {
        IClassB b_dependency;
        public ClassA(IClassB classb)
        {
            b_dependency = classb;
            Console.WriteLine("ClassA is created");
        }
        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }
    }
    class ClassB2 : IClassB
    {
        IClassC c_dependency;
        string message;
        public ClassB2(IClassC classc, string mgs)
        {
            c_dependency = classc;
            message = mgs;
            Console.WriteLine("ClassB2 is created");
        }
        public void ActionB()
        {
            Console.WriteLine(message);
            c_dependency.ActionC();
        }
    }
}
