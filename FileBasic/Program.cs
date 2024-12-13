using System.Text;
namespace FileBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Hello, World!");
            //GetDriverInfo.GetDataDriver();
            //GetDriverInfo.generateFile();
            //GetDriverInfo.GetListDirectory();    
            string pathForder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            GetDriverInfo.GetListDirectoryRecursion(pathForder);
        }
    }
    public static class GetDriverInfo
    {
        public static void GetDataDriver()
        {
            DriveInfo[] allDriver = DriveInfo.GetDrives();

            foreach (DriveInfo drv in allDriver)
            {
                Console.WriteLine("Driver {0}", drv.Name);
                Console.WriteLine("Driver  type {0}", drv.DriveType);
                if (drv.IsReady)
                {
                    Console.WriteLine("Volume label {0,15}", drv.VolumeLabel);
                    Console.WriteLine("File system {0,15}", drv.DriveFormat);
                    Console.WriteLine("Avail space to current user {0,15}", drv.AvailableFreeSpace);
                    Console.WriteLine("total, free {0,15}", drv.TotalFreeSpace);
                    Console.WriteLine("total size {0,15}", drv.TotalSize);
                }

            }
            // Lấy thông tin về my documents của máy tính
            var path_doc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Console.WriteLine(path_doc);

        }
        public static void generateFile()
        {
            string fileName = "text.txt";
            string contentFile = "Hello I'm Backend developer c#";
            var doc_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var full_path = Path.Combine(doc_path, fileName);
            if (File.Exists(full_path))
            {
                string content = "File đã được thay thế";
                File.AppendAllText(full_path, content);
            }
            else
            {
                File.WriteAllText(full_path, contentFile);

            }
            Console.WriteLine("File đã được lưu tại: {0}", full_path);
            try
            {
                var rs = File.ReadAllText(full_path);
                File.Create(Path.Combine(doc_path, "hahaha.txt"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void GetListDirectory()
        {
            string pathForder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string[] files = Directory.GetFiles(pathForder);
            string[] directs = Directory.GetDirectories(pathForder);
            foreach (string file in files)
            {
                Console.WriteLine("File là :{0, 15}", file);
            }
            Console.WriteLine("--------------");
            foreach (string dr in directs)
            {
                Console.WriteLine("Direct là :{0, 15}", dr);
            }
        }
        public static void GetListDirectoryRecursion(string pathForder)
        {
            try
            {
            string[] directs = Directory.GetDirectories(pathForder);
                foreach (string direct in directs)
                {
                    Console.WriteLine("Direct là :{0, 15}", direct);
                    GetListDirectoryRecursion(direct);
                }
            }
            catch ( UnauthorizedAccessException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
           

        }
    }
}
