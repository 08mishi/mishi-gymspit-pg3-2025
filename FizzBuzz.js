num = 1;
N = console.ReadLine("Input max: ");
while (num<=N) {
    if (num % 3 == 0 && num % 5 == 0) {
        console.WriteLine("FizzBuzz");
    }
    else if (num % 3 == 0) {
        console.WriteLine("Fizz");
    }
    else if (num % 5 == 0) {
        console.WriteLine("Buzz");
    }
    else {
        console.WriteLine(num);
    }
    num++;
}
// JavaScript source code
