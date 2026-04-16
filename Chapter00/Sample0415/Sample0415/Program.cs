using System.Security.Cryptography.X509Certificates;

namespace Sample0415
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] array = new int[10];

            //入力
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("array[" + i + "]=");
                array[i] = int.Parse(Console.ReadLine());

            }

            //集計
            //int sum = 0;
            //for (int i = 0; i < array.Length; i++)
            //{
            //    sum += array[i];
            //}

            //出力
            for (int i = 0; i < array.Length; i++)
            {
                astOut(array[i]);

            }
            //合計を出力
            Console.WriteLine("合計値:" + array.Where(n=>n%2==0).Sum());
        }
        static void astOut(int num)
        {
            for (int j = 0; j < num; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}
