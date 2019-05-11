using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Neural_Network
{
    interface INeuralNet
    {
        void Train();
        void ForwardPropagation(Layer outputLayer, params double[] inputs);
        void BackPropagation(Layer outputLayer, params double[] targets);
        double CalculateError(double value, double target);

    }
}
