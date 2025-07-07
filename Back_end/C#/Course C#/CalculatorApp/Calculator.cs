

using System;

namespace CalculatorApp
{
    public class Calculator : ICalculator
    {
        public double num1;
        public double num2;

        public Calculator(double n1, double n2)
        {
            num1 = n1;
            num2 = n2;
        }

        public double Add()
        {
            return num1 + num2;
        }

        public double Subtract()
        {
            return num1 - num2;
        }

        public double Multiply()
        {
            return num1 * num2;
        }

        public double Divide()
        {
           
            return num1 / num2;
        }
    }
}
