using System.Net.Http.Headers;
using System.IO;
namespace Network
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var num = 3.331;
            Console.WriteLine(Math.Round(num, 2).ToString());
            /*  string url = "https://xuanthulab.net/lap-trinh/csharp/?page=3#acff";
              var uri = new Uri(url);
              var host = uri.Host;
              var uritype = typeof(Uri);
              uritype.GetProperties().ToList().ForEach(property => {
                  Console.WriteLine($"{property.Name,15} {property.GetValue(uri)}");
              });
              Console.WriteLine($"Segments: {string.Join(",", uri.Segments)}");*/
            //string url = "https://www.bootstrapcdn.com/";
            //var uri = new Uri(url);
            //var hostEntry = Dns.GetHostEntry(uri.Host);
            //Console.WriteLine($"Host {uri.Host} có các IP");
            //hostEntry.AddressList.ToList().ForEach(ip => Console.WriteLine(ip));
            /*        var ping = new Ping();
                    var pingReply = ping.Send("google.com.vn");
                    Console.WriteLine(pingReply.Status);
                    if (pingReply.Status == IPStatus.Success)
                    {
                        Console.WriteLine(pingReply.RoundtripTime);
                        Console.WriteLine(pingReply.Address);*/
            //}
            var url = "https://pedn.vnresource.net:1112/my-app/#/dashboard/portal";
            var html = await GetWebContent(url);
            string urlImage = "https://raw.githubusercontent.com/xuanthulabnet/jekyll-example/master/images/jekyll-01.png";
            var bytes = await DowloadData(urlImage);
            string filepath = "custom.jpg";
            using var stream = new FileStream(filepath, FileMode.Create, FileAccess.Write, FileShare.None);
            stream.Write(bytes, 0, bytes.Length);
            Console.WriteLine("save " + filepath);

        }
        static void showHeader(HttpResponseHeaders headers)
        {
            Console.WriteLine("header");
            foreach (var header in headers)
            {
                Console.WriteLine($"{header.Key} : {header.Value}");
            }
        }
        public static async Task<string> GetWebContent(string url)
        {
            using var httpClient = new HttpClient();
            try
            {
                //them header
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
                HttpResponseMessage resMess = await httpClient.GetAsync(url);
                showHeader(resMess.Headers); 
                string html = await resMess.Content.ReadAsStringAsync();
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Loi";
            }

        }   
        public static async Task<byte[]> DowloadData(string url)
        {
            using var httpClient = new HttpClient();
            try
            {
                //them header
                HttpResponseMessage resMess = await httpClient.GetAsync(url);
                showHeader(resMess.Headers); 
                var bytes = await resMess.Content.ReadAsByteArrayAsync();
                return bytes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
                //return "Loi";
            }

        }    
        public static async Task DowloadFileStream(string url, string fileName)
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                //them header
                HttpResponseMessage resMess = await httpClient.GetAsync(url);

               using var stream = await resMess.Content.ReadAsStreamAsync();
                int SIZE_BUFFER = 500;
                var buffer = new byte[SIZE_BUFFER];
                bool endread = false;
                do
                {
                    int numBytes = await stream.ReadAsync(buffer,0 , SIZE_BUFFER);
                    if (numBytes == 0) {
                    endread = true;
                    }
                    else
                    {

                    }
                }while
                (endread);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
