namespace ProjectEuler.PrimeNumbers;

/// <summary>
/// Provides utility methods for working with prime numbers, including primality testing,
/// prime generation, and the Sieve of Eratosthenes algorithm.
/// </summary>
public class PrimeUtils
{
    /// <summary>
    /// Determines whether the specified number is prime using an optimized algorithm
    /// based on the fact that all primes greater than 3 can be written as 6k ± 1.
    /// </summary>
    /// <param name="number">The number to test for primality.</param>
    /// <returns>true if the number is prime; otherwise, false.</returns>
    public static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number <= 3) return true;
        if (number % 2 == 0 || number % 3 == 0) return false;

        for (int i = 5; i * i <= number; i += 6)
        {
            if (number % i == 0 || number % (i + 2) == 0)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Finds the next prime number greater than the specified number.
    /// </summary>
    /// <param name="number">The number after which to find the next prime.</param>
    /// <returns>The smallest prime number greater than the specified number.</returns>
    public static int GetNextPrime(int number)
    {
        int candidate = number + 1;
        while (!IsPrime(candidate))
        {
            candidate++;
        }
        return candidate;
    }

    /// <summary>
    /// Generates a sequence of all prime numbers up to the specified limit using lazy evaluation.
    /// </summary>
    /// <param name="limit">The upper bound (inclusive) for prime generation.</param>
    /// <returns>An enumerable sequence of prime numbers from 2 to the specified limit.</returns>
    public static IEnumerable<int> GetPrimesUpTo(int limit)
    {
        for (int i = 2; i <= limit; i++)
        {
            if (IsPrime(i))
                yield return i;
        }
    }

    /// <summary>
    /// Generates a list of all prime numbers up to the specified limit using the Sieve of Eratosthenes algorithm.
    /// This method is more efficient than individual primality testing for finding all primes in a range.
    /// </summary>
    /// <param name="limit">The upper bound (inclusive) for prime generation.</param>
    /// <returns>A list containing all prime numbers from 2 to the specified limit.</returns>
    public static List<int> SieveOfEratosthenes(int limit)
    {
        bool[] isPrime = new bool[limit + 1];
        Array.Fill(isPrime, true);
        isPrime[0] = isPrime[1] = false;

        for (int i = 2; i * i <= limit; i++)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j <= limit; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        List<int> primes = new List<int>();
        for (int i = 2; i <= limit; i++)
        {
            if (isPrime[i])
                primes.Add(i);
        }
        return primes;
    }

    /// <summary>
    /// Creates a boolean array indicating the primality of each number up to the specified limit
    /// using the Sieve of Eratosthenes algorithm.
    /// </summary>
    /// <param name="limit">The upper bound for the array size.</param>
    /// <returns>A boolean array where isPrime[i] is true if i is prime, false otherwise. Indices 0 and 1 are false.</returns>
    public static bool[] GetIsPrimeArray(int limit)
    {
        bool[] isPrime = new bool[limit + 1];
        Array.Fill(isPrime, true);
        isPrime[0] = isPrime[1] = false;

        for (int i = 2; i * i <= limit; i++)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j <= limit; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        return isPrime;
    }

}