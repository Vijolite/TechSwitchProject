//example answer https://github.com/techswitch-learners/calculator-js/blob/FunctionsAndWhileLoops/index.js

function printWelcomeMessage(){
    console.log('Welcome to '+'\n'+'the calculator!');
}
function getCalculationMode() {
    do {
        console.log(`Which calculators do you want
        1) Arithmetic
        2) Vowel counting`);
        c=readline.prompt();
    } while (c!=1 && c!=2);
    return c;
}
function getString() {
    console.log(`Enter a string`);
    c=readline.prompt();
    return c;
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
function performOneVowelCounting () {
    vowel_arr=['a','e','u','o','i'];
    const obj = {
        s:'', 
        vowels: {
        a:0, e:0, u:0, o:0, i:0
        },
        counter : function () {
            for (let i=0; i<this.s.length; i++) {
                if (vowel_arr.includes(this.s[i].toLowerCase())) {
                    this.vowels[this.s[i].toLowerCase()]+=1;
                }
            }
        },
        print : function () {
            for (let i in this.vowels) {
                console.log(`${i.toUpperCase()} : ${this.vowels[i]}`);
            }
        }
    };
    obj.s=getString();
    console.log(obj.s);
    obj.counter();
    obj.print();
}

const readline=require ('readline-sync');
const ARIT_MODE='1';
const VOWEL_MODE='2';
printWelcomeMessage();
while (true) {
    const mode=getCalculationMode();
    if (mode===ARIT_MODE)
        performOneCalculation ();
    else if (mode===VOWEL_MODE)
        performOneVowelCounting ();
}