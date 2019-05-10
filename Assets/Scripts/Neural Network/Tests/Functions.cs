using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Neural_Network
{
    class Functions : IFunctions
    {
        private double _treshold;

        public double Treshold
        {
            get { return _treshold; }
            set { _treshold = value; }
        }


        public double InputFunction(List<IConnections> inputs)
        {
            double result = inputs
                .Select(s => s.Weight * s.GetOutput())
                .Sum();

            return result;
        }

        public double ActivationFunction(double input)
        {
            //Calculate Output
            double result = Convert.ToDouble(input > _treshold);
            return result;
        }
    }
}
