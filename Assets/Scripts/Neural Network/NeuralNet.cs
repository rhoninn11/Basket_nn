using Assets.Scripts.Neural_Network;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NeuralNet : MonoBehaviour, INeuralNet
{
    [SerializeField]
    [Range(0, 1)] public double learningRate;
    [SerializeField]
    public double epochsCount;

    public Layer InputLayer { get; private set; }
    public Layer OutputLayer { get; private set; }
    public List<Layer> HiddenLayers { get; private set; }

    private List<Synapse> InputSynapses;
    private List<Synapse> OutputSynapse;
    private Output output = new Output();

    public double Gradient { get; private set; }

    public NeuralNet(int inputLayerSize, int hiddenLayerCount, int hiddenLayerSize)
    {
        InputLayer = new Layer("Input Layer", inputLayerSize);
        OutputLayer = new Layer("Output Layer", 1);
        HiddenLayers = new List<Layer>();

        for (int i = 0; i < hiddenLayerCount; i++)
        {
            string layerName = $"Hidden Layer {i + 1}";
            var layer = new Layer(layerName, hiddenLayerSize);
            HiddenLayers.Add(layer);
        }
    }

    public void BackPropagation(Layer outputLayer, params double[] targets)
    {
       
    }

    public double CalculateError(double value, double target)
    {
        return target - value;
    }

    public void ForwardPropagation(Layer outputLayer, params double[] inputs)
    {
        
    }

    public void Train()
    {
        
    }

    public double CalculateValue()
    {
        return output.Sigmoid(InputSynapses.Sum(x => x.Weight * x.InputNeuron.Value));
    }

    public double CalculateGradient(double? target = null)
    {
       // return target == null ? Gradient = OutputSynapse.Sum(x => (x.OutputNeuron.Gradient * x.Weight) * output.Sigmoid(x.OutputNeuron.Value)) : Gradient = CalculateError(target.Value) * output.Derivative() ;
        return 0.0;
    }
}
