
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {

            int[] numbers = [5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35];

            #region
            Console.WriteLine("\n7.1.1");//\n改行
            Exercise1(numbers);

            Console.WriteLine("\n7.1.2");
            Exercise2(numbers);

            Console.WriteLine("\n7.1.3");
            Exercise3(numbers);

            Console.WriteLine("\n7.1.4");
            Exercise4(numbers);

            Console.WriteLine("\n7.1.5");
            Exercise5(numbers);
        }
        #endregion


        private static void Exercise1(int[] numbers) {
            var max = numbers.Max();
            Console.WriteLine(max);
        }

        private static void Exercise2(int[] numbers) {
            //foreach(var n in numbers.TakeLast(2)){
            //Console.WriteLine(n);}
            var ban = numbers.TakeLast(2);
            foreach (var item in ban) {
                Console.WriteLine(item);
            }
        }

        private static void Exercise3(int[] numbers) {
            var plus = numbers.Select(n => n.ToString("000"));
            foreach (var item in plus) {
                Console.WriteLine(item);
            }
        }

        private static void Exercise4(int[] numbers) {
            //foreach(var n in numbers.OrderBy(x=>x)).Take(3){
            //Console.WriteLine(n);}
            var sorted = numbers.OrderBy(n => n).Take(3);
            foreach (var item in sorted) {
                Console.WriteLine(item);
            }
        }

        private static void Exercise5(int[] numbers) {
            var results = numbers.Distinct().Count(n=>n>10);
            Console.WriteLine(results);
        }
    }
}
