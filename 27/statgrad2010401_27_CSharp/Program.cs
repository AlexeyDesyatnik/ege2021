using System;
using System.Linq;

namespace statgrad2010401_27_CSharp
{
    class Program
    {
        static void SolutionA()
        {
            var nums = System.IO.File
                .ReadAllLines("27-A.txt")
                .Skip(1)
                .Select(line => int.Parse(line))
                .ToArray();

            var max_triplet = 0;
            for (int i = 0; i < nums.Length; i++)
                for (int j = i + 1; j < nums.Length; j++)
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        var s = nums[i] + nums[j] + nums[k];
                        if (s % 3 == 0 && s > max_triplet)
                            max_triplet = s;
                    }
            Console.WriteLine(max_triplet);
        }
        
        static void SolutionB() {
            var nums = System.IO.File
                .ReadAllLines("27-B.txt")
                .Skip(1)
                .Select(line => int.Parse(line));
            var rem0 = nums.Where(n => n % 3 == 0).OrderByDescending(n => n);
            var rem1 = nums.Where(n => n % 3 == 1).OrderByDescending(n => n);
            var rem2 = nums.Where(n => n % 3 == 2).OrderByDescending(n => n);
            int[] candidates = {
                // 0 1 2
                rem0.First() + rem1.First() + rem2.First(),
                // 0 0 0
                rem0.Take(3).Sum(),
                // 1 1 1
                rem1.Take(3).Sum(),
                // 2 2 2
                rem2.Take(3).Sum(),         
            };
            Console.WriteLine(candidates.Max());
        }
        static void Main(string[] args)
        {
            SolutionA();
            SolutionB();
        }
    }
}
