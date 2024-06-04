using System;

namespace Test2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 정리

            #region 데코
            

            #endregion

            #region 피셔 에이츠 알고리즘
            Random random = new Random();
            int[] array = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[,] array2 = new int[3, 3];



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
                    row1[i, j] = array2[i, j];
                }
            }

            //row2 분리 
            for (int i = 0; i < row1.GetLength(0); i++)
            {
                for (int j = 0; j < row2.GetLength(1); j++)
                {
                    row2[i, j] = array2[i, j + 1];
                }
            }

            //row3 분리 
            for (int i = 0; i < row1.GetLength(0); i++)
            {
                for (int j = 0; j < row2.GetLength(1); j++)
                {
                    row3[i, j] = array2[i, j + 2];
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
                    note[noteCoute] = array2[i, j];
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
            int rows1 = array2.GetLength(0);
            int cols1 = array2.GetLength(1);
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
                    sudoku1[i, j] = array2[i, j];
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

            int[,] newSudoku = new int[rows1 + rows2+rows3, cols1];

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
                    newSudoku[i + rows1+rows2, j] = sudoku3[i, j];
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
            #endregion


            #endregion
        }
    }
}
