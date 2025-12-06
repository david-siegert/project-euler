using System.Diagnostics;
// int N = 10;
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

// Generate list of integers relatively prime to n 
// by removing multiples of each prime factor of n
List<List<int>> relativelyPrime = [];
for (int n = 0; n <= N; n++)
{
    relativelyPrime.Add([]);

}
for (int n = 2; n <= N; n++)
{
    int[] integers = Enumerable.Range(0, n + 1).ToArray();

    foreach (int primeFactor in primeFactors[n])
    {
        int i = 0;
        while (n >= (primeFactor * ++i))
        {
            integers[primeFactor * i] = 0;
        }
    }

    List<int> relativelyPrimeToN = [];
    for (int i = 1; i <= n; i++)
    {
        if (integers[i] != 0)
            relativelyPrimeToN.Add(i);
    }

    relativelyPrime[n] = relativelyPrimeToN;

}


sw.Stop();
Console.WriteLine($"Time: {sw.ElapsedMilliseconds} ms");
TestResults();


void TestResults()
{
    if (φ[2] == 1 &&
        φ[3] == 2 &&
        φ[4] == 2 &&
        φ[5] == 4 &&
        φ[6] == 2 &&
        φ[7] == 6 &&
        φ[8] == 4 &&
        φ[9] == 6 &&
        φ[10] == 4 &&
        relativelyPrime[2].SequenceEqual(new int[] { 1 }) &&
        relativelyPrime[3].SequenceEqual(new int[] { 1, 2 }) &&
        relativelyPrime[4].SequenceEqual(new int[] { 1, 3 }) &&
        relativelyPrime[5].SequenceEqual(new int[] { 1, 2, 3, 4 }) &&
        relativelyPrime[6].SequenceEqual(new int[] { 1, 5 }) &&
        relativelyPrime[7].SequenceEqual(new int[] { 1, 2, 3, 4, 5, 6 }) &&
        relativelyPrime[8].SequenceEqual(new int[] { 1, 3, 5, 7 }) &&
        relativelyPrime[9].SequenceEqual(new int[] { 1, 2, 4, 5, 7, 8 }) &&
        relativelyPrime[10].SequenceEqual(new int[] { 1, 3, 7, 9 }))
    {
        Console.WriteLine("Test passed.");
    }
    else
    {
        Console.WriteLine("Test failed.");
    }

}
