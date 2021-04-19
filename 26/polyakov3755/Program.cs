using System;
using System.Collections.Generic;
using System.Linq;

namespace polyakov3755
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = System.IO.File.ReadAllLines("test.txt");
            var info = file[0].Split(" ").Select(d => Int32.Parse(d)).ToArray();
            var budget = info[1];
            //Console.WriteLine(info[0]);
            //Console.WriteLine(info[1]);

            var prod_a = new List<Tuple<int, int>>();
            var prod_z = new List<Tuple<int, int>>();

            foreach (var line in file.Skip(1))
            {
                var data = line.Split();
                var type = data[0];
                var price = int.Parse(data[1]);
                var amount = int.Parse(data[2]);
                if (type == "A")
                    prod_a.Add(new Tuple<int, int>(price, amount));
                else
                    prod_z.Add(new Tuple<int, int>(price, amount));
            }
            prod_a.Sort();
            prod_z.Sort();
            
            // Покупаем изделия А
            foreach (var p in prod_a)
            {
                var amount = p.Item1;
                var price = p.Item2;
                while (budget - price >= 0 && amount > 0)
                {
                    budget -= price;
                    amount--;
                }
            }

            // Теперь покупаем изделия тип Z
            var z_count = 0;
            foreach (var p in prod_z) {
                var price = p.Item1;
                var amount = p.Item2;
                while (budget - price >= 0 && amount > 0) {
                    budget -= price;
                    amount--;
                    z_count++;
                }                
            }

            Console.WriteLine(z_count);
            Console.WriteLine(budget);
        }
    }
}
