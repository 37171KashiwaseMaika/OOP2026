using Exercise01;
using System.Security.Cryptography.X509Certificates;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {

            var p1 = new YearMonth(2000, 7);
            var p2 = new YearMonth(2000, 7);
            if (p1 == p2) {
                Console.WriteLine("p1とp2は等しい");
            } else {
                Console.WriteLine("等しくない");
            }
        }
    }
}
