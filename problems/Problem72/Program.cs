using System.Diagnostics;
using System.Numerics;
int N = 1_000_000;

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

List<List<int>> primeFactors = new(N + 1);
for (int n = 0; n <= N; n++)
{
    primeFactors.Add([]);
}

int p = 1;
while (++p <= N)
{
    if (!isPrime[p]) continue;

    for (int n = 1; p * n <= N; n++)
    {
        if (n != 1) isPrime[p * n] = false;

        primeFactors[p * n].Add(p);

        // Using Euler's product formula for eulers totient function:
        // φ(n) = n * ∏(1 - 1/p) for all prime p dividing n
        // Initial value of totient[p*n] is p*n => p divides totient[p*n]
        φ[p * n] = φ[p * n] / p * (p - 1);
    }
}


BigInteger sum = 0;
φ.Skip(2).ToList().ForEach(v => sum = BigInteger.Add(sum, v));


sw.Stop();
Console.WriteLine($"Time: {sw.ElapsedMilliseconds} ms");

Console.WriteLine($"Sum of φ(n) for 1 ≤ n ≤ {N}: {sum}");
