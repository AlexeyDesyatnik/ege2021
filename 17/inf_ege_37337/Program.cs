/*
В файле содержится последовательность из 10 000 натуральных чисел. Каждое число
не превышает 10 000. Определите и запишите в ответе сначала количество пар
элементов последовательности, у которых различные остатки от деления на d = 160
и хотя бы одно из чисел делится на p = 7, затем максимальную из сумм элементов
таких пар. В данной задаче под парой подразумевается два различных элемента
последовательности. Порядок элементов в паре не важен.
*/
using System;
using System.IO;
using System.Linq;

class Program
{
  static void Main()
  {
    var numbers = File.ReadLines("17.txt")
                  .Select(line => int.Parse(line))
                  .ToList();
    var count = 0;
    var maxsum = 0;
    for (var i = 0; i < numbers.Count() - 1; i++)
    {
      for (var j = i + 1; j < numbers.Count(); j++)
      {
        if (numbers[i] % 7 == 0 || numbers[j] % 7 == 0)
        {
          if (numbers[i] % 160 != numbers[j] % 160)
          {
            count += 1;
            maxsum = Math.Max(maxsum, numbers[i] + numbers[j]);
          }
        }
      }
    }
    Console.WriteLine($"{count} {maxsum}");
  }
}
