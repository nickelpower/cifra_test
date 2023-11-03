using System;
using System.Collections.Generic;
using System.IO;

namespace Task2
{
	public class Program
	{
		private static int pointX;
		private static int pointY;
		private static int radius;
			

		static void Main(string[] args)
		{
			// Текстовые файлы использовать рядом с бин файлом (в bin).
			ReadCenterCircleCoordsAndRadius(args[0]);

			var pointCoords = GetPoints(args[1]);

			foreach (var coords in pointCoords)
			{
				var x = coords[0];
				var y = coords[1];


				double h = (Math.Pow((x - pointX), 2) / Math.Pow(radius,2)) + Math.Pow((y - pointY), 2) / Math.Pow(radius, 2);

				if (h > 1)
					Console.WriteLine(2);
				else if (h < 1)
					Console.WriteLine(1);
				else
					Console.WriteLine(0);
			}
		}

		private static void ReadCenterCircleCoordsAndRadius(string fileName)
		{
			string text = File.ReadAllText(fileName);

			pointX = int.Parse(text.Split('\r')[0].Split(' ')[0]); 
			pointY = int.Parse(text.Split('\r')[0].Split(' ')[1]);
			radius = int.Parse(text.Split('\n')[1]);
		}

		private static List<int[]> GetPoints(string fileName)
		{
			string text = File.ReadAllText(fileName);
			var pointCoords = new List<int[]>();
			
			var points = text.Replace('\r', ' ').TrimEnd().Split('\n');

			foreach (var point in points)
			{
				int x = int.Parse(point.Split(' ')[0]);
				int y = int.Parse(point.Split(' ')[1]);

				pointCoords.Add(new int[2] { x, y });
			}
			return pointCoords;
		}
	}
}
