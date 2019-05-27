using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sigmoid
{
    public double Output(double x)
    {
        return x < -45.0 ? 0.0 : x > 45.0 ? 1.0 : 1.0 / (1.0 + Mathf.Exp((float)-x));
    }

    public double Derivative(double x)
    {
        return x * (1 - x);
    }
}
