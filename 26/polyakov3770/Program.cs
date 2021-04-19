using System;
using System.Collections.Generic;
using System.Linq;

namespace polyakov3770
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = System.IO.File
                .ReadAllLines("26-53.txt")
                .Skip(1)
                .Select(line => Int32.Parse(line))
                .ToList();
            var numSet = new HashSet<int>(nums);
            var count = 0;
            var minAvg = 1000_000_000;
            for (var i = 0; i < nums.Count; i++)
                for (var j = i + 1; j < nums.Count; j++)
                {
                    if (nums[i] % 2 != 0 || nums[j] % 2 != 0) continue;
                    var avg = (nums[i] + nums[j]) / 2;
                    if (numSet.Contains(avg))
                    {
                        count++;
                        if (minAvg > avg) minAvg = avg;
                    }
                }
            Console.WriteLine(count);
            Console.WriteLine(minAvg);
        }
    }
}
