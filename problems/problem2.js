// The following problem is taken from Project Euler. Solution is mine.

// Each new term in the Fibonacci sequence is generated by adding the previous two terms. 
// By starting with 1 and 2, the first 10 terms will be:
// 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...

// By considering the terms in the Fibonacci sequence whose values do not exceed four million, 
// find the sum of the even-valued terms.

firstTerm = 1;
secondTerm = 2;
variable = 0;

resultSum = 0;

while(secondTerm < 4_000_000){
    
    // in first iteration  we are checking number 2
    if(isEven(secondTerm)){
        resultSum += secondTerm;
    }
    
    variable = firstTerm;
    firstTerm = secondTerm;
    secondTerm = variable + secondTerm;
}

console.log(resultSum);

    


function isEven(number){

    numString = number.toString();

    if(numString.length > 0){

        lastDigit = numString[numString.length - 1];

        if( lastDigit == "0" || 
            lastDigit == "2" || 
            lastDigit == "4" || 
            lastDigit == "6" ||
            lastDigit == "8"){
            return true
        } 
    }
}