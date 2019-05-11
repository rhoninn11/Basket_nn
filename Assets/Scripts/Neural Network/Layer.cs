using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    public string Name { get; private set; }
    public List<Neuron> Neurons { get; private set; }

    public Layer(string name, int size)
    {
        Name = name; 
        SetNeuronsCount(size);
    }

    private void SetNeuronsCount(int size)
    {
        Neurons = new List<Neuron>();
        for (int i = 0; i < size; i++)
        {
            var neuron = new Neuron();
            Neurons.Add(neuron);
        }
    }
}
