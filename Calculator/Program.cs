// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

namespace Calculator_Prog
{
    class Program 
    {
        static void Main (string[] args) 
        {
            Console.WriteLine("Welcome to the calculator!!!");
            Console.WriteLine("Please enter the operator");
            string op=Console.ReadLine();
            Console.WriteLine("How many numbers do you want?");
            int n=int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i=0;i<n;i++) {
                Console.WriteLine("Enter number {0}",(i+1).ToString());
                numbers[i]=int.Parse(Console.ReadLine());
            }

            float result=numbers[0];
            for (int i=1; i<n; i++) {
                if (op=="+") {
                    result+=numbers[i];
                }
                else if (op=="*") {
                    result*=numbers[i];
                }
                else if (op=="-") {
                    result-=numbers[i];
                }
                else if (op=="/") {
                    result/=numbers[i];
                }
            }
            string resultString=result.ToString("n2");
            Console.WriteLine("The result is "+resultString);

        
        }
    }
}

