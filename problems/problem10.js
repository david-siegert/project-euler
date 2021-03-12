// The following problem is taken from Project Euler. Solution is mine.

// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
// Find the sum of all the primes below two million.

import factor from './factor.js';


let f = 1; // 1 -> prime
let index = 2;
let sum = 0;

while (index < 2_000_000) {

    f = factor.getFactor(index);

    if (f == 1) {
        sum += index;
    }

    index++;
}

console.log(sum);