using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSets
{
    public double[] Values { get; set; }
    public double[] Targets { get; set; }

    public DataSets(double[] values, double[] targets)
    {
        Values = values;
        Targets = targets;
    }   
}
