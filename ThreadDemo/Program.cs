namespace ThreadDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++) {
                var temp = i;
            Thread t = new Thread(() =>
            {
                DemoThread(temp);
            });
            t.IsBackground = true; // chương trình tắt thì thread dc giải phóng liền
            t.Start();
            }
        }
         static  void DemoThread(int threadIndex)
        {
            for (int i = 0; i <5; i++)
            {
                Console.WriteLine("Thread" + threadIndex + "----" + i);
            }
        }
    }
}
