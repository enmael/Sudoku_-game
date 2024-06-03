namespace ConsoleApp1
{
    #region
    //public class Sudoku
    //{
    //    protected int[] array = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    //    protected int[,] array2 = new int[3, 3];
    //}

    //public class BasicSudoku : Sudoku
    //{
    //    public void Shuffle()
    //    {
    //        Random random = new Random();

        //        for (int i = array.Length - 1; i > 0; i--)
        //        {
        //            int j = random.Next(0, i + 1);

        //            int temp = array[i];
        //            array[i] = array[j];
        //            array[j] = temp;
        //        }

        //        int a = 0;
        //        for (int i = 0; i < array2.GetLength(0); i++)
        //        {
        //            for (int j = 0; j < array2.GetLength(1); j++)
        //            {
        //                array2[i, j] = array[a];
        //                a++;
        //            }
        //        }
        //    }
        //    public void Print()
        //    {
        //        for (int i = 0; i < array2.GetLength(0); i++)
        //        {
        //            for (int j = 0; j < array2.GetLength(1); j++)
        //            {
        //                Console.Write(array2[i, j]);
        //            }
        //            Console.WriteLine();
        //        }
        //    }
        //}
        #endregion

       
   
  internal class Program
  {
    static void Main(string[] args)
     {
            int[,] array = {
            { 1, 2, 3},
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

            int columns = array.GetLength(1); // 배열의 열 수
            int[,] separatedColumns = new int[columns, array.GetLength(0)]; // 분리된 열을 저장할 배열

            // 열을 분리하여 저장
            for (int col = 0; col < columns; col++)
            {
                for (int row = 0; row < array.GetLength(0); row++)
                {
                    separatedColumns[col, row] = array[row, col];
                }
            }

            // 분리된 열 출력
            for (int col = 0; col < columns; col++)
            {
                Console.WriteLine($"Column {col + 1}:");
                for (int row = 0; row < array.GetLength(0); row++)
                {
                    Console.WriteLine(separatedColumns[col, row]);
                }
                Console.WriteLine();
            }
        }
    }
}

