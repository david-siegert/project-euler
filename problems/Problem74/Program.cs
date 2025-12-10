using System.Diagnostics;

Stopwatch sw = Stopwatch.StartNew();

int[] factorial = [1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880];


int count = 0;
for (int start = 1; start < 1000_000; start++)
{
    HashSet<int> seen = [];
    int current = start;

    while (!seen.Contains(current))
    {
        seen.Add(current);
        current = Next(current);
    }

    if (seen.Count == 60) count++;
}

sw.Stop();
Console.WriteLine($"Result: {count} in {sw.ElapsedMilliseconds} ms");


int Next(int n)
{
    int next = 0;

    n.ToString().Select(ch => ch - '0').ToList().ForEach(digit => next += factorial[digit]);

    return next;
}
