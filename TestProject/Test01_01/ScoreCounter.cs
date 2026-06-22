namespace Test01_01 {
    public class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }

        //メソッドの概要：カンマ区切りで分割
        private static IEnumerable<Student> ReadScore(string filePath) {
            var sales = new List<Student>();
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines) {
                var items = line.Split(',');
                var student = new Student {
                    Name = items[0],
                    Subject = items[1],
                    Score = int.Parse(items[2]),
                };
                sales.Add(student);
            }
            return sales;
        }

        //メソッドの概要：科目が登録済みか確認し、科目ごとに点数を集計
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>();

            foreach (var item in _score) {
                if (dict.ContainsKey(item.Subject))
                    dict[item.Subject] += item.Score;
                else
                    dict[item.Subject] = item.Score;
            }
            return dict;
        }
    }
}
