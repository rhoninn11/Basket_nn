using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neuron : MonoBehaviour
{
    public List<Synapse> InputSynapses { get; private set; }
    public List<Synapse> OutputSynapses { get; private set; }
    public double Value { get; private set; }
    public double Gradient { get; private set; }

    public Neuron()
    {
        InputSynapses = new List<Synapse>();
        OutputSynapses = new List<Synapse>();
    }
}
        