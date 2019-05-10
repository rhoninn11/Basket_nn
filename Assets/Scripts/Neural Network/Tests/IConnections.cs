using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Neural_Network
{
    public interface IConnections
    {
        double previousWeight { get; set; }
        double Weight { get; set; }
        double GetOutput();

        bool IsFromNeuron(Guid NeuronId);
        void UpdateWeight(double learningRate, double delta);
    }
}
