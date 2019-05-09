using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class V3
{
    public Vector3 v3;

    public V3(Vector3 v3) { this.v3 = v3; }
}

[Serializable]
public class VS
{
    public V3[] vS;

    public VS(V3[] vS) { this.vS = vS; }
}

[Serializable]
public class VSDisct
{
    public Dictionary<int,VS> vSDict = new Dictionary<int, VS>();

}

