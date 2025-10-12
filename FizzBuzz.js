num = 0;
N = console.readLine("Input max: ");
while (num<=N) {
    if (num % 3 == 0 && num % 5 == 0) {
        console.writeLine("FizzBuzz");
    }
    else if (num % 3 == 0) {
        console.writeLIne("Fizz");
    }
    else if (num % 5 == 0) {
        console.writeline("Buzz");
    }
    else {
        console.writeline(num);
    }
    num++;
}
// JavaScript source code
