using System;
using System.IO;
using Newtonsoft.Json;


namespace Task3
{
	public class Program
	{
		private const string _reportFileName = "report.json";

		static void Main(string[] args)
		{
			// Все .json файлы класть рядом с бин файлом (в bin)
			var jsonTest = GetJson(args[0]);
			var jsonValues = GetJson(args[1]);

			var deserializedJsonTest = JsonConvert.DeserializeObject<Test>(jsonTest);
			var deserializedJsonValues = JsonConvert.DeserializeObject<TestValues>(jsonValues);

			foreach (var values in deserializedJsonValues.Values)
			{
				if (deserializedJsonTest.Id == values.Id)
					deserializedJsonTest.Value = values.Value;

				foreach (var inValues in deserializedJsonTest.Values)
				{
					if (inValues.Id == values.Id)
						inValues.Value = values.Value;
				}
			}

			var reportJson = JsonConvert.SerializeObject(deserializedJsonTest);

			WriteReportJsonFile(reportJson);

			Console.WriteLine(reportJson);
		}

		private static void WriteReportJsonFile(string jsonString)
		{
			if (File.Exists(_reportFileName))
				File.Delete(_reportFileName);
			File.Create(_reportFileName).Close();
			File.AppendAllText(_reportFileName, jsonString);
		}

		private static string GetJson(string fileName)
		{
			return File.ReadAllText(fileName);
		}
	}

	public class Test
	{ 
		public int Id { get; set; }

		public string Title { get; set; }

		public string Value { get; set; }

		public Test[] Values { get; set; }
	}

	public class TestValues
	{ 
		public InTestValues[] Values { get; set; }
	}

	public class InTestValues
	{
		public int Id { get; set; }

		public string Value { get; set; }
	}
}
