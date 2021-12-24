using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrator
{
    public class Expression : IExpression
    {
        // private:
        private string postfix_expr_;

        private double Count(double v)
        {
            double result = 0; 
            Stack<double> temp = new Stack<double>();
            string input = postfix_expr_.Replace("x", v.ToString());

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (!Operations.IsDelimeter(input[i]) && !Operations.IsOperator(input[i]) && !Operations.IsFunction(input[i]))
                    {
                        a += input[i];
                        i++;
                        if (i == input.Length) break;
                    }
                    temp.Push(double.Parse(a));
                    i--;
                }
                else if (Operations.IsOperator(input[i]))
                {
                    double a = temp.Pop();
                    double b = temp.Pop();

                    switch (input[i])
                    {
                        case '+': result = b + a; break;
                        case '-': result = b - a; break;
                        case '*': result = b * a; break;
                        case '/': result = b / a; break;
                        case '^': result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString()); break;
                    }
                    temp.Push(result);
                }
                else if (Operations.IsFunction(input[i]))
                {
                    double a = temp.Pop();

                    switch (input[i])
                    {
                        case 's': result = Math.Sin(a); break;
                        case 'c': result = Math.Cos(a); break;
                        case 't': result = Math.Tan(a); break;
                        case 'z': result = 1 / Math.Tan(a); break; //catching dbz excetion needed
                        case 'e': result = Math.Exp(a); break;
                        case 'n': result = Math.Log(a, Math.E); break;
                        case 'g': result = Math.Log10(a); break;
                        case 'q': result = Math.Sqrt(a); break;
                    }
                    temp.Push(result);
                }
            }
            return temp.Peek();
        }

        // public:
        public Expression(IParser parser)
        {
            postfix_expr_ = parser.get();
        }

        public double by(double x)
        {
            return Count(x);
        }
    }
}
