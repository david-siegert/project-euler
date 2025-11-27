using System.Diagnostics;
Stopwatch stopwatch = new();
stopwatch.Start();

int numOfOddPeriods = 0;

for (int d = 2; d <= 10_000; d++)
{
    if (IsPerfectSquare(d))
        continue;

    CalculateContinuedFraction(d, out int a_0, out List<int> period);
    Console.WriteLine($"[{a_0}, ({string.Join(", ", period)})]");

    if (period.Count % 2 == 1)
        numOfOddPeriods++;

}

stopwatch.Stop();
Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
Console.WriteLine($"Number of odd periods: {numOfOddPeriods}");

void CalculateContinuedFraction(int d, out int a_0, out List<int> period)
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
