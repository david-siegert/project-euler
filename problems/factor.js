class factor {

    static factorsArr = [];

    static primeFactorsAsc(input) {

        this.factorsArr = [];
        this.Tree(input);
        this.factorsArr.sort((a, b) => a - b);

        return this.TestResult(input) ? this.factorsArr : null;
    }
    static primeFactorsDesc(input) {

        this.factorsArr = [];
        this.Tree(input);
        this.factorsArr.sort((a, b) => b - a);

        return this.TestResult(input) ? this.factorsArr : null;
    }

    static Tree(number) {

        var factor = this.getFactor(number)

        if (factor == 1) {
            this.factorsArr.push(number);
            return;
        }
        else {
            var factor2 = number / factor;

            this.Tree(factor);
            this.Tree(factor2);
        }
    }
    static getFactor(number) {

        if (number < 4) return 1;

        var sqrt = Math.ceil(Math.sqrt(number));

        for (let index = sqrt; index > 1; index--) {

            if (number % index == 0) {
                return index; // not prime
            }
        }

        return 1; // is prime
    }
    static TestResult(startNumber) {

        var result = 1;

        this.factorsArr.forEach(element => {
            result = result * element;
        });

        //console.log(result, startNumber);
        return (result == startNumber);
    }

}
export default factor;
