using System.Diagnostics;
Stopwatch sw = Stopwatch.StartNew();

int[] factorial = [1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880];


int count = 0;

Dictionary<int, int> distanceToRepeat = new();
List<int> chain = [];
bool startNumSolved = false;
for (int start = 1; start < 1000_000; start++)
{
    chain.Clear();
    int current = start;
    int indexOfCurrent = -1;

    while (indexOfCurrent == -1)
    {
        // shortcut
        if (distanceToRepeat.TryGetValue(current, out int dist))
        {
            for (int c = 0; c < chain.Count; c++)
            {
                distanceToRepeat.Add(chain[c], (chain.Count - c) + dist);
            }

            startNumSolved = true;
            break;
        }

        if (chain.Count > 60) // max chain length is 60, so no need to continue
        {
            startNumSolved = true;
            break;
        }

        chain.Add(current);
        current = Next(current);
        indexOfCurrent = chain.IndexOf(current);
    }

    if (startNumSolved) continue;

    // save new loop distances
    int loopLenght = chain.Count - indexOfCurrent;
    for (int c = 0; c < chain.Count; c++)
    {
        if (c >= indexOfCurrent)
        {
            distanceToRepeat.Add(chain[c], loopLenght); // constant for each member of the loop
        }
        else
        {
            distanceToRepeat.Add(chain[c], chain.Count - c);
        }

    }

}


count = distanceToRepeat.Count(m => m.Value == 60);

sw.Stop();
Console.WriteLine($"{(count == 402 ? "Correct" : "Incorrect")} result: {count} in {sw.ElapsedMilliseconds} ms");


int Next(int n)
{
    int next = 0;

    n.ToString().Select(ch => ch - '0').ToList().ForEach(digit => next += factorial[digit]);

    return next;
}
