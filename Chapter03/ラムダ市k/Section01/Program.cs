namespace Section01 {
    internal class Program {

        static void Main(string[] args) {
            var cities = new List<string> {
                "Tokyo",
                "New Delhi",
                "Bangkok",
                "London",
                "Paris",
                "Berlin",
                "Canberra",
                "Hong Kong",
            };

            //P134～137
            //条件（文字数が6文字以上、oを含む、最後がn）
            var names = cities.FindAll(s => s.Length >= 6 && s.Contains('o') && s.EndsWith('n'));//文字列の場合はs(string)
            foreach (var s in names) {
                Console.WriteLine(s);
            }
        }
    }
}
