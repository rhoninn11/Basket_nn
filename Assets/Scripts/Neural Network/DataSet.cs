using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSet : MonoBehaviour
{
    public double[] Values { get; private set; }
    public double[] Targets { get; private set; }

    public DataSet(double[] values, double[] targets)
    {
        Values = values;
        Targets = targets;
    }
}
