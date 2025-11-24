// 14 Longest Collatz Sequence for n < 1,000,000
using System;

int limit = 1000000;
int maxLength = 0;
int startingNumber = 1;

for (int i = 1; i <= limit; i++)
{
    int length = CollatzSequenceLength(i);
    if (length > maxLength)
    {
        maxLength = length;
        startingNumber = i;
    }
}

Console.WriteLine($"n = {startingNumber}");
Console.WriteLine($"length = {maxLength}");

static int CollatzSequenceLength(long n)
{
    long original = n;
    int length = 1;
    while (n != 1)
    {
        if (n % 2 == 0)
        {
            n /= 2;
        }
        else
        {
            n = 3 * n + 1;
        }
        length++;
    }
    return length;
}
