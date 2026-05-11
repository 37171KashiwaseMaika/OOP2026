namespace SalesCalculator {
    internal class Program {
        static void Main(string[] args) {
            
            var sales =new SalesCounter(@"data\sales.csv");
            var amountPerStore = sales.GetPerStoreSales();
            foreach(var obj in amountPerStore) {
                Console.WriteLine($"{obj.Key}{obj.Value}");
            }
        }
    }
}
