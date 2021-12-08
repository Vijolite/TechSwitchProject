// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

namespace Calculator_Prog
{
    class Program 
    {
        static void Main (string[] args) 
        {
            Welcome(); 
            while (true) {
                PerformOneCalculation();
            }
        }

        private static void Welcome() {
            Console.WriteLine("Welcome to the calculator!!!");
        }

        private static void PerformOneCalculation() {
            string op=EnterOperator();
            int n=EnterTotal();
            int[] numbers = EnterNumbers(n);
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
            PrintResult(result);
        }
        private static string EnterOperator() {
            string op;
            do {
                Console.WriteLine("Please enter the operator");
                op=Console.ReadLine();
            } while ((op!="+") && (op!="-") && (op!="*") &&(op!="/") );
            return op;
        }
        private static int EnterTotal() {
            Console.WriteLine("How many numbers do you want?");
            int n=EnterOneNumber ();
            return n;
        }
        private static int[] EnterNumbers(int n) {
            int[] numbers = new int[n];
            for (int i=0;i<n;i++) {
                Console.WriteLine("Enter number {0}",(i+1).ToString());
                numbers[i]=EnterOneNumber ();
            }
            return numbers;
        }

        private static int EnterOneNumber () {
            int n;
            string s;
            do {
                s=Console.ReadLine();
                if (!(int.TryParse(s, out n))) {
                    Console.WriteLine("Enter a NUMBER!!!");
                }
            } while (!(int.TryParse(s, out n))); 
            return n;

        }
        private static void PrintResult(float result) {
            string resultString=result.ToString("n2");
            Console.WriteLine("The result is "+resultString);
        }

    }
}

