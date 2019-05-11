using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuralNetworkModel : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1)] public double learningRate;
    [SerializeField]
    public double epochsCount;

    public Layer InputLayer { get; private set; }
    public Layer OutputLayer { get; private set; }
    public List<Layer> HiddenLayers { get; private set; }


    public NeuralNetworkModel(int inputLayerSize, int hiddenLayerCount, int hiddenLayerSize)
    {
        InputLayer = new Layer("Input Layer", inputLayerSize);
        OutputLayer = new Layer("Output Layer", 1);
        HiddenLayers = new List<Layer>();

        for (int i = 0; i < hiddenLayerCount; i++)
        {
            string layerName = $"Hidden Layer {i+1}";
            var layer = new Layer(layerName, hiddenLayerSize);
            HiddenLayers.Add(layer);
        }
    }
}   
