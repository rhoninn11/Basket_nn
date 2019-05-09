using System;
using System.Collections.Generic;

public class NeuralNetwork 
{
    private int[] layers;
    private float[][] neurons;
    private float[][] weights;

    public NeuralNetwork(int[] layers)
    {
        this.layers = new int[layers.Length];

        foreach (var item in layers)
        {
            this.layers[item] = layers[item];
        }

        SetNeurons();
        SetWeights();
    }

    private void SetNeurons()
    {
        List<float[]> neuronsList = new List<float[]>();

        foreach (var l in layers)
        {
            neuronsList.Add(new float[layers[l]]);
        }

        neurons = neuronsList.ToArray();
    }

    private void SetWeights()
    {
        List<float[][]> weightsList = new List<float[][]>();

        foreach (var l in layers)
        {
            List<float[]> layerWeightList = new List<float[]>();

            int neuronsInPreviousLayer = layers[l - 1];

            foreach (var n in neurons[l])
            {
                float[] neuronWeights = new float[neuronsInPreviousLayer];
            }
        }
    }
}
