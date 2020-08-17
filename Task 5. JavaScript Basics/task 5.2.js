'use strict';

let testString = "3.5 землекопа +4*10-5.3 /5 =";

let regex = /[^\-\+\/\*\.\d=]/ig;

testString = testString.replace(regex, '');
//console.log(testString);

let regexNumbers = /\s*[\-\+\/\*=]\s*/;
let numbers = testString.split(regexNumbers).filter(Boolean);
//console.log(numbers);


let regexOperators = /[\d\.\s]+/
let operators = testString.split(regexOperators).filter(Boolean);
//console.log(operators);	

let result = parseFloat(numbers[0]);

for (let i = 0; i <= operators.length; i++) {
    switch (operators[i]) {
        case '+':
            result += parseFloat(numbers[i + 1]);
            break;
        case '-':
            result -= parseFloat(numbers[i + 1]);
            break;
        case '*':
            result *= parseFloat(numbers[i + 1]);
            break;
        case '/':
            result /= parseFloat(numbers[i + 1]);
            break;
        case '=':
            result = result.toFixed(3);
            console.log(result);
            break;
    }
}