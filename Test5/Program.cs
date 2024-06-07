namespace Test5
{
    using System.Threading;

    internal class Program
    {
        static void TimerCallback(object state)
        {
            
            // 현재 시간을 콘솔에 출력
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
             
        }

        static void Main(string[] args)
        {
            
                Timer timer = new Timer(TimerCallback, null, 0, 1000);

                Console.ReadKey(); // 키 입력을 기다림

                timer.Dispose();
            

        }
    }
}
