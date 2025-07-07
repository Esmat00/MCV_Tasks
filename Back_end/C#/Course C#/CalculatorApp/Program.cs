
using System;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
           

            Console.Write("Enter the first number: ");
            double number1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the second number: ");
            double number2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nSelect operation:\n");
            Console.WriteLine("(+) Collection ");
            Console.WriteLine("(-) Subtraction ");
            Console.WriteLine("(*) multiplication ");
            Console.WriteLine("(/) division ");

            Console.Write("Your choice:");
            string choice = Console.ReadLine();

            
            ICalculator calc = new Calculator(number1, number2);

         

            switch (choice)
            {

                case "+":
                    Console.WriteLine($" The result: {calc.Add()}");
                    break;

               
                case "-":
                    Console.WriteLine($" The result: {calc.Subtract()}");
                    break;

             
                case "*":
                    Console.WriteLine($" The result: {calc.Multiply()}");
                    break;

           
                case "/":
                    Console.WriteLine($" The result: {calc.Divide()}");
                    break;

                default:
                    Console.WriteLine("Invalid selection.");
                    break;
            }

            Console.ReadKey();
        }
    }
}
