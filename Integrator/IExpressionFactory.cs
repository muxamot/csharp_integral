using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrator
{
    interface IExpressionFactory
    {
        IExpression Create(string expr);
    }
}
