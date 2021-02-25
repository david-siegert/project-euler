// Multiples of 3 and 5
// If we list all the natural numbers below 10 that are multiples 
// of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
// Find the sum of all the multiples of 3 or 5 below 1000.

sum = 0;

for (index = 1; index < 1000; index++) {
    
    if(isDivisibleByFive(index) || isDivisibleByThree(index)){
        sum += index;
    }
}

console.log(sum);


function isDivisibleByThree(num) {
    
    // true for 0 but we care only about integers

    numString = num.toString();

    sum = 0;
    
    if(numString.length > 0){

        for (let index = 0; index < numString.length; index++) {
            const element = numString[index];
            sum += parseInt(element);
        }
    }

    return sum % 3 == 0;
}
function isDivisibleByFive(num) {
    
    // true for 0 but we care only about integers

    numString = num.toString();

    if(numString.length > 0){

        lastDigit = numString[numString.length - 1];

        if(lastDigit == "0" || lastDigit == "5"){
            return true
        } 
    }

    return false;
}