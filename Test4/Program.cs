namespace Test4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] array2D = new int[10, 10]
     {
                       {1,1,1,1,1,1,1,1,1,1},
                       {1,0,0,0,0,0,0,0,0,1},
                       {1,0,0,0,0,0,0,0,0,1},
                       {1,0,0,1,1,1,1,0,0,1},
                       {1,0,0,0,0,0,0,0,1,1},
                       {1,0,0,0,0,0,0,0,0,1},
                       {1,1,0,1,1,1,0,1,0,1},
                       {1,1,0,1,1,0,0,1,0,1},
                       {1,0,0,0,0,0,0,0,0,1},
                       {1,1,1,1,1,1,1,1,2,1}

     };


            //Console.SetCursorPosition(2, 1);
            //Console.WriteLine("★");
            Console.CursorVisible = false;
            int number1 = 2;
            int number2 = 1;
            ConsoleKeyInfo key;
            while (true)
            {
                #region 맵 생성
                for (int i = 0; i < array2D.GetLength(1); i++)
                {
                    for (int j = 0; j < array2D.GetLength(0); j++)
                    {

                        if (array2D[i, j] == 0)
                        {
                            Console.Write("□");
                        }
                        else if (array2D[i, j] == 1)
                        {
                            Console.Write("■");
                        }
                        else if (array2D[i, j] == 2)
                        {
                            Console.Write("★");
                        }

                    }

                    Console.WriteLine();
                }
                #endregion

                #region 키보드로 이동
                //x,y
                Console.SetCursorPosition(number1, number2);
                Console.WriteLine("▲");
                key = Console.ReadKey();

                switch (key.Key)
                {

                    case ConsoleKey.UpArrow:

                        if (array2D[number2 - 1, number1] != 1)
                        {
                            number2--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (number2 <= 10)
                        {
                            if (array2D[number2 + 1, number1 - 2] != 1)
                            {
                                number2++;
                            }
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (number1 <= 10)
                        {
                            //if (array2D[number2, number1+1] != 1)
                            //{
                            number1 = number1 + 2;
                            //}

                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (number1 >= 0)
                        {
                            //if (array2D[number2, number1 -1] != 1)
                            //{
                            number1 = number1 - 2;
                            //}
                        }
                        break;
                }


                #endregion

                #region 화면 초기화
                Thread.Sleep(100);
                Console.Clear();
                #endregion
            }
        }
    }
}
