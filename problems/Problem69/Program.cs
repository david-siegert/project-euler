int N = 1000_000;
List<int> primes = [];
bool[] isPrimeArray = [];
Dictionary<int, List<int>> primeFactorsOf = [];
Dictionary<int, List<int>> relativePrimesOf = [];
Dictionary<int, int> totients = [];
int maxN = 0;
double maxRatio = 0;

WrapInStopwatch(() =>
{
    primes = GetPrimes(N);

    for (int n = 1; n <= N; n++)
    {
        var factors = FindPrimeFactors(n);
        primeFactorsOf.Add(n, factors);
    }

    for (int n = 1; n <= N; n++)
    {
        if (n % 10000 == 0)
        {
            Console.WriteLine($"10000 done");
        }
        GetRelativelyPrime(n);
    }

    for (int n = 1; n <= N; n++)
    {
        int phi = relativePrimesOf[n].Count;
        totients.Add(n, phi);
    }

    for (int n = 2; n <= N; n++)
    {
        double ratio = n / totients[n];

        if (ratio > maxRatio)
        {
            maxRatio = ratio;
            maxN = n;
        }
    }
});

OutputPrimes();
OutputPrimeFactors();
// OutputRelativelyPrime();
//OutputTotients();
OutputMaximum();

void WrapInStopwatch(Action action)
{
    var stopwatch = System.Diagnostics.Stopwatch.StartNew();
    action();
    stopwatch.Stop();
    Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
}
void OutputPrimeFactors()
{
    Console.WriteLine($"Prime factors of {N}: {string.Join(", ", primeFactorsOf[N])} ");
}
void OutputPrimes()
{
    Console.WriteLine($"{primes.Count} primes under {N}.");
    //Console.WriteLine($"{primes.Count} primes under {N}: {string.Join(", ", primes)}");
}
void OutputRelativelyPrime()
{
    for (int n = 1; n <= N; n++)
        Console.WriteLine($"Relatively prime numbers to {n}: {string.Join(", ", relativePrimesOf[n])} ");
}
void OutputTotients()
{
    for (int n = 1; n <= N; n++)
        Console.WriteLine($"φ({n}) = {totients[n]}");
}
void OutputMaximum()
{
    Console.WriteLine($"For n = {maxN}, the value of n/φ(n) = {maxRatio} is maximum for n <= {N}");
}

List<int> GetPrimes(int max)
{
    // initialize bool[] [false, false, true, true, true,..., true]
    bool[] isPrime = new bool[max + 1];
    for (int i = 2; i <= max; i++)
    {
        isPrime[i] = true;
    }

    int p = 1;
    while (++p <= Math.Sqrt(max))
    {
        if (!isPrime[p]) continue;

        for (int i = p; p * i <= max; i++)
        {
            isPrime[p * i] = false;
        }
    }

    primes = [];
    for (int i = 0; i <= max; i++)
    {
        if (isPrime[i])
            primes.Add(i);
    }

    isPrimeArray = isPrime;
    return primes;
}
List<int> FindPrimeFactors(int number)
{
    List<int> factors = [];

    foreach (int p in primes)
    {
        int product = 1;
        foreach (int factor in factors)
        {
            product *= factor;
        }

        if (product * p > number)
            break;

        if (number % p == 0)
        {
            factors.Add(p);
        }
    }

    return factors;
}
bool ShareFactors(int bigger, int smaller)
{
    var factorsBigger = primeFactorsOf[bigger];
    var factorsSmaller = primeFactorsOf[smaller];

    foreach (var factor in factorsSmaller)
    {
        for (int i = 0; i < factorsBigger.Count /**&& factor <= factorsBigger[i]**/; i++)
        {
            if (factor == factorsBigger[i])
                return true;
        }
    }

    return false;
}
void GetRelativelyPrime(int n)
{
    List<int> relatives = [];

    bool isPrime = isPrimeArray[n];

    for (int i = 1; i < n; i++)
    {
        if (isPrime || i == 1 || !ShareFactors(n, i))
        {
            relatives.Add(i);
        }
    }

    relativePrimesOf.Add(n, relatives);
}
