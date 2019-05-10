using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Neural_Network
{
    interface IFunctions
    {
        double InputFunction(List<IConnections> inputs);
        double ActivationFunction(double input);
    }
}
