int N = 1000_000;
int maxN = 0;
Dictionary<(int, int), int> GCDCache = [];

WrapInStopwatch(() =>
{
    maxN = Enumerable.Range(2, N - 1).MaxBy(n => n / (double)Totient(n));
});

OutputMaximum();


void WrapInStopwatch(Action action)
{
    var stopwatch = System.Diagnostics.Stopwatch.StartNew();
    action();
    stopwatch.Stop();
    Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
}
void OutputMaximum()
{
    Console.WriteLine($"For n <= {N}, n = {maxN} has the maximum value n/φ(n) = {maxN / (double)Totient(maxN)}");
}

void CacheGCD(int a, int b, int value)
{
    for (int i = 1; i * a <= N && i * b <= N; i++)
    {
        GCDCache[(a * i, b * i)] = value * i;
        GCDCache[(b * i, a * i)] = value * i;
    }

}
int GCD(int a, int b)
{
    if (GCDCache.TryGetValue((a, b), out int cachedGCD2))
        return cachedGCD2;

    int originalA = a;
    int originalB = b;

    while (b != 0)
        (a, b) = (b, a % b);

    CacheGCD(originalA, originalB, a);
    return a;

}
int Totient(int n)
{
    int count = 0;

    for (int i = 1; i < n; i++)
    {
        if (GCD(n, i) == 1)
        {
            count++;
        }
    }

    return count;
}


