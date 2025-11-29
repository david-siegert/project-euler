using System.Diagnostics;
using System.Numerics;


Stopwatch stopwatch = new();
stopwatch.Start();

int dWithLargestX = 0;
BigInteger largestX = 0;
BigInteger correspondingY = 0;

for (int d = 2; d <= 1000; d++)
{
    if (IsPerfectSquare(d))
        continue;

    // sqrt(d) = [b_0; (period)]

    CalculateContinuedFractionSqrtOf(d, out int b_0, out List<int> period);

    // Console.WriteLine($"D = {d}");
    // Console.WriteLine($"[{b_0}, ({(period.Count > 10 ? string.Join(", ", period.Take(10)) : string.Join(", ", period))}{(period.Count > 10 ? ", ..." : "")})]");

    int N;
    if (period.Count % 2 == 0)
        N = period.Count - 1;  // For even period calculate convergents until period - 1
    else
    {
        N = 2 * period.Count - 1; // For odd period calculate convergents until 2 * period - 1
        period.AddRange(period); // Duplicate the period for odd case
    }

    BigInteger A_prev_prev = 1;
    BigInteger A_prev = b_0;
    BigInteger B_prev_prev = 0;
    BigInteger B_prev = 1;

    for (int n = 0; n < N; n++)
    {
        int b_n = period[n];

        BigInteger A_n = b_n * A_prev + A_prev_prev;
        BigInteger B_n = b_n * B_prev + B_prev_prev;

        A_prev_prev = A_prev;
        A_prev = A_n;
        B_prev_prev = B_prev;
        B_prev = B_n;
    }

    if (A_prev > largestX)
    {
        largestX = A_prev;
        correspondingY = B_prev;
        dWithLargestX = d;
    }

}

stopwatch.Stop();
Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
Console.WriteLine($"D with largest x in minimal solution: {dWithLargestX}");
Console.WriteLine($"Numerator: {largestX}");
Console.WriteLine($"Denominator: {correspondingY}");

// check if Pell's equation is satisfied
BigInteger leftSide = largestX * largestX - BigInteger.Multiply(dWithLargestX, correspondingY * correspondingY);
Console.WriteLine($"Check Pell's equation: {largestX}^2 - {dWithLargestX}*{correspondingY}^2 = {leftSide}");

void CalculateContinuedFractionSqrtOf(int d, out int a_0, out List<int> period)
{
    double sqrt_d = Math.Sqrt(d);

    period = [];
    List<(int p, int q)> seen = [];

    int p = 0;
    int q = 1;
    double x = X(p, q, sqrt_d);
    int a = A(x);

    a_0 = a;

    while (true)
    {
        int a_prev = a;
        int q_prev = q;
        int p_prev = p;

        p = P(a_prev, q_prev, p_prev);
        q = Q(d, p, q_prev);

        // Check for cycle before calculating next iteration
        if (seen.Contains((p, q)))
            break;

        seen.Add((p, q));

        x = X(p, q, sqrt_d);
        a = A(x);
        period.Add(a);
    }
}
int P(int a_prev, int q_prev, int p_prev)
{
    return a_prev * q_prev - p_prev;
}
int Q(int d, int p, int q_prev)
{
    return (d - p * p) / q_prev;
}
double X(int p, int q, double sqrt_d)
{
    return (p + sqrt_d) / q;
}
int A(double x)
{
    return (int)Math.Floor(x);
}
bool IsPerfectSquare(int n)
{
    if (n < 0) return false;
    if (n == 0 || n == 1) return true;

    // Get the integer square root, but account for floating-point precision issues
    double sqrt_double = Math.Sqrt(n);
    int sqrt_floor = (int)sqrt_double;
    int sqrt_ceil = sqrt_floor + 1;

    // Check both floor and ceiling, but ensure the square exactly equals n
    return (sqrt_floor * sqrt_floor == n) || (sqrt_ceil * sqrt_ceil == n);
}
