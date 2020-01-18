using System;
using TestProject.Calculator;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ICalculator<int> calc = new Calculator<int>();
            calc.Addition(5, 10);
            calc.Subtraction(5, 10);
            calc.Multiplication(5, 10);
            calc.Division(5, 10);

            Calculator<double> calc1 = new Calculator<double>();
            calc1.Addition(10.3, 5);
            calc1.Subtraction(10.3, 5);
            calc1.Multiplication(10.3, 5);
            calc1.Division(10.3, 5);

            Console.WriteLine();
            Calculator<char> calc2 = new Calculator<char>();
            calc2.Addition('a', 'b');
            calc2.Subtraction('l', 'm');
            calc2.Multiplication('a', 'b');
            calc2.Division('d', 'a');
            
            Calculator<string> calc3 = new Calculator<string>();
            calc3.Addition("Happy ","new year");
            calc3.Subtraction("Moskow", "Minsk");
            calc3.Multiplication("Lena", "Michele");
            calc3.Division("hdjhjhdkhd", "hdjhj");
          
           

            Console.ReadLine();

        }
    }
}
