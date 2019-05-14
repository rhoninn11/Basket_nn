using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Output : MonoBehaviour
{
    public double Sigmoid(double x)
    {
        return 1.0 / (1.0 + Mathf.Exp((float)-x));
    }

    public double Derivative(double x)
    {
        return x * (1 - x);
    }
}
        