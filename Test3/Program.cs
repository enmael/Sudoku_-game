namespace Test3
{
    internal class Program
    {

        #region  피셔 에이츠 셔플 알고리즘
        class Basic
        {
            private int[] array = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            private int[,] array2 = new int[3, 3];

            public Basic()
            {
                Random random = new Random();

                for (int i = array.Length - 1; i > 0; i--)
                {
                    int j = random.Next(0, i + 1);

                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }


                int a = 0;
                for (int i = 0; i < array2.GetLength(0); i++)
                {
                    for (int j = 0; j < array2.GetLength(1); j++)
                    {
                        array2[i, j] = array[a];
                        a++;
                    }
                }

            }

            public int Array2(int x, int y)
            {
                int note = array2[x, y];
                return note;


            }

        }


        #endregion

        class Plus1
        {
            private int rows1 = 3;
            private int cols1 = 3;
            private int rows2 = 3;
            private int cols2 = 3;
            private int rows3 = 3;
            private int cols3 = 3;
            int[,] sudoku1 = new int[3, 9];
            private RowShuffle rowShuffle;
            private Define1 define1;

            public int Sudoku(int x, int y)
            {
                return sudoku1[x, y];
            }
            public Plus1()
            {
                rowShuffle = new RowShuffle();
                define1 = new Define1();

                // rowArray1 복사
                for (int i = 0; i < rows1; i++)
                {
                    for (int j = 0; j < cols1; j++)
                    {
                        sudoku1[i, j] = rowShuffle.RowArray1(i, j);
                    }
                }

                // lineArray1 복사
                for (int i = 0; i < rows2; i++)
                {
                    for (int j = 0; j < cols2; j++)
                    {
                        sudoku1[i, j + cols1] = define1.lineArray1(i, j);
                    }
                }

                // array4 복사
                for (int i = 0; i < rows2; i++)
                {
                    for (int j = 0; j < cols2; j++)
                    {
                        sudoku1[i, j + cols1 + cols2] = define1.lineArray2(i, j); ;
                    }
                }
            }


        }

        #region 분리 
        class Separation
        {
            private int[,] row1 = new int[3, 1];
            private int[,] row2 = new int[3, 1];
            private int[,] row3 = new int[3, 1];

            private Basic basic;

            public Separation()
            {
                basic = new Basic();

                for (int i = 0; i < row1.GetLength(0); i++)
                {
                    for (int j = 0; j < row2.GetLength(1); j++)
                    {
                        row1[i, j] = basic.Array2(i, j);
                    }
                }

                //row2 분리 
                for (int i = 0; i < row1.GetLength(0); i++)
                {
                    for (int j = 0; j < row2.GetLength(1); j++)
                    {
                        row2[i, j] = basic.Array2(i, j + 1);
                    }
                }

                //row3 분리 
                for (int i = 0; i < row1.GetLength(0); i++)
                {
                    for (int j = 0; j < row2.GetLength(1); j++)
                    {
                        row3[i, j] = basic.Array2(i, j + 2);
                    }
                }

                for (int i = 0; i < row1.GetLength(0); i++)
                {
                    for (int j = 0; j < row2.GetLength(1); j++)
                    {
                        Console.Write(row3[i, j]);
                    }
                }
            }

            public int Row1(int x, int y)
            {
                int note = row1[x, y];
                return note;

            }

            public int Row2(int x, int y)
            {
                int note = row2[x, y];
                return note;

            }

            public int Row3(int x, int y)
            {
                int note = row3[x, y];
                return note;

            }
        }
        #endregion
        static void Main(string[] args)
        {
            Separation basic = new Separation();
        }
    }
}
