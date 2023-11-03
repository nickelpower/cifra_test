using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
  internal class Program
  {
    static void Main(string[] args)
    {
      //Пользователь производит ввод данных
      Console.WriteLine("Введите длину массива n = ");
      var n = int.Parse(Console.ReadLine());
      Console.WriteLine("Введите длину шага m = ");
      var m = int.Parse(Console.ReadLine());

      //Создаем список из n элементов
      List<int> initialList = new List<int>();

      for (int i = 1; i <= n; i++)
      {
        initialList.Add(i);
      }

      //Если шаг больше длины списка, то создаем круговой список такой длины,
      //чтобы количество элементов в нем было больше длины шага
      var circleList = new List<int>();
      
      if (n < m)
      {
        while (circleList.Count() <= m)
        {
          circleList = circleList.Concat(initialList).ToList();
        }
      }

      //В цикле создаем списки длиной = длине шага, пока не появится список, последний элемент которого = 1
      //Первый элемент каждого списка записываем в результирующую строку
      List<int> stepList;
      string result = null;

      do
      {
        circleList = circleList.Concat(initialList).ToList();
        stepList = circleList.Take(m).ToList();
        result+=stepList.First();
        circleList.RemoveRange(0, m - 1);
      } while (stepList.Last<int>()!=1);

      //Выводим результирующий список в одну строку
      Console.Write(result);
      Console.ReadKey();
    }
  }
}
