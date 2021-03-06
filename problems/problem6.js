// The following problem is taken from Project Euler. Solution is mine.
// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

var sqrOfSum = 5050 * 5050; // 5050 = 101 * 50, sum of arithmetic progression (AP)
var sumOfSqr = 0;

for (let index = 1; index < 101; index++) {

    sumOfSqr = sumOfSqr + index * index;

}

console.log((sqrOfSum - sumOfSqr));