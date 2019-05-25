using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DataProcessor))]
public class DataProcessorEditorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DataProcessor processor = ((DataProcessor)this.target);

        EditorGUILayout.LabelField("throw performance", processor.throwPerformanceIndex.ToString());
        EditorGUILayout.LabelField("the highest performance", processor.theHighestPerformanceIndex.ToString());
        EditorGUILayout.LabelField("the lowest performance", processor.theLowestPerformanceIndex.ToString());
    }
}
