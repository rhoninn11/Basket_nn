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
        ThrowerService service = ((ThrowerService)this.target);
        var dir = service.LastThrowDirection;
        EditorGUILayout.LabelField("last direction", $"x:{dir.x}, y:{dir.y}, z:{dir.z}");
        if (GUILayout.Button("Spawn Throwers"))
        {
            service.CreateThrower();
        }     
    }
}
