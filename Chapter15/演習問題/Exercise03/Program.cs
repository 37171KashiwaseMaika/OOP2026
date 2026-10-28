using Exercise03;

var service = new Take20Processor();
var processor = new TextFileProcessor(service);
//Console.Write("パスの入力:");
//processor.Run(Console.ReadLine());
string fileName = @"C:\\Users\\infosys\\source\\repos\\OOP2026\\Chapter15\\演習問題\\Exercise03\\枕草子.txt";
processor.Run(fileName);