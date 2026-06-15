using System.Text;

namespace Section05 {
    internal class Program {
        static void Main(string[] args) {           
            var separator = ",";
            var result = String.Join(separator, GetWords());
        //    var sb = new StringBuilder();
        //    foreach (var word in GetWords()) {
        //        sb.Append(word);
        //    }
            Console.WriteLine(result);
        }

        private static IEnumerable<object> GetWords() {
            return ["Orange", "Lemon", "Strawberry"];
        }
    }
}
