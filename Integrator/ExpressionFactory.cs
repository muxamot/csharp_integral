using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrator
{
    public class ExpressionFactory : IExpressionFactory
    {
        public IExpression Create(string expr)
        {
            IParser parser = new Parser(expr);
            return new Expression(parser);
        }
    }
}
