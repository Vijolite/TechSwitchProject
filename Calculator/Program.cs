// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

namespace Calculator_Prog
{
    class Program 
    {
        static void Main (string[] args) 
        {
            Console.WriteLine("Welcome to the calculator!!!");
            Console.WriteLine("Enter 2 numbers");
            string s1=Console.ReadLine();
            int TheFirstNum=int.Parse(s1);
            string s2=Console.ReadLine();
            int TheSecondNum=int.Parse(s2);
            Console.WriteLine("The product is "+TheFirstNum*TheSecondNum);
        }
    }
}

