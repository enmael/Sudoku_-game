namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Random random = new Random();
            //int[,] array2D = new int[3, 3];
            //int[] array = new int[9] {1,2,3,4,5,6,7,8,9};
            //int[] array2 = new int[9];
            //for (int i = 0; i < array.Length; i++)
            //{
            //    int a = random.Next(1, 10);
            //    array[i] = a;
            //    Console.Write(array[i]);
            //}
            //int a = random.Next(1, 10);
            //array2[a] = array[8];
            //int count = 8;
            //int a = random.Next(0, 9);
            //array2[a] = array[count];
            //Console.WriteLine("count:" +a);
            //Console.WriteLine(array2[a]);

            Random random = new Random();
            int[] array = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] array2 = new int[9];

            int a = random.Next(1, 10);
            array2[a] = array[8];
            int right = 0;
            int left = 0;
            int count = 8;
           
                 if(a ==4)
                 {
                    right = 4;
                    left  = 4;
                    random.Next(right, 10);
                    random.Next(0, left);

                 }
                 else if(a >4) 
                 {
                    right = count-a;
                    left = 4;
                    random.Next(right, 10);
                    random.Next(0, left);
                 }
                else if (a < 4)
                {
                    right = count-a;
                    left = 4;
                    random.Next(right, 10);
                    random.Next(0, left);
                }

            


        }
    }
}
