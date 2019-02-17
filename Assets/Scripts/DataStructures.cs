using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class VectorData
{
    public Vector3 vector;

    public VectorData(Vector3 position) { this.vector = position; }
}

[Serializable]
public class VectorDataCollection
{
    public VectorData[] vectors;

    public VectorDataCollection(VectorData[] vector) { vectors = vector; }
}

