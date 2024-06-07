using System;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    #region  화면 
    class Screen
    {
        private readonly int width;
        private readonly int height;
        public Screen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            width = 20;
            height = 20;
            Console.SetWindowSize(width, height);
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

        public int rows()
        {
            int note = array2.GetLength(0);
            return note;
        }

        public int cols()
        {
            int note = array2.GetLength(1);
            return note;
        }

    }


    #endregion


    internal class Program
    {
        static void UpdateTimer(object state)
        {
            Console.Clear(); // 콘솔 창을 지웁니다.
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss")); // 현재 시간을 표시합니다.
        }
        static void Main(string[] args)
        {

            #region 랜덤으로 중복 없는 스도쿠판 만들기

            #region 화면
            Screen screen = new Screen();   
            #endregion

            #region 피셔 에이츠 알고리즘
            Basic basic = new Basic();
            #endregion

            #region 열분리 해보기
            int[,] row1 = new int[3, 1];
            int[,] row2 = new int[3, 1];
            int[,] row3 = new int[3, 1];

            //row1 분리 
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


            #endregion

            #region 3x3 만들기 

            #region 1번째
            //array2 이미 위에서 만듬

            #region 1차원 배열로 분리 
            int[] note = new int[9];
            int noteCoute = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    note[noteCoute] = basic.Array2(i, j);
                    noteCoute++;
                }
            }
            #region 1차배열 3개씩 자르기
            int[] arr1 = new int[3];
            int[] arr2 = new int[3];
            int[] arr3 = new int[3];

            for (int i = 0; i < 9; i++)
            {
                if (i < 3)
                {
                    arr1[i] = note[i];
                }
                else if (i < 6)
                {
                    arr2[i - 3] = note[i];
                }
                else if (i <= 8)
                {
                    arr3[i - 6] = note[i];
                }
            }

            #endregion
            #endregion

            #region 분리한 1차원 배열을 가지고 썩기
            int[,] lineArray1 = new int[3, 3];
            int[,] lineArray2 = new int[3, 3];


            #region lineArray1
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 0)
                    {
                        lineArray1[i, j] = arr3[j];
                    }
                    else if (i == 1)
                    {
                        lineArray1[i, j] = arr1[j];
                    }
                    else if (i == 2)
                    {
                        lineArray1[i, j] = arr2[j];
                    }

                }
            }

            #endregion

            #region lineArray2
            for (int i = 0; i < lineArray2.GetLength(0); i++)
            {
                for (int j = 0; j < lineArray2.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        lineArray2[i, j] = arr2[j];
                    }
                    else if (i == 1)
                    {
                        lineArray2[i, j] = arr3[j];
                    }
                    else if (i == 2)
                    {
                        lineArray2[i, j] = arr1[j];
                    }

                }
            }

            #endregion

            #region 합치기
            int rows1 = basic.rows();
            int cols1 = basic.cols();
            int rows2 = lineArray1.GetLength(0);
            int cols2 = lineArray1.GetLength(1);
            int rows3 = lineArray2.GetLength(0);
            int cols3 = lineArray2.GetLength(1);

            int[,] sudoku1 = new int[rows1, cols1 + cols2 + cols3];

            #region 복사하기
            // rowArray1 복사
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    sudoku1[i, j] = basic.Array2(i, j);
                }
            }

            // lineArray1 복사
            for (int i = 0; i < rows2; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    sudoku1[i, j + cols1] = lineArray1[i, j];
                }
            }

            // array4 복사
            for (int i = 0; i < rows2; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    sudoku1[i, j + cols1 + cols2] = lineArray2[i, j];
                }
            }

            //for (int i = 0; i < sudoku1.GetLength(0); i++)
            //{
            //    for (int j = 0; j < sudoku1.GetLength(1); j++)
            //    {
            //        Console.Write(sudoku1[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            #endregion
            #endregion

            #endregion

            #endregion

            #region 2번째
            #region rowArray1
            int[,] rowArray1 = new int[3, 3];
            for (int i = 0; i < rowArray1.GetLength(0); i++)
            {
                for (int j = 0; j < rowArray1.GetLength(1); j++)
                {
                    //row3 삽입 
                    if (j == 0)
                    {
                        rowArray1[i, j] = row3[i, 0];
                    }
                    //row1 삽입 
                    if (j == 1)
                    {
                        rowArray1[i, j] = row1[i, 0];
                    }
                    //row2 삽입 
                    if (j == 2)
                    {
                        rowArray1[i, j] = row2[i, 0];
                    }


                }
            }
            #endregion

            #region 1차원 배열로 분리 

            noteCoute = 0;
            for (int i = 0; i < rowArray1.GetLength(0); i++)
            {
                for (int j = 0; j < rowArray1.GetLength(1); j++)
                {
                    note[noteCoute] = rowArray1[i, j];
                    noteCoute++;
                }
            }
            #region 1차배열 3개씩 자르기


            for (int i = 0; i < note.Length; i++)
            {
                if (i < 3)
                {
                    arr1[i] = note[i];
                }
                else if (i < 6)
                {
                    arr2[i - 3] = note[i];
                }
                else if (i <= 8)
                {
                    arr3[i - 6] = note[i];
                }
            }

            #endregion
            #endregion

            #region 분리한 1차원 배열을 가지고 썩기

            #region lineArray1
            for (int i = 0; i < lineArray1.GetLength(0); i++)
            {
                for (int j = 0; j < lineArray1.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        lineArray1[i, j] = arr3[j];
                    }
                    else if (i == 1)
                    {
                        lineArray1[i, j] = arr1[j];
                    }
                    else if (i == 2)
                    {
                        lineArray1[i, j] = arr2[j];
                    }

                }
            }

            #endregion

            #region lineArray2
            for (int i = 0; i < lineArray2.GetLength(0); i++)
            {
                for (int j = 0; j < lineArray2.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        lineArray2[i, j] = arr2[j];
                    }
                    else if (i == 1)
                    {
                        lineArray2[i, j] = arr3[j];
                    }
                    else if (i == 2)
                    {
                        lineArray2[i, j] = arr1[j];
                    }

                }
            }

            #endregion



            #endregion

            #region 합치기
            rows1 = rowArray1.GetLength(0);
            rows1 = rowArray1.GetLength(1);
            rows1 = lineArray1.GetLength(0);
            rows1 = lineArray1.GetLength(1);
            rows1 = lineArray2.GetLength(0);
            rows1 = lineArray2.GetLength(1);

            int[,] sudoku2 = new int[rows1, cols1 + cols2 + cols3];

            #region 복사하기
            // rowArray1 복사
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    sudoku2[i, j] = rowArray1[i, j];
                }
            }

            // lineArray1 복사
            for (int i = 0; i < rows2; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    sudoku2[i, j + cols1] = lineArray1[i, j];
                }
            }

            // array4 복사
            for (int i = 0; i < rows2; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    sudoku2[i, j + cols1 + cols2] = lineArray2[i, j];
                }
            }

            //for (int i = 0; i < sudoku2.GetLength(0); i++)
            //{
            //    for (int j = 0; j < sudoku2.GetLength(1); j++)
            //    {
            //        Console.Write(sudoku2[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            #endregion
            #endregion
            #endregion

            #region 3번째

            #region rowArray2
            int[,] rowArray2 = new int[3, 3];
            for (int i = 0; i < rowArray2.GetLength(0); i++)
            {
                for (int j = 0; j < rowArray2.GetLength(1); j++)
                {
                    //row2 삽입 
                    if (j == 0)
                    {
                        rowArray2[i, j] = row2[i, 0];
                    }
                    //row3 삽입 
                    if (j == 1)
                    {
                        rowArray2[i, j] = row3[i, 0];
                    }
                    //row1 삽입 
                    if (j == 2)
                    {
                        rowArray2[i, j] = row1[i, 0];
                    }


                }
            }
            #endregion

            #region 1차원 배열로 분리 
            noteCoute = 0;
            for (int i = 0; i < rowArray2.GetLength(0); i++)
            {
                for (int j = 0; j < rowArray2.GetLength(1); j++)
                {
                    note[noteCoute] = rowArray2[i, j];
                    noteCoute++;
                }
            }
            #region 1차배열 3개씩 자르기


            for (int i = 0; i < note.Length; i++)
            {
                if (i < 3)
                {
                    arr1[i] = note[i];
                }
                else if (i < 6)
                {
                    arr2[i - 3] = note[i];
                }
                else if (i <= 8)
                {
                    arr3[i - 6] = note[i];
                }
            }

            #endregion
            #endregion

            #region 분리한 1차원 배열을 가지고 썩기



            #region lineArray1
            for (int i = 0; i < lineArray1.GetLength(0); i++)
            {
                for (int j = 0; j < lineArray1.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        lineArray1[i, j] = arr3[j];
                    }
                    else if (i == 1)
                    {
                        lineArray1[i, j] = arr1[j];
                    }
                    else if (i == 2)
                    {
                        lineArray1[i, j] = arr2[j];
                    }

                }
            }

            #endregion

            #region lineArray2
            for (int i = 0; i < lineArray2.GetLength(0); i++)
            {
                for (int j = 0; j < lineArray2.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        lineArray2[i, j] = arr2[j];
                    }
                    else if (i == 1)
                    {
                        lineArray2[i, j] = arr3[j];
                    }
                    else if (i == 2)
                    {
                        lineArray2[i, j] = arr1[j];
                    }

                }
            }

            #endregion



            #endregion

            #region 합치기
            rows1 = rowArray2.GetLength(0);
            cols1 = rowArray2.GetLength(1);
            rows2 = lineArray1.GetLength(0);
            cols2 = lineArray1.GetLength(1);
            rows3 = lineArray2.GetLength(0);
            cols3 = lineArray2.GetLength(1);

            int[,] sudoku3 = new int[rows1, cols1 + cols2 + cols3];

            #region 복사하기
            // rowArray1 복사
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    sudoku3[i, j] = rowArray2[i, j];
                }
            }

            // lineArray1 복사
            for (int i = 0; i < rows2; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    sudoku3[i, j + cols1] = lineArray1[i, j];
                }
            }

            // array4 복사
            for (int i = 0; i < rows2; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    sudoku3[i, j + cols1 + cols2] = lineArray2[i, j];
                }
            }

            //for (int i = 0; i < sudoku3.GetLength(0); i++)
            //{
            //    for (int j = 0; j < sudoku3.GetLength(1); j++)
            //    {
            //        Console.Write(sudoku3[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            #endregion
            #endregion
            #endregion

            #region 출력용
            //for (int i = 0; i < sudoku1.GetLength(0); i++)
            //{
            //    for (int j = 0; j < sudoku1.GetLength(1); j++)
            //    {
            //        Console.Write(sudoku1[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            //for (int i = 0; i < sudoku2.GetLength(0); i++)
            //{
            //    for (int j = 0; j < sudoku2.GetLength(1); j++)
            //    {
            //        Console.Write(sudoku2[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            //for (int i = 0; i < sudoku3.GetLength(0); i++)
            //{
            //    for (int j = 0; j < sudoku3.GetLength(1); j++)
            //    {
            //        Console.Write(sudoku3[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}
            #endregion
            #endregion

            #region Sudoku판 합치기

            rows1 = sudoku1.GetLength(0);
            cols1 = sudoku1.GetLength(1);
            rows2 = sudoku2.GetLength(0);
            cols2 = sudoku2.GetLength(1);
            rows3 = sudoku3.GetLength(0);
            cols3 = sudoku3.GetLength(1);

            int[,] newSudoku = new int[rows1 + rows2 + rows3, cols1];

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    newSudoku[i, j] = sudoku1[i, j];
                }
            }

            for (int i = 0; i < rows2; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    newSudoku[i + rows1, j] = sudoku2[i, j];
                }
            }

            for (int i = 0; i < rows3; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    newSudoku[i + rows1 + rows2, j] = sudoku3[i, j];
                }
            }

            //Console.WriteLine(" ");
            //for (int i = 0; i < newSudoku.GetLength(0); i++)
            //{
            //    for (int j = 0; j < newSudoku.GetLength(1); j++)
            //    {
            //        Console.Write(newSudoku[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}
            #endregion


            #endregion

            #region 복사해서 빈공간 만들기
            //복사
            int[,] copySudoku = new int[9, 9];
            for (int i = 0; i < copySudoku.GetLength(0); i++)
            {
                for (int j = 0; j < copySudoku.GetLength(1); j++)
                    copySudoku[i, j] = newSudoku[i, j];
            }

            //랜덤 좌표를 빈공간으로 만들기
            int number1 = 0;
            int number2 = 0;
            Random random = new Random();
            for (int i = 0; i < 15; i++)
            {
                number1 = random.Next(0, 9);
                number2 = random.Next(0, 9);
                copySudoku[number1, number2] = 0;
            }
            #endregion

            #region 빈공간의 갯수 저장
            int Zero = 0;
            for (int i = 0; i < copySudoku.GetLength(0); i++)
            {
                for (int j = 0; j < copySudoku.GetLength(1); j++)
                {
                    if (copySudoku[i, j] == 0)
                    {
                        Zero++;
                    }
                }
            }
            int Zero2 = 0;
            Zero2 = Zero;
            #endregion

            #region 가동부

            #region 입력키 확인용

            string[] num = new string[9] { "ⓠ", "ⓦ", "ⓔ", "ⓐ", "ⓢ", "ⓓ", "ⓩ", "ⓧ", "ⓒ" };//표시용
            int[] num2 = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9, }; //표시용
            int[] num3 = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9, }; //초기화 용
            #endregion 


            Console.CursorVisible = false; //콘솔창 커서 제거 
            //시작위치
            int x = 16;
            int y = 16;
            ConsoleKeyInfo key; //키보드 사용
            int start = 0; // 화면 대기용으로 만든거
            int memo = 0; //임시적으로 숫자를 저장
            //
            while (true)
            {
                if (start < 20)
                {
                    #region 시작화면
                    Console.SetCursorPosition(5, 3);
                    Console.WriteLine("SUDOKU");
                    Console.WriteLine(" ");
                    Console.SetCursorPosition(5, 5);
                    Console.WriteLine("Game");
                    Console.SetCursorPosition(5, 6);
                    Console.WriteLine("Starting");
                    
                    start++;
                    #endregion
                }
                else
                {
                    if (Zero != 0)
                    {
                        #region 정보 표시
                        for (int i = 0; i < num.Length; i++)
                        {
                            Console.Write(num[i]);
                        }
                        Console.WriteLine(" ");
                        
                        for(int i = 0; i < num2.Length; i++)
                        {
                            if (num2[i] == 1)
                            {
                                Console.Write("①");
                            }
                            else if (num2[i] == 2)
                            {
                                Console.Write("②");
                            }
                            else if (num2[i] == 2)
                            {
                                Console.Write("②");
                            }
                            else if (num2[i] == 3)
                            {
                                Console.Write("③");
                            }
                            else if (num2[i] == 4)
                            {
                                Console.Write("④");
                            }
                            else if (num2[i] == 5)
                            {
                                Console.Write("⑤");
                            }
                            else if (num2[i] == 6)
                            {
                                Console.Write("⑥");
                            }
                            else if (num2[i] == 7)
                            {
                                Console.Write("⑦");
                            }
                            else if (num2[i] == 8)
                            {
                                Console.Write("⑧");
                            }
                            else if (num2[i] == 9)
                            {
                                Console.Write("⑨");
                            }
                            else if (num2[i] == 0)
                            {
                                Console.Write("●");
                            }
                        }
                        Console.WriteLine(" ");

                        Console.WriteLine("입력 : Enter");
                        Console.WriteLine("초기화 : Spacebar");
                        Console.WriteLine("빈공간 : " + Zero);
                        Console.WriteLine("memo:" + memo);
                        Console.WriteLine(" ");
                        #endregion

                        #region 스도쿠 판
                        for (int i = 0; i < copySudoku.GetLength(1); i++)
                        {
                            for (int j = 0; j < copySudoku.GetLength(0); j++)
                            {
                                if (copySudoku[i, j] == 0)
                                {
                                    Console.Write("□");
                                }
                                else if (copySudoku[i, j] == 1)
                                {
                                    Console.Write("①");
                                }
                                else if (copySudoku[i, j] == 2)
                                {
                                    Console.Write("②");
                                }
                                else if (copySudoku[i, j] == 2)
                                {
                                    Console.Write("②");
                                }
                                else if (copySudoku[i, j] == 3)
                                {
                                    Console.Write("③");
                                }
                                else if (copySudoku[i, j] == 4)
                                {
                                    Console.Write("④");
                                }
                                else if (copySudoku[i, j] == 5)
                                {
                                    Console.Write("⑤");
                                }
                                else if (copySudoku[i, j] == 6)
                                {
                                    Console.Write("⑥");
                                }
                                else if (copySudoku[i, j] == 7)
                                {
                                    Console.Write("⑦");
                                }
                                else if (copySudoku[i, j] == 8)
                                {
                                    Console.Write("⑧");
                                }
                                else if (copySudoku[i, j] == 9)
                                {
                                    Console.Write("⑨");
                                }
                                else
                                {
                                    Console.Write(copySudoku[i, j] + " ");
                                }

                            }

                            Console.WriteLine();
                        }
                        #endregion

                        #region 키보드 이벤트
                        //Q : 1, W : 2, E : 3
                        //A : 4, S : 5, D : 6
                        //Z : 7, X : 8, C : 9
                        //enter : 입력
                        //Spacebar : 지우기 
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine("▲");
                        key = Console.ReadKey();
                        switch (key.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (y > 7)
                                {
                                    y--;
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (y <= 14)
                                {
                                    y++;
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (x > 0)
                                {
                                    x = x - 2;
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (x <= 15)
                                {
                                    x = x + 2;
                                }
                                break;
                            case ConsoleKey.Q:
                                if (copySudoku[y - 7, x / 2] == 0)
                                {
                                    memo = 1;
                                    num2[0] = 0;
                                }
                                break;
                            case ConsoleKey.W:
                                if (copySudoku[y - 7, x / 2] == 0)
                                {
                                    memo = 2;
                                    num2[1] = 0;
                                }
                                break;
                            case ConsoleKey.E:
                                if (copySudoku[y - 7, x / 2] == 0)
                                {
                                    memo = 3;
                                    num2[2] = 0;
                                }
                                break;
                            case ConsoleKey.A:
                                if (copySudoku[y - 7, x / 2] == 0)
                                {
                                    memo = 4;
                                    num2[3] = 0;
                                }
                                break;
                            case ConsoleKey.S:
                                if (copySudoku[y - 7, x / 2] == 0)
                                {
                                    memo = 5;
                                    num2[4] = 0;
                                }
                                break;
                            case ConsoleKey.D:
                                if (copySudoku[y - 7, x / 2] == 0)
                                {
                                    memo = 6;
                                    num2[5] = 0;
                                }
                                break;
                            case ConsoleKey.Z:
                                if (copySudoku[y - 7, x / 2] == 0)
                                {
                                    memo = 7;
                                    num2[6] = 0;
                                }
                                break;
                            case ConsoleKey.X:
                                if (copySudoku[y - 7, x / 2] == 0)
                                {
                                    memo = 8;
                                    num2[7] = 0;
                                }
                                break;
                            case ConsoleKey.C:
                                if (copySudoku[y - 7, x / 2] == 0)
                                {
                                    memo = 9;
                                    num2[8] = 0;
                                }
                                break;
                            case ConsoleKey.Enter:
                                if (memo != 0)
                                {
                                    if (copySudoku[y - 7, x / 2] == 0)
                                    {
                                        copySudoku[y - 7, x / 2] = memo;
                                        Zero--;
                                        memo = 0;
                                        //숫자 초기화
                                        for(int i  =0; i < num2.Length; i++)
                                        {
                                            num2[i] = num3[i];
                                        }
                                    }
                                    
                                }
                                break;
                            case ConsoleKey.Spacebar:
                                //입력 오타 초기화
                                memo = 0;
                                for (int i = 0; i < num2.Length; i++)
                                {
                                    num2[i] = num3[i];
                                }
                                break;
                        }
                        #endregion
                    }
                    else if (Zero == 0) 
                    {
                        #region 게임종료후 점수 판정
                        int sudokuAnswer = Zero2;
                        for (int i = 0; i < copySudoku.GetLength(0); i++)
                        {
                            for (int j = 0; j < copySudoku.GetLength(1); j++)
                            {
                                if (newSudoku[i, j] != copySudoku[i, j])
                                {
                                    sudokuAnswer--;
                                }
                            }
                        }
                        Console.SetCursorPosition(5, 3);
                        if (sudokuAnswer == 0)
                        {
                            Console.WriteLine("Game Over");

                        }
                        else if (sudokuAnswer == Zero2)
                        {
                            Console.WriteLine("All Clear!!!");

                        }
                        else if (sudokuAnswer > 0)
                        {
                            Console.WriteLine(sudokuAnswer + "개");
                            Console.WriteLine(" 맞추셨습니다.");

                        }
                        #endregion
                    }
                }
                #region 화면 초기화
                Thread.Sleep(100);
                Console.Clear();

                #endregion
            }
            #endregion
        }
    }
}