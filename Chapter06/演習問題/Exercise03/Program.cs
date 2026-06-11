
using System.Runtime.InteropServices;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";
            #region
            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);

            Console.WriteLine("6.3.99");
            Exercise6(text);
            #endregion
        }

        private static void Exercise1(string text) {
            var spaces = text.Count(c => c == ' ');
            Console.WriteLine($"空白数:{spaces}");
            //別の書き方
            //Console.WriteLine("空白数:{0}", spaces);
        }

        private static void Exercise2(string text) {
            Console.Write("検索：");
            var search = Console.ReadLine();
            Console.Write("置換：");
            var replace = Console.ReadLine();

            var replaced = text.Replace(search, replace);
            Console.WriteLine(replaced);
        }

        private static void Exercise3(string text) {
            //やらなくてよい
        }

        private static void Exercise4(string text) {
            var word = text.Split(' ');
            Console.WriteLine("単語数" + word.Length);
        }

        private static void Exercise5(string text) {
            var words = text.Split(' ').Where(s=>s.Length<=4);
            //即時実行↓　配列はToArray
            //text.Split(' ').Where(s=>s.Length<=4).ToList().ForEach(Console.WriteLine);        
        }

        //アルファベットの数をカウントして表示する
        private static void Exercise6(string text) {
            //辞典(ディクショナリ)を使った集計
            //全部小文字にする,空白を無くす
            var str = text.ToLower().Replace(" ","");

            var alphDicCount = Enumerable.Range('a', 26).
            ToDictionary(num => ((char)num), num => 0);

            //var dict = new SortedDictionary<char, int>();
            foreach (var c in str) {
                if (alphDicCount.ContainsKey(c))
                    alphDicCount[c]++;               
            }
            foreach (var word in alphDicCount) {
                Console.WriteLine(word.Key + ":" + word.Value);
            }

            //配列を用いた集計
            var array = Enumerable.Repeat('a', 26).ToArray();
            foreach (var alph in str) {
                array[alph - 'a']++;
            }
            for (char ch = 'a'; ch <= 'z'; ch++) {
                Console.WriteLine($"{ch}:{array[ch - 'a']}");
            }

            //'a'から順にカウント           
            for (char ch = 'a'; ch <= 'z'; ch++) {
                Console.WriteLine($"{ch}:{str.Count(c=>c==ch)}");//ラムダ演算子
            }
        }
    }
}
