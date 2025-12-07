using System.Diagnostics;
using System.Reflection.Metadata;
// int N = 10;
int D = 1_000_000;

Stopwatch sw = Stopwatch.StartNew();

List<(int n, int d)> candidates = [];

int n = 3 * D / 7 + 1; // +1 to offset initial --n;
while (--n > 1)
{
    // find first d > 7n/3 with GCD(d, n) == 1

    for (int d = (int)Math.Floor(7 * n / (double)3) + 1; d <= D; d++)
    {
        if (GCD(d, n) == 1)
        {
            candidates.Add((n, d));
            break;
        }
    }
}


(int n, int d) best = candidates
    .OrderBy(c => 3 / (double)7 - (c.n / (double)c.d)).First();


sw.Stop();
Console.WriteLine($"Time: {sw.ElapsedMilliseconds} ms");
Console.WriteLine($"n/d = {best.n}/{best.d} = {best.n / (double)best.d} with distance = {3 / (double)7 - (best.n / (double)best.d):0.00000000000000000}.");


// calculate GCD of two numbers
int GCD(int a, int b)
{
    while (b != 0)
    {
        int temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}
