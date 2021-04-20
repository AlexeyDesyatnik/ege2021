using System;
using System.Collections.Generic;
using System.Linq;

namespace polyakov3153
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("26-39.txt");
            var maxWeight = int.Parse(lines[0].Split(" ")[1]);
            var weights = lines[1..].Select(line => int.Parse(line));
            Func<int, bool> priorityPredicate = w => w >= 180 && w <= 200;
            var usedWeight = 0;
            var weightCount = 0;
            // Грузим приоритетное
            var priorityWeights = weights.Where(priorityPredicate).OrderByDescending(w => w);
            foreach (var w in priorityWeights)
            {
                if (usedWeight + w <= maxWeight)
                {
                    usedWeight += w;
                    weightCount++;
                }
            }

            // Грузим остальное
            var otherWeights = weights
                .Where(w => !priorityPredicate(w))
                .OrderBy(w => w)
                .Select(w => (w, used: false))
                .ToArray();
            var loadedWeights = new List<(int w, int idx)>();

            for (var i = 0; i < otherWeights.Length; i++)
            {
                if (usedWeight + otherWeights[i].w <= maxWeight)
                {
                    usedWeight += otherWeights[i].w;
                    otherWeights[i].used = true;
                    loadedWeights.Add((otherWeights[i].w, i));
                    weightCount++;
                }
            }

            // Оптимизируем
            var loadedWeightsArr = loadedWeights.ToArray();
            for (var i = loadedWeightsArr.Length - 1; i >= 0; i--) {
                var newWeightIdx = -1;
                for (var j = 0; j < otherWeights.Length; j++) {
                    if (otherWeights[j].used) continue;
                    var newUsedWeight = usedWeight - loadedWeightsArr[i].w + otherWeights[j].w;
                    if (newUsedWeight <= maxWeight)
                        newWeightIdx = j;
                }
                if (newWeightIdx >= 0) {
                    usedWeight = usedWeight - loadedWeightsArr[i].w + otherWeights[newWeightIdx].w;
                    otherWeights[loadedWeightsArr[i].idx].used = false;
                    otherWeights[newWeightIdx].used = true;
                    loadedWeightsArr[i].w = otherWeights[newWeightIdx].w;
                    loadedWeightsArr[i].idx = newWeightIdx;
                }
            }

            Console.WriteLine($"Погружено: {weightCount}");
            Console.WriteLine($"Общая масса: {usedWeight}");
        }
    }
}
