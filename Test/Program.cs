using System;
using System.Runtime.ExceptionServices;
using System.Runtime.Versioning;

namespace Test
{
    public class Sudoku
    {
        private int[] array = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private int[,] array2 = new int[3, 3];

        public  Sudoku()
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                Random random = new Random();
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

    }
    internal class Program
    {
        static void Main(string[] args)
        {

            #region 피셔 에이츠 셔플 알고리즘 을 이용하여 3X3 스도쿠 만들기
            //Random random = new Random();
            //int[] array = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //int[,] array2 = new int[9, 9];

            //for (int i = array.Length - 1; i > 0; i--)
            //{
            //    int j = random.Next(0, i + 1);

            //    int temp = array[i];
            //    array[i] = array[j];
            //    array[j] = temp;
            //}

            //int a = 0;
            //for (int i = 0; i < array2.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array2.GetLength(1); j++)
            //    {
            //        array2[i, j] = array[a];
            //        a++;
            //    }
            //}

            //for (int i = 0; i < array2.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array2.GetLength(1); j++)
            //    {
            //        Console.Write(array2[i, j]);
            //    }
            //    Console.WriteLine();
            //}
            #endregion

            #region 9x9 스도쿠 완성본으로 한번 돌려보기
            //먼가 중간에 새로운것이 필요함 이방법은 안됨
            //random random = new random();
            ////int[,] array = new int[9, 9] 
            ////{ 
            ////{8,3,9,6,5,7,2,1,4},
            ////{6,7,2,9,4,1,5,8,3},
            ////{1,5,4,8,3,2,9,6,7},
            ////{5,4,1,2,8,3,7,9,6},
            ////{2,8,7,4,9,6,3,5,1},
            ////{9,6,3,7,1,5,4,2,8},
            ////{7,1,8,3,2,9,6,4,5},
            ////{3,2,5,1,6,4,8,7,9},
            ////{4,9,6,5,7,8,1,3,2},
            ////};

            //int[] array = new int[81] { 8, 3, 9, 6, 5, 7, 2, 1, 4, 6, 7, 2, 9, 4, 1, 5, 8, 3, 1, 5, 4, 8, 3, 2, 9, 6, 7, 5, 4, 1, 2, 8, 3, 7, 9, 6, 2, 8, 7, 4, 9, 6, 3, 5, 1, 9, 6, 3, 7, 1, 5, 4, 2, 8, 7, 1, 8, 3, 2, 9, 6, 4, 5, 3, 2, 5, 1, 6, 4, 8, 7, 9, 4, 9, 6, 5, 7, 8, 1, 3, 2 };
            //int[,] array2 = new int[9, 9];

            //for (int i = array.length - 1; i > 0; i--)
            //{
            //    int j = random.next(0, i + 1);

            //    int temp = array[i];
            //    array[i] = array[j];
            //    array[j] = temp;
            //}

            //int a = 0;
            //for (int i = 0; i < array2.getlength(0); i++)
            //{
            //    for (int j = 0; j < array2.getlength(1); j++)
            //    {
            //        array2[i, j] = array[a];
            //        a++;
            //    }
            //}

            //for (int i = 0; i < array2.getlength(0); i++)
            //{
            //    for (int j = 0; j < array2.getlength(1); j++)
            //    {
            //        console.write(array2[i, j]);
            //    }
            //    console.writeline();
            //}
            #endregion

            #region 백 트레이킹 알고리즘 

            //백트래킹 알고리즘 이란
            // 어떤 조건에 부합하지 않으면 그 경로를 포기하고 이전 상태로
            //되돌아가서 새로운 경로를 찾아간다?

            //그럼 1단계 : 피셔 에이츠 셔플 알고리즘 으로 3X3의 스도쿠를 만들고
            //2단계 나머지 9X9의 스도쿠를 백트래킹을 사용하여 매꾼다????

            //깊이 우선 탐색을 알아야지만 백트래킹을 할수있다 이거인가요??

            #region DFS(깊이 우선 탐색)
            //현재 정점에서 시작하여 한 노드의 자식을 모두 탐색한 후
            // 다음 자식으로 넘어가는 방식으로 동작합니다.
            // 알고리즘이 제대로 안되니 미쳐버리겠네 

            #endregion
            #endregion

            #region 3x9 의 스도쿠 만들기
            //Random random = new Random();
            //int[] array = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //int[,] array2 = new int[3, 3];
            //int[,] array3 = new int[3, 3];
            //int[,] array4 = new int[3, 3];
            //int[,] array5 = new int[9, 9];
            //int[] arr1 = new int[3];
            //int[] arr2 = new int[3];
            //int[] arr3 = new int[3];


            //for (int i = array.Length - 1; i > 0; i--)
            //{
            //    int j = random.Next(0, i + 1);

            //    int temp = array[i];
            //    array[i] = array[j];
            //    array[j] = temp;
            //}


            //int a = 0;
            //for (int i = 0; i < array2.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array2.GetLength(1); j++)
            //    {
            //        array2[i, j] = array[a];
            //        a++;
            //    }
            //}

            //for (int i = 0; i < array2.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array2.GetLength(1); j++)
            //    {
            //        Console.Write(array2[i, j]);
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();

            //int count = 3;
            //for (int i = 0; i < count; i++)
            //{   
            //    arr1[i] = array[i];
            //}

            //int b = 3;
            //for (int i = 0; i < count; i++)
            //{

            //    arr2[i] = array[b];
            //    b++;
            //}

            //int c = 5;
            //for (int i = 0; i < count; i++)
            //{
            //    arr3[i] = array[c];
            //    c++;
            //}


            //for (int i = 0; i < array3.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array3.GetLength(1); j++)
            //    {
            //       if(i == 0)
            //        {
            //            array3[i,j] = arr3[j];
            //        }
            //        else if(i == 1)
            //        {
            //            array3[i, j] = arr1[j];
            //        }
            //        else if (i == 2)
            //        {
            //            array3[i, j] = arr2[j];
            //        }

            //    }
            //}

            //for (int i = 0; i < array4.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array4.GetLength(1); j++)
            //    {
            //        if (i == 0)
            //        {
            //            array4[i, j] = arr2[j];
            //        }
            //        else if (i == 1)
            //        {
            //            array4[i, j] = arr3[j];
            //        }
            //        else if (i == 2)
            //        {
            //            array4[i, j] = arr1[j];
            //        }

            //    }
            //}

            //for (int i = 0; i < array3.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array3.GetLength(1); j++)
            //    {
            //        Console.Write(array3[i, j]);
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();

            //for (int i = 0; i < array4.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array4.GetLength(1); j++)
            //    {
            //        Console.Write(array4[i, j]);
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();

            //int v = 0;
            //for (int i = 0; i < array5.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array5.GetLength(1); j++)
            //    {
            //        if(j<4)
            //        {
            //            array5[i, j] = array2[i,v];
            //            v++;
            //        }
            //        else if( j<6)
            //        {
            //            array5[i, j] = array3[i, v];
            //            v++;
            //        }
            //        else if (j <=8)
            //        {
            //            array5[i, j] = array4[i, v];
            //            v++;
            //        }
            //    }
            //}

            //for (int i = 0; i < array5.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array5.GetLength(1); j++)
            //    {
            //        Console.Write(array5[i, j]);
            //    }
            //    Console.WriteLine();
            //}

            #endregion

            #region 2차원배열 합치기
            // 이건 수직(열)으로 합치는거군아 
            //int[,] array1 = { { 1, 2, 3 }, { 4, 5, 6 } };
            //int[,] array2 = { { 7, 8, 9 }, { 10, 11, 12 } };

            //// array1과 array2의 행과 열 길이
            //int rows1 = array1.GetLength(0);
            //int cols1 = array1.GetLength(1);
            //int rows2 = array2.GetLength(0);
            //int cols2 = array2.GetLength(1);

            //// 새로운 배열 생성
            //int[,] combinedArray = new int[rows1 + rows2, cols1];

            //// array1의 요소 복사
            //for (int i = 0; i < rows1; i++)
            //{
            //    for (int j = 0; j < cols1; j++)
            //    {
            //        combinedArray[i, j] = array1[i, j];
            //    }
            //}

            //// array2의 요소 복사
            //for (int i = 0; i < rows2; i++)
            //{
            //    for (int j = 0; j < cols2; j++)
            //    {
            //        combinedArray[i + rows1, j] = array2[i, j];
            //    }
            //}

            //// 결과 출력
            //Console.WriteLine("Combined Array:");
            //for (int i = 0; i < combinedArray.GetLength(0); i++)
            //{
            //    for (int j = 0; j < combinedArray.GetLength(1); j++)
            //    {
            //        Console.Write(combinedArray[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}


            //열로 합치기
            //int[,] array1 = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            //int[,] array2 = { { 7, 8 }, { 9, 10 }, { 11, 12 } };

            //int rows1 = array1.GetLength(0);
            //int cols1 = array1.GetLength(1);
            //int rows2 = array2.GetLength(0);
            //int cols2 = array2.GetLength(1);

            //// 새로운 배열 생성
            //int[,] combinedArray = new int[rows1, cols1 + cols2];

            //// array1 복사
            //for (int i = 0; i < rows1; i++)
            //{
            //    for (int j = 0; j < cols1; j++)
            //    {
            //        combinedArray[i, j] = array1[i, j];
            //    }
            //}

            //// array2 복사
            //for (int i = 0; i < rows2; i++)
            //{
            //    for (int j = 0; j < cols2; j++)
            //    {
            //        combinedArray[i, j + cols1] = array2[i, j];
            //    }
            //}

            //// 결과 출력
            //Console.WriteLine("Combined Array:");
            //for (int i = 0; i < combinedArray.GetLength(0); i++)
            //{
            //    for (int j = 0; j < combinedArray.GetLength(1); j++)
            //    {
            //        Console.Write(combinedArray[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            #endregion

            #region 열로 합치기

            //Random random = new Random();
            //int[] array = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //int[,] array2 = new int[3, 3];
            //int[,] array3 = new int[3, 3];
            //int[,] array4 = new int[3, 3];
            //int[,] array5 = new int[9, 9];
            //int[] arr1 = new int[3];
            //int[] arr2 = new int[3];
            //int[] arr3 = new int[3];


            //for (int i = array.Length - 1; i > 0; i--)
            //{
            //    int j = random.Next(0, i + 1);

            //    int temp = array[i];
            //    array[i] = array[j];
            //    array[j] = temp;
            //}


            //int a = 0;
            //for (int i = 0; i < array2.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array2.GetLength(1); j++)
            //    {
            //        array2[i, j] = array[a];
            //        a++;
            //    }
            //}

            //int count = 3;
            //for (int i = 0; i < count; i++)
            //{
            //    arr1[i] = array[i];
            //}

            //int b = 3;
            //for (int i = 0; i < count; i++)
            //{

            //    arr2[i] = array[b];
            //    b++;
            //}

            //int c = 5;
            //for (int i = 0; i < count; i++)
            //{
            //    arr3[i] = array[c];
            //    c++;
            //}


            //for (int i = 0; i < array3.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array3.GetLength(1); j++)
            //    {
            //        if (i == 0)
            //        {
            //            array3[i, j] = arr3[j];
            //        }
            //        else if (i == 1)
            //        {
            //            array3[i, j] = arr1[j];
            //        }
            //        else if (i == 2)
            //        {
            //            array3[i, j] = arr2[j];
            //        }

            //    }
            //}

            //for (int i = 0; i < array4.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array4.GetLength(1); j++)
            //    {
            //        if (i == 0)
            //        {
            //            array4[i, j] = arr2[j];
            //        }
            //        else if (i == 1)
            //        {
            //            array4[i, j] = arr3[j];
            //        }
            //        else if (i == 2)
            //        {
            //            array4[i, j] = arr1[j];
            //        }

            //    }
            //}

            //int rows1 = array2.GetLength(0);
            //int cols1 = array2.GetLength(1);
            //int rows2 = array3.GetLength(0);
            //int cols2 = array3.GetLength(1);
            //int rows3 = array4.GetLength(0);
            //int cols3 = array4.GetLength(1);

            //int[,] sudoku = new int[rows1, cols1 + cols2 + cols3];

            //// array2 복사
            //for (int i = 0; i < rows1; i++)
            //{
            //    for (int j = 0; j < cols1; j++)
            //    {
            //        sudoku[i, j] = array2[i, j];
            //    }
            //}

            //// array3 복사
            //for (int i = 0; i < rows2; i++)
            //{
            //    for (int j = 0; j < cols2; j++)
            //    {
            //        sudoku[i, j + cols1] = array3[i, j];
            //    }
            //}

            //// array4 복사
            //for (int i = 0; i < rows2; i++)
            //{
            //    for (int j = 0; j < cols2; j++)
            //    {
            //        sudoku[i, j + cols1 + cols2] = array4[i, j];
            //    }
            //}

            //for (int i = 0; i < sudoku.GetLength(0); i++)
            //{
            //    for (int j = 0; j < sudoku.GetLength(1); j++)
            //    {
            //        Console.Write(sudoku[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}
            //for (int i = 0; i < array2.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array2.GetLength(1); j++)
            //    {
            //        Console.Write(array2[i, j]);
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();

            //for (int i = 0; i < array3.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array3.GetLength(1); j++)
            //    {
            //        Console.Write(array3[i, j]);
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();

            //for (int i = 0; i < array4.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array4.GetLength(1); j++)
            //    {
            //        Console.Write(array4[i, j]);
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();

            #endregion

            #region 열 나누기 
            //    int[,] array = {
            //    { 1, 2, 3 },
            //    { 4, 5, 6 },
            //    { 7, 8, 9 }
            //};

            //    int columns = array.GetLength(1); // 배열의 열 수
            //    int[,] separatedColumns = new int[columns, array.GetLength(0)]; // 분리된 열을 저장할 배열

            //    // 열을 분리하여 저장
            //    for (int col = 0; col < columns; col++)
            //    {
            //        for (int row = 0; row < array.GetLength(0); row++)
            //        {
            //            separatedColumns[col, row] = array[row, col];
            //        }
            //    }

            //    // 분리된 열 출력
            //    for (int col = 0; col < columns; col++)
            //    {
            //        Console.WriteLine($"Column {col + 1}:");
            //        for (int row = 0; row < array.GetLength(0); row++)
            //        {
            //            Console.WriteLine(separatedColumns[col, row]);
            //        }
            //        Console.WriteLine();
            //    }

            #endregion

            #region 피셔 에이츠 셔플 알고리즘으로 만든거 열 분리하기

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

            for (int i = 0; i < array2.GetLength(0); i++)
            {
                for (int j = 0; j < array2.GetLength(1); j++)
                {
                    Console.Write(array2[i,j]);
                }
                Console.WriteLine();
            }


            #region 열분리 해보기
            int[,] row1 = new int[3, 1];
            int[,] row2 = new int[3, 1];
            int[,] row3 = new int[3, 1];

            //row1 분리 
            for(int i =0; i< row1.GetLength(0); i++) 
            {
                for(int j = 0; j< row2.GetLength(1); j++)
                {
                    row1[i, j] = array2[i, j];
                }
            }

            //row2 분리 
            for (int i = 0; i < row1.GetLength(0); i++)
            {
                for (int j = 0; j < row2.GetLength(1); j++)
                {
                    row2[i, j] = array2[i, j+1];
                }
            }

            //row3 분리 
            for (int i = 0; i < row1.GetLength(0); i++)
            {
                for (int j = 0; j < row2.GetLength(1); j++)
                {
                    row3[i, j] = array2[i, j+2];
                }
            }

            for (int i = 0; i < row1.GetLength(0); i++)
            {
                for (int j = 0; j < row2.GetLength(1); j++)
                {
                    Console.WriteLine(row3[i,j]);
                }
            }
            #endregion


            #endregion
        }
    }
}
