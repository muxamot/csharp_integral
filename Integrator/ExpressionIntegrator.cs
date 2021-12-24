using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrator
{
    public class ExpressionIntegrator : IExpressionIntegrator
    {
        private IExpression expr_;

        public ExpressionIntegrator(IExpression expr)
        {
            expr_ = expr;
        }

        public double Integrate(double a, double b, double dx)
        {
            if (b < a || (dx + a) > b)
                throw new FormatException();

            double res = 0;
            while (a < b)
            {
                res += ((expr_.by(a) + expr_.by(a + dx)) / 2)*dx;
                a += dx;
            }
            return res;
        }
    }
}
