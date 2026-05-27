
namespace exercise01 {
    internal class Program {
        static void Main(string[] args) {
            List<string> langs = [
                "C#", "Java", "Ruby", "PHP", "Python", "TypeScript",
                "JavaScript", "Swift", "Go",
            ];

            Exercise1(langs);
            Console.WriteLine("---");
            Exercise2(langs);
            Console.WriteLine("---");
            Exercise3(langs);
        }

        private static void Exercise1(List<string> langs) {
            //foreach文
            Console.WriteLine("foreach文で出力");
            var name = langs.FindAll(s => s.Contains('S'));          
                foreach (var s in name) {
                    Console.WriteLine(s);                
            }

            //for文
            Console.WriteLine("\nfor文で出力");
            var cut = langs.Where(s => s.Contains('S')).ToArray();
            for (int i =0;i<cut.Length;i++) {
                Console.WriteLine(cut[i]);
            }

            //while文
            Console.WriteLine("\nwhili文で出力");
            int j = 0;
            var count = langs.Where(s => s.Contains('S')).ToArray();
            while (j < count.Length) {
                Console.WriteLine(count[j]);
                j++;
            }

        }

        private static void Exercise2(List<string> langs) {
            
        }

        private static void Exercise3(List<string> langs) {

        }
    }
}
