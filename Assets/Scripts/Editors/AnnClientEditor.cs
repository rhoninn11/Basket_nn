using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AnnClient))]
public class AnnClientEditor : Editor
{
    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();
        AnnClient editant = ((AnnClient)this.target);

        if (GUILayout.Button("Poke server"))
        {
            editant.ServerCommand(editant.pokeMessage);
        }
        
    }
}
