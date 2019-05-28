using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NeularService : MonoBehaviour
{
    private NeuralNet _net;
    private Vector3 lastDirectionToLern;
    private int duplicationTimes = 0;

    [Range(1, 5)]
    public int hiddenLayersCount = 1;

    [Range(3, 20)]
    public int hiddenLayerSize = 6;

    public void PopulateNeuralNetwork()
    {
        _net = new NeuralNet(6, hiddenLayerSize, 3, hiddenLayerSize, 0.33, 0.9);
    }

    public void SaveNeuralNetwork()
    {
        Debug.Log("saving not implemented yet");
    }

    public void LoadNeuralNetwork()
    {
        Debug.Log("loading not implemented yet");
    }

    public Vector3 CalculateThrowDirection(Vector3 position, Vector3 targetPosition)
    {
        if (_net == null)
            return new Vector3(0.5f, 1, 0.5f);

        double[] inputVector = { position.x, position.y, position.z, targetPosition.x, targetPosition.y, targetPosition.z };
        double[] output = _net.Compute(inputVector);

        Vector3 outputDirection = new Vector3((float)output[0], (float)output[1], (float)output[2]);
        return outputDirection;
    }

    public void NetAdaptation(Vector3 throwPosition, Vector3 targetPosition, Vector3 directionToLern)
    {
        if (_net == null)
            return;

        double[] values = { throwPosition.x, throwPosition.y, throwPosition.z, targetPosition.x, targetPosition.y, targetPosition.z };
        double[] target = { directionToLern.x, directionToLern.y, directionToLern.z };

        if (directionToLern == lastDirectionToLern)
        {
            if (++duplicationTimes > 5)
            {
                duplicationTimes = 0;
                _net.TrainForSingleDataset(new DataSets(values, target), 100);
                // Debug.Log("Focusedlearning");
                return;

            }
        }
        _net.SingleTrain(new DataSets(values, target));
        lastDirectionToLern = directionToLern;
    }
}
