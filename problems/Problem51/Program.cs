// Prime Digit Replacements
// Problem 51

using System.Runtime.CompilerServices;
using ProjectEuler.PrimeNumbers;

var primes = PrimeUtils.GetPrimesUpTo(1_000_000);
bool[] isPrime = PrimeUtils.GetIsPrimeArray(1_000_000);

DateTime startTime = DateTime.Now;

foreach (var prime in primes)
{
    if (prime < 56003)
        continue;

    string primeStr = prime.ToString();
    int length = primeStr.Length;

    for (int digitCount = 1; digitCount < length; digitCount++)
    {
        // Generate all combinations of positions to replace
        var combinations = GeneratePositionCombinations(length, 1, digitCount);

        foreach (var positions in combinations)
        {
            int familySize = GetPrimeFamilySize(prime, positions);

            if (familySize >= 8) // Problem 51 asks for family of 8 primes
            {
                Console.WriteLine($"Found family of {familySize} primes starting with {prime}");
                Console.WriteLine($"Positions to replace: [{string.Join(", ", positions)}]");

                Console.WriteLine(string.Join(", ", GetPrimeFamily(prime, positions)));

                // You can break here if you only need the first solution
                return;
            }
        }
    }
}

Console.WriteLine($"{(DateTime.Now - startTime).TotalMilliseconds} ms");

List<int> GetPrimeFamily(int prime, int[] positions)
{
    string primeStr = prime.ToString();
    char[] primeChars = primeStr.ToCharArray();
    List<int> family = [];

    for (char replacementDigit = '0'; replacementDigit <= '9'; replacementDigit++)
    {
        foreach (var pos in positions)
        {
            primeChars[pos] = replacementDigit;
        }

        int newNumber = int.Parse(new string(primeChars));
        if (isPrime[newNumber])
        {
            family.Add(newNumber);
        }
    }

    return family;
}
int GetPrimeFamilySize(int prime, int[] positions)
{
    string primeStr = prime.ToString();
    char[] primeChars = primeStr.ToCharArray();
    int familyCount = 0;

    for (char replacementDigit = '0'; replacementDigit <= '9'; replacementDigit++)
    {
        foreach (var pos in positions)
        {
            primeChars[pos] = replacementDigit;
        }

        // Skip numbers with leading zero
        if (primeChars[0] == '0')
            continue;

        int newNumber = int.Parse(new string(primeChars));
        if (isPrime[newNumber])
        {
            familyCount++;
        }
    }

    return familyCount;
}
static IEnumerable<int[]> GeneratePositionCombinations(int length, int minSize, int maxSize)
{
    for (int size = minSize; size <= maxSize; size++)
    {
        foreach (var combination in GenerateCombinations(length, size, 0, []))
        {
            yield return combination;
        }
    }
}
static IEnumerable<int[]> GenerateCombinations(int count, int size, int start, int[] current)
{
    if (current.Length == size)
    {
        yield return current;
        yield break;
    }

    for (int i = start; i < count; i++)
    {
        foreach (var combination in GenerateCombinations(count, size, i + 1, [.. current, i]))
        {
            yield return combination;
        }
    }
}
