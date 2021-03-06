// The following problem is taken from Project Euler. Solution is mine.

// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
// What is the 10 001st prime number?

import factor from './factor.js';

var primes = [2, 3, 5, 7, 11];
var index = 11;
var f = 1;

while (primes.length < 10_001) {
    
    index++;

    f = factor.getFactor(index);

    if(f == 1) primes.push(index) 

}

console.log(primes[primes.length - 1]);