
namespace exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("---4.2.1---");
            NewMethod1();
            Console.WriteLine("\n---4.2.2---");
            Exercise2();
            Console.WriteLine("\n---4.2.3---");
            Exercise3();
        }
        //P89～90を参考にする
        private static void NewMethod1() {
            //if-else文を使用（コード4.10）
            var line = Console.ReadLine();
            int num = int.Parse(line);
            if (num < 0) {
                Console.WriteLine(num);
            } else if(num<100){
                Console.WriteLine(num * 2);
            }else if (num < 500) {

            }
                }

        private static void Exercise2() {
            //switch式を使用(コード4.11)

        }

        private static void Exercise3() {
            
        }
    }
}
