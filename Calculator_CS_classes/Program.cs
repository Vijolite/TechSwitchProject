
namespace Calculator_Prog
{
    class NumberCalculator
    {
        public int[] Numbers {get;set;}
        public string Op {get;set;}
        public int N {get;set;}

        public NumberCalculator() {
            this.EnterOperator();
            this.EnterTotal();
            this.EnterNumbers();
        }
        private void EnterOperator() {
            string op;
            do {
                Console.WriteLine("Please enter the operator");
                op=Console.ReadLine();
            } while ((op!="+") && (op!="-") && (op!="*") &&(op!="/") );
            this.Op= op;
        }
        private void EnterTotal() {
            Console.WriteLine("How many numbers do you want?");
            int n=GeneralMethods.EnterOneNumber ();
            this.N= n;
        }
        private void EnterNumbers() {
            int[] numbers = new int[this.N];
            for (int i=0;i<this.N;i++) {
                Console.WriteLine("Enter number {0}",(i+1).ToString());
                numbers[i]=GeneralMethods.EnterOneNumber ();
            }
            this.Numbers =numbers;
        }
        private void PrintResult(float result) {
            string resultString=result.ToString("n2");
            Console.WriteLine("The result is "+resultString);
        }
        public void Calculate (){
            float result=this.Numbers[0];
            for (int i=1; i<this.Numbers.Length; i++) {
                if (this.Op=="+") {
                    result+=this.Numbers[i];
                }
                else if (this.Op=="*") {
                    result*=this.Numbers[i];
                }
                else if (this.Op=="-") {
                    result-=this.Numbers[i];
                }
                else if (this.Op=="/") {
                    result/=this.Numbers[i];
                }
            }
            this.PrintResult(result);
        }

    }

    class DateCalculator
    {
        public DateTime Dt {get;set;}
        public DateCalculator () {
            DateTime dt;
            string s;
            Console.WriteLine("Please enter a date: ");
            do {
                s=Console.ReadLine();
                if (!(DateTime.TryParse(s, out dt))) {
                    Console.WriteLine("Enter a DATE!!!");
                }
            } while (!(DateTime.TryParse(s, out dt))); 
            this.Dt= dt;
        }
        public void AddANumber(int n) {
            this.Dt=this.Dt.AddDays(n);
        }
        public void Print() {
            Console.WriteLine("The date is : {0}",this.Dt.ToLongDateString());
        }
        
    }

    class GeneralMethods 
        {
        public static int EnterOneNumber () {
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
    }


    class Program 
    {
        private const int NumberCalculatorCo = 1;
        private const int DateCalculatorCo = 2;
        static void Main (string[] args) 
        {
            Welcome(); 
            while (true) {
                int calculationMode = AskForCalculationMode();
                if (calculationMode==NumberCalculatorCo)
                    PerformOneNumberCalculation();
                else
                    PerformOneDateCalculation();
            }
        }
        private static void PerformOneDateCalculation() {
            DateCalculator dt=new DateCalculator();
            Console.WriteLine("Please enter the number of days to add:");
            int n=GeneralMethods.EnterOneNumber ();
            dt.AddANumber(n);
            dt.Print();
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
            NumberCalculator numC=new NumberCalculator();
            numC.Calculate();    
        }   
    }

    
}

