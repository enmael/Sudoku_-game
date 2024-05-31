using System;

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

            #region

            #region 9x9 의 스도쿠 만들기
   
            #endregion 

        }
    }
}