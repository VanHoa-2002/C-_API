
namespace ParralelTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParallelFor();
            Console.WriteLine("Press any key ...");
            Console.ReadKey();
        }
        public static void PinInfo(string info) =>
            Console.WriteLine($"{info,10} Task:{Task.CurrentId,3}    " + $"thread: {Thread.CurrentThread.ManagedThreadId}");
        public static async void RunTask(int i)
        {
            PinInfo($"start {i,3}");
            await Task.Delay(1);
            PinInfo($"Finish {i,3}");
        }
        public static void ParallelFor()
        {
            ParallelLoopResult result = Parallel.For(1, 20, RunTask);
            Console.WriteLine($"All task start and finish :{result.IsCompleted}");
        }

    }

}

