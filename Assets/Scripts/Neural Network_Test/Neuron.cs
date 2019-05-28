using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Neuron
{
    public List<Synapse> InputSynapses { get; private set; }
    public List<Synapse> OutputSynapses { get; private set; }
    public double Bias { get; private set; }
    public double BiasDelta { get; private set; }
    public double Gradient { get; private set; }
    public double Value { get; set; }

    public Neuron()
    {
        InputSynapses = new List<Synapse>();
        OutputSynapses = new List<Synapse>();

        var random = new System.Random();
        Bias = 2 * random.NextDouble() - 1;
    }

    public Neuron(IEnumerable<Neuron> inputNeurons) : this()
    {
        foreach (var inputNeuron in inputNeurons)
        {
            var synapse = new Synapse(inputNeuron, this);
            inputNeuron.OutputSynapses.Add(synapse);
            InputSynapses.Add(synapse);
        }
    }

    public virtual double CalculateValue()
    {
        return Value = Sigmoid.Output(InputSynapses.Sum(a => a.Weight * a.InputNeuron.Value) + Bias);
    }

    public double CalculateError(double target)
    {
        return target - Value;
    }

    public double CalculateGradient(double? target = null)
    {
        return target == null
            ? (Gradient = OutputSynapses.Sum(a => a.OutputNeuron.Gradient * a.Weight) * Sigmoid.Derivative(Value))
            : (Gradient = CalculateError(target.Value) * Sigmoid.Derivative(Value));
    }

    public void UpdateWeights(double learningRate, double momentum)
    {
        var prevDelta = BiasDelta;
        BiasDelta = learningRate * Gradient;
        Bias += BiasDelta + momentum * prevDelta;

        foreach (var synapse in InputSynapses)
        {
            prevDelta = synapse.WeightDelta;
            synapse.WeightDelta = learningRate * Gradient * synapse.InputNeuron.Value;
            synapse.Weight += synapse.WeightDelta + momentum * prevDelta;
        }
    }

}