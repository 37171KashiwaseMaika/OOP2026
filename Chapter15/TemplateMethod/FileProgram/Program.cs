using TextFileProcessor;

string path = @"C:\Users\infosys\source\repos\OOP2026\Chapter14\演習問題\Exercise01_WPF\走れメロス.txt";
TextProcessor.Run<FileProgramProcessor>(path);




public class FileProgramProcessor : TextProcessor {
    private int _count = 0;
    private string _tan = "";

    protected override void Initialize(string fname) {
        Console.Write("カウントしたい単語:");
        _count = 0;
        _tan = Console.ReadLine();
    }

    protected override void Execute(string line) {
        if (string.IsNullOrEmpty(_tan))
            return;

        int index = 0;
        
        while ((index = line.IndexOf(_tan, index)) >= 0) { 
            _count++;
            index += _tan.Length;
        }
    }

    protected override void Terminate() =>
        Console.WriteLine("{0}個", _count);
}