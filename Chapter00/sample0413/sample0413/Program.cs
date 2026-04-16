using System.Diagnostics.CodeAnalysis;

namespace sample0413
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("表示回数:");
            string? inputNum = Console.ReadLine();//入力

            int count = int.Parse(inputNum);//整数への変換

            //for (int i = 0; i < count; i++) {
            int i = 0;
            while (i < count)
            {
                if ((i + 1) % 2 == 0)
                {
                    Console.WriteLine((i + 1) + ":" + "群馬県太田市");//画面出力
                }
                i++;
            }
        }
    }
}
