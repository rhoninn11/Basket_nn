using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NeularService))]
public class NeuralServiceEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        NeularService service = ((NeularService)this.target);

        if (GUILayout.Button("populate new neural network"))
        {
            service.PopulateNeuralNetwork();
        }

        if (GUILayout.Button("save neural network"))
        {
            service.SaveNeuralNetwork();
        }

        if (GUILayout.Button("load neural network"))
        {
            service.LoadNeuralNetwork();
        }
    }
}
