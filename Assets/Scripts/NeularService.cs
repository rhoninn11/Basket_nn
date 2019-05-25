using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NeularService : MonoBehaviour
{
    private NeuralNet _net;

    public void PopulateNeuralNetwork()
    {
        _net = new NeuralNet(6, 12, 3, 4, 0.33, 0.6);
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
            return Vector3.up;

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
        _net.SingleTrain(new DataSet(values,target));
        Debug.Log("adaptation");
    }
}
