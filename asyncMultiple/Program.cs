using System.Net;

namespace asyncMultiple
{
    public delegate void Showlog(string message);


    internal class Program
    {
        static async Task Main(string[] args)
        {
            Showlog log = warning;
            //log("Run delegate");
            //log?.Invoke("hahaha");

            string url = "https://code.visualstudio.com/";
            //DowloadWeb01.TestDownload(url);
            Task t3 = Task2();
            Task t4 = Task3();
            Task Async1 = TestAsync.Async1("a","b");
            await t3;
            await t4;
            //string kq = await Async1;
            Console.WriteLine("sad");
            var task = GetWeb(url);
            var kq = await task;
            Console.WriteLine(kq.Substring(0,12));
            Console.WriteLine("Done TASK");
        }
        static async Task Task2() {
            Task t3 = new Task((object ob) =>
            {
            string tenTacVu = (string)ob;
            info(tenTacVu);
        }, "heelo");

            t3.Start();
            await t3;
            Console.WriteLine("Done t2");
        }      
        static async Task Task3() {
            Task t4 = new Task((object ob) =>
            {
            string tenTacVu = (string)ob;
            info(tenTacVu);
        }, "heelo");
            t4.Start();
            await t4;
            Console.WriteLine("Done t3");
   
        }
        static void info(string message)
        {
            Console.WriteLine(message);
        }
        static void warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        static async Task<string> GetWeb(string url)
        {
            HttpClient httpClient = new HttpClient();
            Console.WriteLine("Readweb");
            HttpResponseMessage kq = await httpClient.GetAsync(url);
            string content = await kq.Content.ReadAsStringAsync();
            Console.WriteLine("Done read");
            return content;
        }
    }
    
    public static class TestAsync
    {
        public static void WriteLine(string mess, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(mess);
            Console.ResetColor();
        }

        public static async Task<string> Async1(string thamso1, string thamso2)
        {
            Func<object, string> myfunc = (object thamso) =>
            {
                dynamic ts = thamso;
                for (int i = 1; i <= 10; i++)
                {
                    WriteLine($"{i,5} {Thread.CurrentThread.ManagedThreadId,3} Tham so {ts.x} {ts.y}", ConsoleColor.Green);
                     Task.Delay(500);
                }
                return $"Shut down Async 1 {ts.x}";
            };

            Task<string> task = new Task<string>(myfunc, new { x = thamso1, y = thamso2 });
            task.Start();
            Console.WriteLine("Do something .....");
            var kq = await task;
            return kq;
        }
    }
    public class DowloadWeb01
    {
        public static string DowloaddWebPage(string url, bool showRs)
        {
            using (var client = new WebClient())
            {
                Console.WriteLine("Start loading ...");
                string content = client.DownloadString(url);
                Thread.Sleep(3000);
                if (showRs)
                {
                    Console.WriteLine(content.Substring(0, 150));
                }
                return content;
            }

        }
        public static void TestDownload(string url)
        {
            DowloaddWebPage(url, true);
            Console.WriteLine("Do something...");
        }
    }
}
