using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    #region 화면 꾸미기용 클래스 
    class Screen //스크린의 크기를 제한한다.
    {
        public Screen()
        {
            Console.Clear();
            Console.SetWindowSize(30, 20);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(3, 10);
            Console.WriteLine("아무 버튼이나 눌러주세요 ");
        }
    }
    #endregion

    #region 피셔 에이츠 셔플 알고리즘
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

    #region row 셔플

    class RowShuffle
    {
        private int[,] rowArray1 = new int[3, 3];
        private int[,] rowArray2 = new int[3, 3];
        private int[,] rowArray3 = new int[3, 3];

        private Separation separation;
        public RowShuffle()
        {
            separation = new Separation();
            //rowArray1
            for (int i = 0; i < rowArray1.GetLength(0); i++)
            {
                for (int j = 0; j < rowArray1.GetLength(1); j++)
                {
                    //row1 삽입 
                    if (j == 0)
                    {
                        rowArray1[i, j] = separation.Row1(i, 0);
                    }
                    //row2 삽입
                    if (j == 1)
                    {
                        rowArray1[i, j] = separation.Row2(i, 0);
                    }
                    //row3 삽입 
                    if (j == 2)
                    {
                        rowArray1[i, j] = separation.Row3(i, 0);
                    }


                }
            }
            //rowArray2
            for (int i = 0; i < rowArray2.GetLength(0); i++)
            {
                for (int j = 0; j < rowArray2.GetLength(1); j++)
                {
                    //row3 삽입 
                    if (j == 0)
                    {
                        rowArray1[i, j] = separation.Row3(i, 0);
                    }
                    //row1 삽입
                    if (j == 1)
                    {
                        rowArray1[i, j] = separation.Row1(i, 0);
                    }
                    //row2 삽입 
                    if (j == 2)
                    {
                        rowArray1[i, j] = separation.Row2(i, 0);
                    }


                }
            }
            //rowArray3
            for (int i = 0; i < rowArray2.GetLength(0); i++)
            {
                for (int j = 0; j < rowArray2.GetLength(1); j++)
                {
                    //row3 삽입 
                    if (j == 0)
                    {
                        rowArray1[i, j] = separation.Row2(i, 0);
                    }
                    //row1 삽입
                    if (j == 1)
                    {
                        rowArray1[i, j] = separation.Row3(i, 0);
                    }
                    //row2 삽입 
                    if (j == 2)
                    {
                        rowArray1[i, j] = separation.Row1(i, 0);
                    }


                }
            }

        }

        public int RowArray1(int x, int y)
        {
            int note = rowArray1[x, y];
            return note;
        }

        public int RowArray2(int x, int y)
        {
            int note = rowArray2[x, y];
            return note;
        }

        public int RowArray3(int x, int y)
        {
            int note = rowArray3[x, y];
            return note;
        }
    }

    #endregion 

    #region 2차원 배열을 1차원 배열로 전환
     class Transform1
    {
        private int[] note = new int[9];
        private int noteCoute = 0;

        private RowShuffle rowShuffle;
        public int Note(int x)
        {
            return note[x];
        }
        public Transform1() 
        {
            rowShuffle = new RowShuffle();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    note[noteCoute] = rowShuffle.RowArray1(i, j);
                    noteCoute++;
                }
            }
        }
        
    }

    class Transform2
    {
        private int[] note = new int[9];
        private int noteCoute = 0;

        private RowShuffle rowShuffle;

        public int Note(int x)
        {
            return note[x];
        }
        public Transform2()
        {
            rowShuffle = new RowShuffle();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    note[noteCoute] = rowShuffle.RowArray2(i, j);
                    noteCoute++;
                }
            }
        }

    }

    class Transform3
    {
        private int[] note = new int[9];
        private int noteCoute = 0;

        private RowShuffle rowShuffle;

        public int Note(int x)
        {
            return note[x];
        }
        public Transform3()
        {
            rowShuffle = new RowShuffle();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    note[noteCoute] = rowShuffle.RowArray3(i, j);
                    noteCoute++;
                }
            }
        }

    }


    #endregion

    #region 1차원 배열 3개로 분활
    public class CutBasic
    {
        protected int[] arr1 = new int[3];
        protected int[] arr2 = new int[3];
        protected int[] arr3 = new int[3];
    }
    public class Cut1 : CutBasic
    {
       private Transform1 transform1;  
        public int Arr1(int x)
        {
            return arr1[x];
        }

        public int Arr2(int x)
        {
            return arr2[x];
        }

        public int Arr3(int x)
        {
            return arr3[x];
        }
        public Cut1()
        {
            transform1 = new Transform1();

            for (int i = 0; i < 9; i++)
            {
                if (i < 3)
                {
                    arr1[i] = transform1.Note(i);
                }
                else if (i < 6)
                {
                    arr2[i - 3] = transform1.Note(i); ;
                }
                else if (i <= 8)
                {
                    arr3[i - 6] = transform1.Note(i); ;
                }
            }
        }
    }

    public class Cut2 : CutBasic
    {
        private Transform2 transform2;
        public int Arr1(int x)
        {
            return arr1[x];
        }

        public int Arr2(int x)
        {
            return arr2[x];
        }

        public int Arr3(int x)
        {
            return arr3[x];
        }
        public Cut2()
        {
            transform2 = new Transform2();

            for (int i = 0; i < 9; i++)
            {
                if (i < 3)
                {
                    arr1[i] = transform2.Note(i);
                }
                else if (i < 6)
                {
                    arr2[i - 3] = transform2.Note(i); ;
                }
                else if (i <= 8)
                {
                    arr3[i - 6] = transform2.Note(i); ;
                }
            }
        }
    }

    public class Cut3 : CutBasic
    {
        private Transform3 transform3;
        public int Arr1(int x)
        {
            return arr1[x];
        }

        public int Arr2(int x)
        {
            return arr2[x];
        }

        public int Arr3(int x)
        {
            return arr3[x];
        }
        public Cut3()
        {
            transform3 = new Transform3();

            for (int i = 0; i < 9; i++)
            {
                if (i < 3)
                {
                    arr1[i] = transform3.Note(i);
                }
                else if (i < 6)
                {
                    arr2[i - 3] = transform3.Note(i); ;
                }
                else if (i <= 8)
                {
                    arr3[i - 6] = transform3.Note(i); ;
                }
            }
        }
    }
    #endregion

    #region 1차원 배열로 다시 2차원 배열 만들기
    



    #endregion



    internal class Program
 {
    static void Main(string[] args)
    {
     //Screen screen = new Screen();
      //Separation separation = new Separation();   


    }
 }
}

