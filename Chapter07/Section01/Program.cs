namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 9, 7, 5, 4, 2, 5, 4, 0, 4, 1, 0, 4 };
            //var average = numbers.Average();

            var books = Books.GetBooks();
            var average = books.Average(x=>x.Price);
            var pageSum = books.Sum(x => x.Pages);      
            var pageMax = books.Max(x => x.Price);                  


            Console.WriteLine("平均金額:" + average);
            Console.WriteLine("合計ページ:" + pageSum);
            Console.WriteLine("高価な本:" + pageMax);
            Console.WriteLine("---500円以上の本---");
            foreach (var book in books.Where(x=>x.Price>=500)) {
                Console.WriteLine(book.Title);
                #region その他
                //foreach (var Title in books.Where(x=>x.Price>=500).Select(x=>x.Title)) {
                //Console.WriteLine(Title);
                #endregion
            }
            //本のページが250以上の上位3出す
            Console.WriteLine("---250ページ以上の上位3冊---");
            foreach (var item in books.Where(x => x.Pages >= 250).Take(3)) {
                Console.WriteLine(item.Title);
            }
        }
    }
}
