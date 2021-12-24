using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrator
{
    static class Operations
    {
        public static bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
                return true;
            return false;
        }

        public static bool IsOperator(char с)
        {
            if (("+-/*^()".IndexOf(с) != -1))
                return true;
            return false;
        }

        public static bool IsFunction(char с)
        {
            if (("sctzengq".IndexOf(с) != -1))
                return true;
            return false;
        }

        public static bool IsVariable(char с)
        {
            if (("x".IndexOf(с) != -1))
                return true;
            return false;
        }

        public static byte GetPriority(char s)
        {
            if (IsFunction(s))
                return 1;

            switch (s)
            {
                case '(': return 0;
                case ')': return 0;
                case '^': return 1;
                case '*': return 2;
                case '/': return 2;
                case '+': return 3;
                case '-': return 3;
                default: return 4;
            }
        }
    }
}
