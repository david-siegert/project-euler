using System.Diagnostics;
using System.Numerics;
int N = 12_000;

Stopwatch sw = Stopwatch.StartNew();


BigInteger sum = 0;

for (int d = 1; d <= N; d++)
{
    // Correct integer bounds: strictly between 1/3 and 1/2
    int start = d / 3 + 1;       // smallest n with n > d/3
    int end = (d - 1) / 2;       // largest n with n < d/2

    for (int n = start; n <= end; n++)
    {
        if (GCD(d, n) == 1)
        {
            sum++;
        }
    }
}


sw.Stop();
Console.WriteLine($"Time: {sw.ElapsedMilliseconds} ms");

Console.WriteLine($"Sum of reduced fractions between 1/3 and 1/2 for d <= 12000: {sum}.");



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
