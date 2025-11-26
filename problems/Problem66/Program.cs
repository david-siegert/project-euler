// generate an array of integers without square numbers

var nonSquareNumbers = GenerateNonSquareNumbers(1000);
//var perfectSquares = GeneratePerfectSquares();

List<(long x, long D)> results = [];
long tmp;

foreach (int D in nonSquareNumbers)
{
    Console.WriteLine($"Processing D={D}");

    for (long x = 1; x <= long.MaxValue; x++)
    {
        tmp = x * x - 1;

        if (tmp < D) continue;
        if ((x * x - 1) % D != 0) continue;

        long y_squared = (x * x - 1) / D;

        if (IsPerfectSquareFast(y_squared))
        {
            results.Add((x, D));
            break;
        }

    }

    File.AppendAllLines("results.txt", new[] { $"D={D}, x={results.Last().x}" });
}

results.Sort((r1, r2) => r1.x.CompareTo(r2.x));
var result = results.Last();
var result_y = GetIntegerSolution(result.D, 1 - result.x * result.x);
bool verify = result.x * result.x - result.D * result_y * result_y == 1;

Console.WriteLine($"D = {result.D}");
Console.WriteLine($"x = {result.x}");
Console.WriteLine($"y = {result_y}");
Console.WriteLine($"x^2 - D*y^2 = 1 => {result.x}^2 - {result.D}*{result_y}^2 = 1 => {verify}");



static long GetIntegerSolution(long a, long c)
{
    // 0 = ax^2 + c 

    long max = long.MaxValue;
    long min = 0;
    long x, f_x;
    double f_x_double;

    while (max - min > 1)
    {
        x = (max + min) / 2;

        f_x_double = a * (double)x * x + c;
        f_x = Math.Sign(f_x_double);

        if (f_x == 0)
        {
            return x;
        }
        else if (f_x > 0)
        {
            max = x;
        }
        else
        {
            min = x;
        }
    }

    return 0;
}
static List<int> GenerateNonSquareNumbers(int upperBound)
{
    var nonSquares = new List<int>();
    int number = 1;
    int nextSquare = 1;
    int squareRoot = 1;

    while (number <= upperBound)
    {
        if (number == nextSquare)
        {
            // Skip perfect squares
            squareRoot++;
            nextSquare = squareRoot * squareRoot;
        }
        else
        {
            nonSquares.Add(number);
        }
        number++;
    }

    return nonSquares;
}
static bool IsPerfectSquare(long n)
{
    if (n < 0) return false;
    if (n < 2) return true;

    // Use Newton's method for initial estimate
    long x = n;
    long y = (x + 1) / 2;

    while (y < x)
    {
        x = y;
        y = (x + n / x) / 2;
    }

    return x * x == n;
}
static bool IsPerfectSquareFast(long n)
{
    if (n < 0) return false;
    if (n < 2) return true;

    // Quick bit pattern check
    if ((n & 2) != 0) return false; // Numbers ending in binary 10 or 11 can't be squares
    if ((n & 7) == 5) return false; // Numbers ≡ 5 (mod 8) can't be squares
    if ((n & 11) == 8) return false; // Numbers ≡ 8 (mod 12) can't be squares

    long sqrt = (long)Math.Sqrt(n);
    return sqrt * sqrt == n;
}
static bool IsPerfectSquareFasterThanFast(long n)
{
    if (n < 0) return false;
    if (n < 2) return true;

    // Quick rejection: perfect squares can only end in 0,1,4,5,6,9 in base 16
    int lastHex = (int)(n & 0xF);
    if (lastHex > 9) return false;
    if (lastHex == 2 || lastHex == 3 || lastHex == 7 || lastHex == 8) return false;

    // Quick rejection: check modulo small primes
    if ((n % 3) == 2) return false;
    if ((n % 7) == 3 || (n % 7) == 5 || (n % 7) == 6) return false;
    if ((n % 11) == 2 || (n % 11) == 6 || (n % 11) == 7 || (n % 11) == 8 || (n % 11) == 10) return false;

    // Use integer square root
    long sqrt = (long)Math.Sqrt(n);

    // Check sqrt and sqrt+1 to handle floating point precision issues
    return sqrt * sqrt == n || (sqrt + 1) * (sqrt + 1) == n;
}
static bool IsPerfectSquareNewton(long n)
{
    if (n < 0) return false;
    if (n < 2) return true;

    // Start with a better initial guess
    long x = n;
    long y = (x + 1) >> 1; // Use bit shift for division by 2

    while (y < x)
    {
        x = y;
        y = (x + n / x) >> 1;
    }

    return x * x == n;
}