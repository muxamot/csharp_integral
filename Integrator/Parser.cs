using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrator
{
    public class Parser : IParser
    {
        private string parsed_s_;

        private string Preprocess(string input)
        {
            input = input.Replace("sin", "s");
            input = input.Replace("cos", "c");
            input = input.Replace("tg", "t");
            input = input.Replace("ct", "z");
            input = input.Replace("exp", "e");
            input = input.Replace("ln", "n");
            input = input.Replace("lg", "g");
            input = input.Replace("sqrt", "q");
            //its enough, i think

            return input;
        }

        private string MakePostfix(string input)
        {
            string output = string.Empty;
            Stack<char> operStack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (Operations.IsDelimeter(input[i]))
                    continue;

                if (Char.IsDigit(input[i]))
                {
                    while (!Operations.IsDelimeter(input[i]) && !Operations.IsOperator(input[i]))
                    {
                        output += input[i];
                        i++;

                        if (i == input.Length) break;
                    }

                    output += " ";
                    i--;
                    continue;
                }

                if (Operations.IsVariable(input[i]))
                {
                    output = output + input[i] + " ";
                    continue;
                }

                if (Operations.IsFunction(input[i]))
                {
                    operStack.Push(char.Parse(input[i].ToString()));
                    continue;
                }

                if (Operations.IsOperator(input[i]))
                {
                    if (input[i] == '(')
                        operStack.Push(input[i]);
                    else if (input[i] == ')')
                    {
                        char s = operStack.Pop();
                        while (s != '(')
                        {
                            if (operStack.Count == 0)
                                throw new FormatException();
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else
                    {
                        while (operStack.Count > 0 && Operations.GetPriority(input[i]) > Operations.GetPriority(operStack.Peek()) && operStack.Peek() != '(')
                        {
                            output += operStack.Pop().ToString() + " ";
                        }
                        operStack.Push(char.Parse(input[i].ToString()));
                    }
                }
            }

            while (operStack.Count > 0)
            {
                if (operStack.Peek() == '(')
                    throw new FormatException();

                output += operStack.Pop() + " ";
            }

            return output;
        }

        public Parser(string str)
        {
            parsed_s_ = MakePostfix(Preprocess(str));
        }

        public string get()
        {
            return parsed_s_;
        }
    }
}
