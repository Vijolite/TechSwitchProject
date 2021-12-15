
namespace Calculator_Prog
{
    class Program 
    {
        private const int NumberCalculator = 1;
        private const int DateCalculator = 2;
        static void Main (string[] args) 
        {
            Welcome(); 
            while (true) {
                int calculationMode = AskForCalculationMode();
                if (calculationMode==NumberCalculator)
                    PerformOneNumberCalculation();
                else
                    PerformOneDateCalculation();
            }
        }

        private static void Welcome() {
            Console.WriteLine("Welcome to the calculator!!!");
        }

        private static int AskForCalculationMode() {
            string op;
            do {
                Console.WriteLine("Witch calculator do you want? \n 1) Numbers \n 2) Dates ");
                op=Console.ReadLine();
            } while ((op!="1") && (op!="2"));
            return int.Parse(op);
        }

        private static void PerformOneNumberCalculation() {
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

        private static void PerformOneDateCalculation() {
            DateTime dt=EnterOneDate();
            Console.WriteLine("Please enter the number of days to add:");
            int n=EnterOneNumber ();
            Console.WriteLine("The answer is : {0}",dt.AddDays(n).ToLongDateString());
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

        private static DateTime EnterOneDate () {
            DateTime dt;
            string s;
            Console.WriteLine("Please enter a date: ");
            do {
                s=Console.ReadLine();
                if (!(DateTime.TryParse(s, out dt))) {
                    Console.WriteLine("Enter a DATE!!!");
                }
            } while (!(DateTime.TryParse(s, out dt))); 
            return dt;
        }
        private static void PrintResult(float result) {
            string resultString=result.ToString("n2");
            Console.WriteLine("The result is "+resultString);
        }

    }
}

