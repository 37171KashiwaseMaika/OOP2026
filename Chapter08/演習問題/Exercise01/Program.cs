
using System.Diagnostics.Metrics;
using System.Text;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";

            Exercise1(text);
            Console.WriteLine();
            Exercise2(text);
        }
        
        private static void Exercise1(string text) {
            var dict = new Dictionary<char,int>();//dict　辞書


            var words = text.Split(' ');
            var sb = new StringBuilder();

            
            foreach (var item in words.Skip(1)) {
                var uppt = text.ToUpper();
            }

            foreach (var item in dict) {
                //if ('A' <= ch && ch <= 'Z') {
                //    var counts = item.Count(s => s == ch);
                //}              
            }
        }

        private static void Exercise2(string text) {
            
        }
    }
}
