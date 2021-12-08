console.log('Welcome to '+'\n'+'the calculator!');
const readline=require ('readline-sync');
console.log('Please enter 2 numbers');
const response1 = readline.prompt();
x=+response1;
const response2 = readline.prompt();
y=+response2;
console.log('Choose the operation + - * /');
const op = readline.prompt();
var result;
switch (op) {
    case '+':
        result=x+y;
        break;
    case '-':
        result=x-y;
        break;
    case '*':
        result=x*y;
        break;
    case '/':
        result=x/y;
        break;
}
if (result===undefined)
    console.log('Wrong operation!');
else
    console.log('result is '+result);