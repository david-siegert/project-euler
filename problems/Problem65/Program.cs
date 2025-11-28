
using System.Diagnostics;
using System.Numerics;

Stopwatch stopwatch = Stopwatch.StartNew();

var b = GenerateEulerNumberContinuedFraction().Take(100).ToList();

int N = 100;

BigInteger A_prev_prev = 1;
BigInteger A_prev = b[0];
BigInteger B_prev_prev = 0;
BigInteger B_prev = 1;

for (int n = 1; n < N; n++)
{
    int b_n = b[n];

    BigInteger A_n = b_n * A_prev + A_prev_prev;
    BigInteger B_n = b_n * B_prev + B_prev_prev;

    A_prev_prev = A_prev;
    A_prev = A_n;
    B_prev_prev = B_prev;
    B_prev = B_n;
}

Console.WriteLine($"{N}th:");
Console.WriteLine($"Numerator: {A_prev}");
Console.WriteLine($"Denominator: {B_prev}");

Console.WriteLine($"Sum of digits in numerator: {A_prev.ToString().ToCharArray().Select(c => c - '0').Sum()}");

stopwatch.Stop();
Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");



IEnumerable<int> GenerateEulerNumberContinuedFraction()
{
    // This method generates the continued fraction sequence for Euler's number (e).
    // The sequence is defined as: [2; 1,2n,1] for n = 1, 2, 3, ...

    int n = 1;
    yield return 2; // The first term of the continued fraction for e

    while (true)
    {
        yield return 1;       // First term in the pattern
        yield return 2 * n;   // Middle term in the pattern
        yield return 1;       // Last term in the pattern
        n++;
    }
}