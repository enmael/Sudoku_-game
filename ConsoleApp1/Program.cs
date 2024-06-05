using System;
using System.Diagnostics.Contracts;
using System.Drawing;
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
    

   public class DefineBasic
    {
        protected int[,] iineArray1 = new int[3, 3];
        protected int[,] iineArray2 = new int[3, 3];
    }

    public class Define1 : DefineBasic
    {
        private Cut1 cut1;

        public int lineArray1(int x, int y)
        {
            int note = iineArray1[x,y];
            return note;
        }

        public int lineArray2(int x, int y)
        {
            int note = iineArray2[x, y];
            return note;
        }
        public Define1()
        {
            cut1 = new Cut1();
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 0)
                    {
                        iineArray1[i, j] = cut1.Arr3(j);
                    }
                    else if (i == 1)
                    {
                        iineArray1[i, j] = cut1.Arr1(j);
                    }
                    else if (i == 2)
                    {
                        iineArray1[i, j] = cut1.Arr2(j);
                    }

                }
            }

           
            for (int i = 0; i < iineArray2.GetLength(0); i++)
            {
                for (int j = 0; j < iineArray2.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        iineArray2[i, j] = cut1.Arr2(j);
                    }
                    else if (i == 1)
                    {
                        iineArray2[i, j] = cut1.Arr3(j);
                    }
                    else if (i == 2)
                    {
                        iineArray2[i, j] = cut1.Arr1(j);
                    }

                }
            }
        }
    }

    public class Define2 : DefineBasic
    {
        private Cut2 cut2;

        public int lineArray1(int x, int y)
        {
            return iineArray1[x, y];
            
        }

        public int lineArray2(int x, int y)
        {
            return iineArray2[x, y];
        }
        public Define2()
        {
            cut2 = new Cut2();
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 0)
                    {
                        iineArray1[i, j] = cut2.Arr3(j);
                    }
                    else if (i == 1)
                    {
                        iineArray1[i, j] = cut2.Arr1(j);
                    }
                    else if (i == 2)
                    {
                        iineArray1[i, j] = cut2.Arr2(j);
                    }

                }
            }

            for (int i = 0; i < iineArray2.GetLength(0); i++)
            {
                for (int j = 0; j < iineArray2.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        iineArray2[i, j] = cut2.Arr2(j);
                    }
                    else if (i == 1)
                    {
                        iineArray2[i, j] = cut2.Arr3(j);
                    }
                    else if (i == 2)
                    {
                        iineArray2[i, j] = cut2.Arr1(j);
                    }

                }
            }
        }
    }

    public class Define3 : DefineBasic
    {
        private Cut3 cut3;

        public int lineArray1(int x, int y)
        {
            int note = iineArray1[x, y];
            return note;
        }

        public int lineArray2(int x, int y)
        {
            int note = iineArray2[x, y];
            return note;
        }
        public Define3()
        {
            cut3 = new Cut3();
          
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 0)
                    {
                        iineArray1[i, j] = cut3.Arr3(j);
                    }
                    else if (i == 1)
                    {
                        iineArray1[i, j] = cut3.Arr1(j);
                    }
                    else if (i == 2)
                    {
                        iineArray1[i, j] = cut3.Arr2(j);
                    }

                }
            }

            for (int i = 0; i < iineArray2.GetLength(0); i++)
            {
                for (int j = 0; j < iineArray2.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        iineArray2[i, j] = cut3.Arr2(j);
                    }
                    else if (i == 1)
                    {
                        iineArray2[i, j] = cut3.Arr3(j);
                    }
                    else if (i == 2)
                    {
                        iineArray2[i, j] = cut3.Arr1(j);
                    }

                }
            }
        }
    }
    #endregion
    
    #region 배열 합쳐서 3x9 스도쿠 만들기
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
            return sudoku1[x,y];
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

    class Plus2
    {
        private int rows1 = 3;
        private int cols1 = 3;
        private int rows2 = 3;
        private int cols2 = 3;
        private int rows3 = 3;
        private int cols3 = 3;

        int[,] sudoku2 = new int[3, 9];
        private RowShuffle rowShuffle;
        private Define2 define2;

        public int Sudoku(int x, int y)
        {
            return sudoku2[x, y];
        }

        public Plus2()
        {
            rowShuffle = new RowShuffle();
            define2 = new Define2();

            // rowArray1 복사
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    sudoku2[i, j] = rowShuffle.RowArray1(i, j);
                }
            }

            // lineArray1 복사
            for (int i = 0; i < rows2; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    sudoku2[i, j + cols1] = define2.lineArray1(i, j);
                }
            }

            // array4 복사
            for (int i = 0; i < rows2; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    sudoku2[i, j + cols1 + cols2] = define2.lineArray2(i, j); ;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(sudoku2[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
    class Plus3
        {
            private int rows1 = 3;
            private int cols1 = 3;
            private int rows2 = 3;
            private int cols2 = 3;
            private int rows3 = 3;
            private int cols3 = 3;
            int[,] sudoku3 = new int[3, 9];
            private RowShuffle rowShuffle;
            private Define3 define3;

            public int Sudoku(int x, int y)
            {
                return sudoku3[x, y];
            }

        public Plus3()
            {
                rowShuffle = new RowShuffle();
                define3 = new Define3();

                // rowArray1 복사
                for (int i = 0; i < rows1; i++)
                {
                    for (int j = 0; j < cols1; j++)
                    {
                        sudoku3[i, j] = rowShuffle.RowArray3(i, j);
                    }
                }

                // lineArray1 복사
                for (int i = 0; i < rows2; i++)
                {
                    for (int j = 0; j < cols2; j++)
                    {
                        sudoku3[i, j + cols1] = define3.lineArray1(i, j);
                    }
                }

                // array4 복사
                for (int i = 0; i < rows2; i++)
                {
                    for (int j = 0; j < cols2; j++)
                    {
                        sudoku3[i, j + cols1 + cols2] = define3.lineArray2(i, j); ;
                    }
                }
            }
        }

    #endregion

    #region 3x9 스도쿠 합쳐서 9x9 만들기
    
    class NewSudoku
    {
        private int rows1 = 3;
        private int cols1 = 9;
        private int rows2 = 3;
        private int cols2 = 9;
        private int rows3 = 3;
        private int cols3 = 9;
        private int[,] newSudoku = new int[9, 9];

        private Plus1 plus1;
        private Plus2 plus2;
        private Plus3 plus3;

        public NewSudoku()
        {
            plus1 = new Plus1();
            plus2 = new Plus2();
            plus3 = new Plus3();

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    newSudoku[i, j] = plus1.Sudoku(i, j);
                }
            }

            for (int i = 0; i < rows2; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    newSudoku[i + rows1, j] = plus2.Sudoku(i, j);
                }
            }

            for (int i = 0; i < rows3; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    newSudoku[i + rows1 + rows2, j] = plus3.Sudoku(i, j);
                }
            }

            Console.WriteLine(" ");
            for (int i = 0; i < newSudoku.GetLength(0); i++)
            {
                for (int j = 0; j < newSudoku.GetLength(1); j++)
                {
                    Console.Write(newSudoku[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            //Screen screen = new Screen();
            Separation separation = new Separation();   
            //NewSudoku newSudoku = new NewSudoku(); 
            //Define1 cut1 = new Define1();
        }
    }
}