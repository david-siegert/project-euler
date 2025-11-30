using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Intrinsics.Arm;
RunMeasured(() =>
{
    int[][] a = LoadTriangleData();
    //int[][] a = TestTriangleData();

    int[][] dp = new int[a.Length][];

    // Initialize bottom row
    int last = a.Length - 1;
    dp[last] = new int[a.Length];
    for (int j = 0; j < a.Length; j++)
    {
        dp[last][j] = a[last][j];
    }

    // Fill dp table from bottom to top
    for (int i = last - 1; i >= 0; i--)
    {
        dp[i] = new int[i + 1];
        for (int j = 0; j <= i; j++)
        {
            dp[i][j] = a[i][j] + Math.Max(dp[i + 1][j], dp[i + 1][j + 1]);
        }
    }

    return dp[0][0];
});



void RunMeasured(Func<int> action)
{
    Console.WriteLine("I am witness!");
    Stopwatch stopwatch = Stopwatch.StartNew();

    int result = action();

    stopwatch.Stop();
    Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
    Console.WriteLine($"result = {result}");
}

int[][] LoadTriangleData()
{
    var lines = File.ReadAllLines("triangle.txt");

    int[][] triangle = new int[lines.Length][];
    for (int i = 0; i < lines.Length; i++)
    {
        var numbers = lines[i].Split(' ').Select(int.Parse).ToArray();
        triangle[i] = numbers;
    }

    return triangle;
}
int[][] TestTriangleData()
{
    return
    [
        [3],
        [7, 4],
        [2, 4, 6],
        [8, 5, 9, 3]
    ];
}