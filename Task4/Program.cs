using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task4
{
  internal class Program
  {
    static void Main(string[] args)
    {      
      string fileLine;
      List<int> listFromFile = new List<int>();
      try
      {
        //Пользователь вводит путь к файлу
        Console.WriteLine("Введите путь к файлу с массивом: ");
        var filepath = Console.ReadLine();
        //Считываем строки из файла
        StreamReader sr = new StreamReader(filepath);
        //Считываем первую строку
        fileLine = sr.ReadLine();

        //В цикле считываем остальные строки из файла и записываем их в список
        while (fileLine != null)
        {
          listFromFile.Add(int.Parse(fileLine));
          fileLine = sr.ReadLine();
        }

        //Закрываем файл
        sr.Close();
      }

      catch (Exception e)
      {
        Console.WriteLine("Exception: " + e.Message);
      }

      //Считаем среднее значение элементов массива, приводим к целому значению
      var avg = (int)listFromFile.Average();
      int stepsSum = 0;

      //Для каждого элемента списка считаем количество шагов, необходимых для приведения к среднему значению
      //Суммируем количество шагов, записываем в результирующую переменную
      foreach (var element in listFromFile)
      {
        var steps = Math.Abs(element - avg);
        stepsSum += steps;
      }

      //Выводим результирующую переменную
      Console.WriteLine(stepsSum);
      Console.ReadKey();
    }
  }
}
