using System;
using System.Globalization;
namespace DateKeywordParser;
class Program
{
	static void Main(string[] args)
	{
		string template1 = "backup_NOW.sql";
		string template2 = "logs_NOW-1d.txt";
		string template3 = "report_YESTERDAY.csv";
		string template4 = "snapshot_Format(NOW, \"yyyy-MM-dd\").json";

		Console.WriteLine(DateKeywordParser.Parse(template1));
		Console.WriteLine(DateKeywordParser.Parse(template2));
		Console.WriteLine(DateKeywordParser.Parse(template3));
		Console.WriteLine(DateKeywordParser.Parse(template4, new CultureInfo("fr-FR")));
	}
}
