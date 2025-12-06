using System.Diagnostics;

int N = 10_000_000;

Stopwatch sw = Stopwatch.StartNew();

// initialize bool[] [0:false, 1:false, 2:true, 3:true, 4:true,..., N:true]
bool[] isPrime = new bool[N + 1];
for (int n = 2; n <= N; n++)
{
    isPrime[n] = true;
}

int[] φ = new int[N + 1];
for (int n = 0; n <= N; n++)
{
    φ[n] = n;
}

// List<List<int>> primeFactors = new(N + 1);
// for (int n = 0; n <= N; n++)
// {
//     primeFactors.Add([]);
// }

int p = 1;
while (++p <= N)
{
    if (!isPrime[p]) continue;

    for (int n = 1; p * n <= N; n++)
    {
        if (n != 1) isPrime[p * n] = false;

        // primeFactors[p * n].Add(p);

        // Using Euler's product formula for eulers totient function:
        // φ(n) = n * ∏(1 - 1/p) for all prime p dividing n
        // Initial value of totient[p*n] is p*n => p divides totient[p*n]
        φ[p * n] = φ[p * n] / p * (p - 1);
    }
}

int minPalindrome = Enumerable.Range(2, N - 1)
    .OrderBy(n => n / (double)φ[n])
    .First(n =>
    {
        var s1 = n.ToString();
        var s2 = φ[n].ToString();
        return s1.Length == s2.Length && s1.OrderBy(c => c).SequenceEqual(s2.OrderBy(c => c));
    });

sw.Stop();
Console.WriteLine($"Time: {sw.ElapsedMilliseconds} ms");
Console.WriteLine($"Value of n, 1 < n <10^7, for which φ(n) is a permutation of n and the ratio n/φ(n) produces a minimum is n = {minPalindrome}.");
