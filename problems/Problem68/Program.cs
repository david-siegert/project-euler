// Initialize variables
using System.Numerics;

int N = 5; // N-Gon 
int n = 2 * N; // Used numbers in N-Gon 1, 2, .., n
// maximum total = (sum (1 + ... + n) + (1 + ... + N)) / N
int Tmax = (7 * N + 3) / 2;
// minimum total = sum (1 + ... + n) + ((N+1) + (N+2) +... + n) / N
int Tmin = (10 * N + 6) / 4;
// Helper dictionary calculated once
Dictionary<int, List<(int s1, int s2)>> Summands = [];
// The list of solutions sets, set is a List<(int, int, int)>
List<List<(int a, int b, int c)>> SolutionSets = [];
HashSet<(int, int, int)> solutionTripplesForT = [];

WrapInStopwatch(() =>
{
    Summands = FindPossibleSummands();

    for (int t = Tmin; t <= Tmax; t++)
    {
        solutionTripplesForT = [];
        for (int i = 1; i <= n; i++)
            FindSetsByTotalAndStartNumber(t, i);

    }

});

OutputNGon();
OutputTotals();
OutputPossibleSummands();
OutputSolutionSets();
OutputOrderedStrings();




// timer
void WrapInStopwatch(Action action)
{
    var stopwatch = System.Diagnostics.Stopwatch.StartNew();
    action();
    stopwatch.Stop();
    Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
}
// output
void OutputNGon()
{
    Console.WriteLine($"{N}-Gon");
}
void OutputTotals()
{
    Console.WriteLine($"Possible totals: {string.Join(", ", Enumerable.Range(Tmin, Tmax - Tmin + 1))}");
}
void OutputPossibleSummands()
{
    foreach (var s in Summands)
    {
        Console.WriteLine($"{s.Key}: {string.Join("; ", s.Value.Select(v => $"({v.s1},{v.s2})"))}");
    }
}
void OutputSolutionSets()
{
    foreach (List<(int a, int b, int c)> solution in SolutionSets)
    {
        var (a, b, c) = solution.First();

        Console.WriteLine($"Total = {a + b + c}: " +
            $"{string.Join(";", solution.Select(v => $"({v.a},{v.b},{v.c})"))}");
    }
}
void OutputOrderedStrings()
{
    List<string> strings = [];
    foreach (List<(int a, int b, int c)> set in SolutionSets)
    {
        string s = string.Empty;
        foreach ((int a, int b, int c) in set)
        {
            s += $"{a}{b}{c}";
        }
        strings.Add(s);
    }

    var ordered = strings.OrderByDescending(a => BigInteger.Parse(a));

    foreach (var s in ordered)
        Console.WriteLine($"Length: {s.Length}, {s}");
}

// logic
Dictionary<int, List<(int b, int c)>> FindPossibleSummands()
{
    // For integers i from (Tmin - n) to (Tmax - 1) find all possible 
    // summand variations of i = a + b for a,b from <1;n> where a != b 

    int min = Tmin - n;
    int max = Tmax - 1;

    Dictionary<int, List<(int b, int c)>> summands = [];


    for (int sum = min; sum <= max; sum++)
    {
        List<(int b, int c)> iSummands = [];

        for (int b = sum - n > 0 ? sum - n : 1; b <= sum / 2; b++)
        {
            int c = sum - b;

            if (b != c)
                iSummands.Add((b, c));

        }

        summands.Add(sum, iSummands);
    }

    return summands;
}
void FindSetsByTotalAndStartNumber(int T, int startNum)
{
    int a = startNum;
    int trippleComplement = T - startNum;
    var complementSummands = Summands[trippleComplement];
    complementSummands = [.. complementSummands.Where(s => s.s1 != a && s.s2 != a)];

    List<(int a, int b, int c)> firstTripples = [.. complementSummands.Select(s => (a, s.s1, s.s2))];
    firstTripples.AddRange(complementSummands.Select(s => (a, s.s2, s.s1)));


    foreach (var tripple in firstTripples)
    {
        List<(int a, int b, int c)> current = [tripple];
        CheckNext(current, T);
    }

}
bool ContainsNumber(List<(int a, int b, int c)> set, int number)
{
    foreach ((int a, int b, int c) in set)
    {
        return a == number || b == number || c == number;
    }

    return false;
}
void CheckNext(List<(int a, int b, int c)> current, int T)
{
    if (current.Count == N)
    {
        if (current.Last().c == current.First().b)
        {
            SolutionSets.Add(current);

            foreach (var tripple in current)
                solutionTripplesForT.Add(tripple);
        }

        return;
    }

    int b = current.Last().c;
    int trippleComplement = T - b;
    var complementSummands = Summands[trippleComplement];
    complementSummands = [.. complementSummands.Where(s => s.s1 != b && s.s2 != b)];

    foreach ((int s1, int s2) in complementSummands)
    {
        // s1, b, s2
        (int a, int b, int c) trippleS1 = (s1, b, s2);
        if (!ContainsNumber(current, s1) && !solutionTripplesForT.Contains(trippleS1))
        {
            CheckNext([.. current, trippleS1], T);
        }

        // s2, b, s1
        (int a, int b, int c) trippleS2 = (s2, b, s1);
        if (!ContainsNumber(current, s2) && !solutionTripplesForT.Contains(trippleS2))
        {
            CheckNext([.. current, trippleS2], T);
        }
    }

}
