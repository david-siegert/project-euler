# What is project-euler?

![Latest Problem](https://img.shields.io/badge/Latest%20Solved-Problem%2066-brightgreen?style=for-the-badge&logo=mathworks)
![Total Solved](https://img.shields.io/badge/Total%20Solved-15+-blue?style=for-the-badge&logo=checkmarx)
![Language](https://img.shields.io/badge/Language-C%23%20%7C%20JavaScript-purple?style=for-the-badge&logo=dotnet)
![Difficulty](https://img.shields.io/badge/Difficulty-25%25-orange?style=for-the-badge&logo=target)

https://projecteuler.net/

Repository tracking my solutions to the Project Euler problems.

-   Later problems: `C#`
-   Early problems (1 - 12): newbie `JavaScript`

# Motivation

At first I used JavaScript because I wanted to learn the language, thinking these would be easy problems and a good opportunity to **learn a language**. While that's certainly possible, it made it unnecessarily harder than just focusing on the algorithms while using a language I'm most comfortable with.

Another motivation was to go through some algorithmic exercises and learn more about **algorithms and data structures**.

The newest goal was to learn C# programming without Visual Studio using **VS Code** and **dotnet CLI**, and also start solving harder problems and **practice math**.

# AI tools, LLMs

At this point AI tools are able to solve the problems in seconds giving right answers, which leads me to question whether the skills I am learning through these exercises are actually valuable when these tools are now superior and faster at logical reasoning than I can ever hope to be.

Arguments to continue:

-   You need to understand it to verify it - but do you? nowadays it is faster to test if it works
-   It is fun - well only if your idea of fun aren't only happy emotions :D
-   Building intuition for mathematical concepts
-   The journey of discovery matters

In the end I am making use of the AI tools, it would be stupid not to. But I am also very careful about what I have it do for me so that I fully understand the problem and am able to solve it myself. I am now using it as a smart friend to help me learn and also as a fast generator of what I already know and can quickly verify that I understand what and how it's doing it and that it is what I want. In order to not miss out on any learning.

# What I learned

### Math and algorithms

-   **Number theory basics**: prime factorization, GCD, LCM, modular arithmetic
-   **Data type limitations**: int, long, double won't cut it every time - especially in edge cases dealing with large numbers - but C# BigInteger is very helpful
-   **Algorithm optimization**: brute-forcing is never a good algorithm, and with clever algorithms you can bring exponential time down to milliseconds
-   **Sieve of Eratosthenes**: efficient prime number generation
-   **Newton's method**: fast square root approximation and optimization techniques
-   **Performance vs. readability**: sometimes(most of the time) Math.Sqrt() beats custom optimizations
-   **Continued fractions**: representing square roots and finding convergents
-   **Pell's equation**: finding integer solutions to x² - Dy² = 1
-   **Collatz conjecture**: understanding iterative sequences
-   **Combinatorics**: permutations, combinations, and counting problems

### Technology

-   **VS Code**
-   **GitHub Copilot**
-   **dotnet CLI**: command-line interface for .NET projects
-   **Git Bash (mingw64)**: is awesome - I prefer it to cmd and PowerShell on Windows

# Solved Problems

![Latest Solved](https://img.shields.io/badge/Latest%20Solved-Problem%2066-success?style=flat-square&logo=checkmarx)
![Progress](https://img.shields.io/badge/Progress-15%2B%20Problems-blue?style=flat-square&logo=trending-up)

**Latest solved: 66** 🎯

### Problem Categories Completed:

-   **1-12** 🟢 Prime numbers & Basic algorithms
-   **13** 🟢 Large sum computation
-   **14** 🟢 Collatz conjecture
-   **51** 🟢 Prime digit replacements
-   **64, 65, 66** 🟢 Continued fractions of square roots and convergents

### Problem 66

At first I tried it naively and found it won't work - had to go back to 64 and 65 to learn concepts necessary for solving the problem. ChatGPT solved it in 10 seconds... But I learned a lot.
