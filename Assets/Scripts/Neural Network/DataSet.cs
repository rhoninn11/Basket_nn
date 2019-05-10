using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Neural_Network
{
    class DataSet : MonoBehaviour
    {
        private double[] _values;
        private double[] _targets;

        public DataSet(double[] Values, double[] Targets)
        {
            _values = Values;
            _targets = Targets;
        }
    }
}
