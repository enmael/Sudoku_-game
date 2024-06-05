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

        }
    }
}
