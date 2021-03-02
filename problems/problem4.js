// The following problem is taken from Project Euler. Solution is mine.

// A palindromic number reads the same both ways. 
// The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
// Find the largest palindrome made from the product of two 3-digit numbers.

var palindromArray = GetCandidatePalindroms();

var sqrt = 0;

for (let index = 0; index < Object.keys(palindromArray).length; index++) {

    const number = palindromArray[index];

    sqrt = Math.ceil((Math.sqrt(number)));

    for (let factor = sqrt; factor > 99; factor--) {
        
        if(number % factor == 0){

            if(number / factor < 1000){
                console.log(number + " = " + (number / factor) + " * " + factor); 
                return;
            }
        }
    }
}

function GetCandidatePalindroms(){

    var palindroms = new Array();
    var numString = "";

    // 10 -> 99 && 0 -> 9
    for (let index = 10; index < 100; index++) {
        
        numString = index.toString();

        var temp = "";
        for (let index2 = 0; index2 < 10; index2++) {
            temp = numString + index2.toString() + numString[1] + numString[0];
            palindroms.push(parseInt(temp));
        }
    }
    // 100 -> 999
    for (let index3 = 100; index3 < 1000; index3++) {
        numString = index3.toString();
        numString = numString + numString[2] + numString[1] + numString[0];
        palindroms.push(parseInt(numString));
    }

    return palindroms.sort((a, b) => b - a);
}