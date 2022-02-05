var lines = File.ReadAllLines("27-88a.txt");
var n_k = lines[0].Split(' ');
var n = int.Parse(n_k[0]);
var k = int.Parse(n_k[1]);
var a = lines[1..].Select(line => int.Parse(line)).ToArray();

long maxsum = long.MinValue;
for (int begin = 0; begin < a.Length; begin++)
{
    for (int end = begin + 1; end <= a.Length; end++)
    {
        long sum = 0;
        int count = 0;
        for (int i = begin; i < end; i++)
        {
            sum += a[i];
            if (IsPrime(Math.Abs(a[i])) && a[i] < 0) count++;
        }
        if (count % k == 0) maxsum = Math.Max(maxsum, sum);
    }
}

Console.WriteLine(maxsum);


static bool IsPrime(int n)
{
    for (int d = 2; d * d <= n; d++)
    {
        if (n % d == 0) return false;
    }
    return true;
}
