//example answer https://github.com/techswitch-learners/calculator-js/blob/FunctionsAndWhileLoops/index.js

function printWelcomeMessage(){
    console.log('Welcome to '+'\n'+'the calculator!');
}
function enterElementsToArr(n) {
    let arr=[];
    let x;
    for (i=0;i<n;i++) {
        do {
            console.log('Please enter number '+i);
            x = +readline.prompt();
        } while (isNaN(x));
        arr.push(x);
    }
    return arr;
}
function calculationInself(op,arr) {
    var result;
    switch (op) {
        case '+':
            result=arr.reduce (function(acc,currVal) {return acc+currVal},0);
            break;
        case '-':
            result=arr.slice(1,arr.length).reduce (function(acc,currVal) {return acc-currVal},arr[0]);
            break;
        case '*':
            result=arr.reduce (function(acc,currVal) {return acc*currVal},1);
            break;
        case '/':
            result=arr.slice(1,arr.length).reduce (function(acc,currVal) {return acc/currVal},arr[0]);
            break;
    }
    return result;
}
function performOneCalculation (){
    console.log('How many numbers do you want to ?');
    const count = +readline.prompt();
    arr=enterElementsToArr(count);
    console.log('Choose the operation + - * /');
    const op = readline.prompt();
    result=calculationInself(op,arr);
    if (result===undefined)
        console.log('Wrong operation!');
    else
        console.log(`result of the operation ${op} is ${result}`);
}

const readline=require ('readline-sync');
printWelcomeMessage();
while (true) 
    performOneCalculation ();