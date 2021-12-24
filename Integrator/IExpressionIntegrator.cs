using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrator
{
    public interface IExpressionIntegrator
    {
        double Integrate(double a, double b, double dx);
    }
}
