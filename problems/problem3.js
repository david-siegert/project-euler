// The following problem is taken from Project Euler. Solution is mine.

// The prime factors of 13195 are 5, 7, 13 and 29.
// What is the largest prime factor of the number 600851475143?

input = 600_851_475_143; // not prime

var factorsArr = [];

Tree(input);

factorsArr.sort((a, b) => a - b);
console.log(factorsArr);
TestResult(input);

// functions
function Tree(number){

    var factor = getFactor(number)

    // console.log(number + " : " + factor);

    if(factor == 1){
        factorsArr.push(number);
        return;
    }
    else{
        var factor2 = number / factor;

        Tree(factor);
        Tree(factor2);
    }

}
function getFactor(number){
    
    if(number == 2) return 1;

    sqrt = Math.ceil(Math.sqrt(number));

    for (let index = sqrt; index > 1; index--) {
        
        if(number % index == 0){
            return index; // not prime
        }
    }

    return 1; // is prime
}
function TestResult(startNumber){
    
    var result = 1;
    factorsArr.forEach(element => {
        result = result * element;
    });

    if(result == startNumber){
        console.log("res: " + result);
        console.log("inp: " + startNumber);
        console.log("OK");
    }else{
        console.log("res: " + result);
        console.log("inp: " + startNumber);
        console.log("NOK");
    }

}