using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Neural_Network
{
    public class Neuron : MonoBehaviour
    {
        private List<Synapse> _inputSynapses;
        private List<Synapse> _outputSynapses;
        //private double Bias;

        System.Random random = new System.Random();
        public Neuron()
        {
            _inputSynapses = new List<Synapse>();
            _outputSynapses = new List<Synapse>();
            //Bias = random.NextDouble();
        }
    }
}
