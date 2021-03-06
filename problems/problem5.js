// The following problem is taken from Project Euler. Solution is mine.

// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

// Algo:
// 1,
// 2,
// 3,
// 4 = 2 * 2 -> 2 (one 2 is already present)
// 5
// 6 = 2 * 3 -> both present
// 7
// ... 

import factor from './factor.js';

var result = [];

for (let index = 1; index < 21; index++) {

    var factors = factor.primeFactorsAsc(index);

    let i = 0;
    
    while (i < Object.keys(factors).length) {
        const factor = factors[i];

        var increment = Contains(factors, factor);

        i += increment; // increment is always atleast 1

        // how many times I already have this factor in result
        var currentCount = Contains(result, factor);        

        for (let j = 0; j < increment - currentCount; j++) {
            result.push(factor);            
        }
    }
}

console.log(result);

// multiply factors in result array to get the smallest number we are looking for
var smallestNumber = 1;
result.forEach(element => {
    smallestNumber = smallestNumber * element;
});

console.log(smallestNumber);


function Contains(array, number) {

    var count = 0;

    array.forEach(element => {

        if (element === number) {
            count++;
        }
    });

    return count;
}