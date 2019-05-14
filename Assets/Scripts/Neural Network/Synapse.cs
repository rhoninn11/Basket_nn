using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synapse : MonoBehaviour
{
    public Neuron InputNeuron { get; private set; }
    public Neuron OutputNeuron { get; private set; }
    public double Weight { get; private set; }

    private System.Random random = new System.Random();

    public Synapse(Neuron inputNeuron, Neuron outputNeuron)
    {
        InputNeuron = inputNeuron;
        OutputNeuron = outputNeuron;
        Weight = random.NextDouble(); //Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
    }
}
        