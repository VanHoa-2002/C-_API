using System.Text;
namespace StreamTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stream stream = new MemoryStream();
            for (int i = 0; i < 122; i++)
            {
                stream.WriteByte((byte)i);
            }
            stream.Position = 0;

            //Đọc từng block 5 bytes

            //byte[] buffer = new byte[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //int offset = 0;
            //int count = 5;
            //int numByte = stream.Read(buffer, 0, 2);
            //while (numByte != 0)
            //{
            //    Console.Write($"{numByte} byte");
            //    for (int i = 1; i <= numByte; i++)
            //    {
            //        byte b = buffer[i - 1];
            //        Console.Write(b);
            //    }
            //    numByte = stream.Read(buffer, offset, count);
            //    Console.WriteLine();
            //}
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "text.txt");
            string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "save.txt");
            // check data of that file 
            //Stream str = WorkWithStream(filePath);
            //Encoding rs = GetEncoding(str);
            //Console.WriteLine(rs.GetString(buffer));
            //WriteWithStream(filePath);
            int MAX_BUFFER = 5;
            //ReadFileStream(filePath, MAX_BUFFER);
            ReadAndSaveStream(filePath, MAX_BUFFER, savePath);
        }
        public static Stream WorkWithStream(string filePath)
        {
            using (var stream = new FileStream(path: filePath, mode: FileMode.Open, access: FileAccess.ReadWrite, share: FileShare.None))
            {
                Console.WriteLine(stream.Name);
                Console.WriteLine($"Size of stream {stream.Length} bytes/ Position {stream.Position}");
                Console.WriteLine($"Permission of stream:" +
                    $"Read: {stream.CanRead}, Write: {stream.CanWrite}, Shared: {stream.CanSeek}");
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                memoryStream.Position = 0;
                return memoryStream;
            }
        }
        public static Encoding GetEncoding(Stream stream)
        {
            byte[] BOMBytes = new byte[4]; // mảng chứa 4 byte để làm bộ nhớ lưu byte đọc được
            int offset = 0; // vị trí (index) trong buffer - nơi ghi byte đầu tiên đọc được
            int count = 4; // đọc 4 byte
            int numberbyte = stream.Read(BOMBytes, offset, count); // bắt đầu đọc 4 đầu tiên lưu vào buffer

            if (BOMBytes[0] == 0xfe && BOMBytes[1] == 0xff)
            {
                stream.Seek(2, SeekOrigin.Begin); // Di chuyển về vị trí bắt đầu của dữ liệu (đã trừ BOM)
                return Encoding.BigEndianUnicode;
            }
            if (BOMBytes[0] == 0xff && BOMBytes[1] == 0xfe)
            {
                stream.Seek(2, SeekOrigin.Begin); // Di chuyển về vị trí bắt đầu của dữ liệu (đã trừ BOM)
                return Encoding.Unicode;
            }

            if (BOMBytes[0] == 0xef && BOMBytes[1] == 0xbb && BOMBytes[2] == 0xbf)
            {
                stream.Seek(3, SeekOrigin.Begin);
                return Encoding.UTF8;
            }
            if (BOMBytes[0] == 0x2b && BOMBytes[1] == 0x2f && BOMBytes[2] == 0x76)
            {
                stream.Seek(3, SeekOrigin.Begin);
                return Encoding.UTF7;
            }
            if (BOMBytes[0] == 0xff && BOMBytes[1] == 0xfe && BOMBytes[2] == 0 && BOMBytes[3] == 0)
            {
                stream.Seek(4, SeekOrigin.Begin);
                return Encoding.UTF32;
            }
            if (BOMBytes[0] == 0 && BOMBytes[1] == 0 && BOMBytes[2] == 0xfe && BOMBytes[3] == 0xff)
            {
                stream.Seek(4, SeekOrigin.Begin);
                return Encoding.GetEncoding(12001);
            }

            stream.Seek(0, SeekOrigin.Begin);
            return Encoding.Default;

        }
        public static void WriteWithStream(string path)
        {
            using (var stream = new FileStream(path: path, mode: FileMode.Create))
            {
                Encoding encode = Encoding.UTF8;
                byte[] bom = encode.GetPreamble();

                stream.Write(bom, 0, bom.Length);
                string s1 = "Xin chào các bạn trẻ";
                string s2 = "Ví dụ- from stream";
                byte[] buffer = encode.GetBytes(s1);
                stream.Write(buffer, 0, buffer.Length);
                buffer = encode.GetBytes(s2);
                stream.Write(buffer, 0, buffer.Length);
                Console.WriteLine("Success writing !");
            }
        }

        public static void ReadFileStream(string path, int sizeBuffer)
        {
            using (var stream = new FileStream(path: path, mode: FileMode.Open))
            {
                Encoding encode = GetEncoding(stream);
                Console.WriteLine(encode.ToString());
                byte[] buffer = new byte[sizeBuffer];
                bool end = false;
                do
                {
                    int numberRead = stream.Read(buffer, 0, sizeBuffer);
                    if (numberRead == 0) end = true;
                    if (numberRead < sizeBuffer)
                    {
                        Array.Clear(buffer, numberRead, sizeBuffer - numberRead);
                    }
                    string str = encode.GetString(buffer);
                    Console.OutputEncoding = Encoding.UTF8;
                    Console.WriteLine(str);
                } while (!end);
            }
        }
        /// <summary>
        /// read data from savePath and write to path 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="sizeBuffer"></param>
        /// <param name="savePath"></param>
        public static void ReadAndSaveStream(string path, int sizeBuffer, string savePath)
        {
            using (var stream_write = File.OpenWrite(path))
            using (var stream_read = File.OpenRead(savePath))
            {

                byte[] buffer = new byte[sizeBuffer];
                bool end = false;
                do
                {
                    int numberRead = stream_read.Read(buffer, 0, sizeBuffer);
                    if (numberRead == 0)
                    {
                        end = true;
                    }
                    else
                    {
                        stream_write.Write(buffer, 0, numberRead);
                    }

                } while (!end);
            }
        }

    }
}
