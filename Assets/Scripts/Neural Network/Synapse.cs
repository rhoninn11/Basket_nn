using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Neural_Network
{
    class Synapse : MonoBehaviour
    {
        private Neuron _inputNeuron;
        private Neuron _outputNeuron;
        private double _weights;
        private double _weightDelta;

        System.Random random = new System.Random();
        public Synapse(Neuron InputNeuron, Neuron OutputNeuron)
        {
            _inputNeuron = InputNeuron;
            _outputNeuron = OutputNeuron;
            _weights = random.NextDouble(); //Generate random double point values from 0 to 1.
        }

        private double _weightsDelta;

        public double WeightsDelta
        {
            get { return _weightsDelta; }
            set { _weightsDelta = value; }
        }

    }
}
