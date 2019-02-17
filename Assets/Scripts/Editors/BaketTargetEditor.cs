using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BallTarget))]
public class BaketTargetEditor : Editor
{
    public override void OnInspectorGUI(){

       DrawDefaultInspector();

       if(GUILayout.Button("Print possition")){
           ((BallTarget)this.target).GetTargetCords();
       }
   }
}
