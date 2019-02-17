using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ThrowerService))]
public class ThrowerServiceEditor : Editor
{
    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();
        ThrowerService editant = ((ThrowerService)this.target);

        if (GUILayout.Button("Spawn Throwers"))
        {
            editant.SpawnThrowers();
        }
        if (GUILayout.Button("Throwing"))
        {
            editant.ThrowingProccess();
        }
        
    }
}
