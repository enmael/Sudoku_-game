namespace ConsoleApp1
{
    #region 화면 꾸미기용 
    class Screen //스크린의 크기를 제한한다.
    {
        public Screen()
        {
            Console.Clear();
            Console.SetWindowSize(50, 25);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(10, 10);
        }
    }


    
    #endregion
    internal class Program
 {
    static void Main(string[] args)
    {
      Screen screen = new Screen();


    }
 }
}

