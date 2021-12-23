
namespace Calculator_Prog
{
    class NumberCalculator
    {
        public List <int> Numbers {get;set;}
        public string Op {get;set;}
        //public int N {get;set;}

        public NumberCalculator() {
            this.EnterOperator();
            //this.EnterTotal();
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
        // private void EnterTotal() {
        //     Console.WriteLine("How many numbers do you want?");
        //     int n=GeneralMethods.EnterOneNumber ();
        //     this.N= n;
        // }
        private void EnterNumbers() {
            //int[] numbers = new int[this.N];
            Numbers=new List<int> ();
            int? x;
            int i =0;
            do {
                Console.WriteLine("Enter number {0}",(i+1).ToString());
                //numbers[i]=GeneralMethods.EnterOneNumber ();
                x=GeneralMethods.EnterOneNumberNull ();
                if (x.HasValue) this.Numbers.Add(x.Value);
                //this.Numbers.Add(x.Value);
                i++;
            } while (x.HasValue);
            //this.Numbers =numbers;
        }
        public void PrintResult(float result) {
            string resultString=result.ToString("n2");
            Console.WriteLine("The result is "+resultString);
        }
        public float Calculate (){
            float result=0;
            if (this.Op=="+") 
                    result = this.Numbers.Aggregate((a,b)=>a+b);
            if (this.Op=="-") 
                    result = this.Numbers.Aggregate((a,b)=>a-b);
            if (this.Op=="*")
                    result = this.Numbers.Aggregate((a,b)=>a*b);
            if (this.Op=="/") 
                    result = this.Numbers.Aggregate((a,b)=>a/b);
            return result;
        }
        public string MakeAString() {
            int i=0;
            string s="";
            foreach (int x in Numbers) {
                if (i==0) s=x.ToString();
                else s=s+this.Op+x.ToString();
                i++;
            }
            s=s+"="+this.Calculate().ToString("n2");
            return s;
        }

    }

    class DateCalculator
    {
        public DateTime Dt {get;set;}
        public string strDt {get;set;}
        public DateCalculator () {
            this.Dt=GeneralMethods.EnterOneDate ();
            this.strDt=this.Dt.ToLongDateString();
        }
        public void AddANumber(int n) {
            this.strDt= this.strDt+" + "+n.ToString() +" days = ";
            this.Dt=this.Dt.AddDays(n);
            this.strDt=this.strDt+this.Dt.ToLongDateString();    
        }
        public void Print() {
            Console.WriteLine("The date is : {0}",this.Dt.ToLongDateString());
        }
        
    }

    class GeneralMethods 
    {
        public static int? EnterOneNumberNull () {
        // int? n;
        // string s;
        // do {
        //     s=Console.ReadLine();
        //     if (!(int.TryParse(s, out n))) {
        //         Console.WriteLine("Enter a NUMBER!!!");
        //     }
        // } while (!(int.TryParse(s, out n))); 
        // return n;
        // }
        int n;
        string s=Console.ReadLine();
        if ((int.TryParse(s, out n))) return n;
        return null;
        }

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
        public static DateTime EnterOneDate () {
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
    }

    class FileWriter
    {
        public string fileName {get;set;}
        public FileWriter (string st) {
            this.fileName=st;
        }
        public void WriteIntoFile(string s) {
            //File.WriteAllText(@fileName,s);
            using (StreamWriter sw = File.CreateText(@fileName)) {
                sw.WriteLine(s);
            }
        }
        public void AppendToFile(string s) {
            using (StreamWriter sw = File.AppendText(@fileName)) {
                sw.WriteLine(s);
            }
            //File.AppendText(@fileName,s);
        }
    }

    class Program 
    {
        private const int NumberCalculatorCo = 1;
        private const int DateCalculatorCo = 2;
        static void Main (string[] args) 
        {
            Welcome(); 
            FileWriter FL=new FileWriter("CalculatorLog.txt");
            string s="";
            FL.WriteIntoFile(s);
            while (true) {
                int calculationMode = AskForCalculationMode();
                if (calculationMode==NumberCalculatorCo)
                    s=PerformOneNumberCalculation();
                else
                    s=PerformOneDateCalculation();
                FL.AppendToFile(s);
            }
        }
        private static string PerformOneDateCalculation() {
            DateCalculator dt=new DateCalculator();
            Console.WriteLine("Please enter the number of days to add:");
            int n=GeneralMethods.EnterOneNumber ();
            dt.AddANumber(n);
            dt.Print();
            return dt.strDt;
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

        private static string PerformOneNumberCalculation() {
            NumberCalculator numC=new NumberCalculator();
            numC.PrintResult(numC.Calculate());  
            return numC.MakeAString();
        }   
    }   
}

