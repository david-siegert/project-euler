using System.Diagnostics;
RunMeasured(() =>
{
    var triangle = LoadTriangleData();
    //var triangle = TestTriangleData();

    int sum = triangle[0][0];
    int j = 0;
    for (int i = 0; i < triangle.Length - 1; i++)
    {
        int leftTriangleSum = SubTriangleSum(i + 1, j, triangle);
        int rightTriangleSum = SubTriangleSum(i + 1, j + 1, triangle);

        if (leftTriangleSum > rightTriangleSum)
        {
            sum += triangle[i + 1][j];
        }
        else
        {
            sum += triangle[i + 1][j + 1];
            j++;
        }

    }

    return sum;

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
int SubTriangleSum(int rowIndex, int colIndex, int[][] triangle)
{
    int sum = 0;

    for (int i = rowIndex; i < triangle.Length; i++)
    {
        // (i - rowIndex) gives the width of the sub-triangle at row i
        for (int j = colIndex; j <= colIndex + (i - rowIndex); j++)
        {
            sum += triangle[i][j];
        }
    }

    return sum;
}