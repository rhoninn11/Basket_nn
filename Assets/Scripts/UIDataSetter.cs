using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDataSetter : MonoBehaviour
{
    public Slider HiddenLayersCount;
    public Slider HiddenLayersSize;
    public Slider TimeScale;
    public Slider DeviationFactor;

    public Text ThrowPerformance;
    public Text HighestPerformance;
    public Text LowestPerformance;
    public Text GoalPerformance;
    public Text GoalDirection;

    public ThrowerService throwerService;
    public DataProcessor dataProcessor;
    public NeularService neuralService;

    private void Update()
    {
        SetSliderValues();
        SetTextValues();
    }

    private void SetTextValues()
    {
        ThrowPerformance.text = $"Throw Performance: {dataProcessor.throwPerformanceIndex:0.000}";
        HighestPerformance.text = $"The Highest Performance: {dataProcessor.theHighestPerformanceIndex:0.000}";
        LowestPerformance.text = $"The Lowest Performance: {dataProcessor.theLowestPerformanceIndex:0.000}";
        GoalPerformance.text = $"Goal performance: {dataProcessor.theHighestPerformaceAchived:0.000}";
        GoalDirection.text = $"Goal Direction: X: {dataProcessor.ultimateDirection.x:0.000} Y: {dataProcessor.ultimateDirection.y:0.00} Z: {dataProcessor.ultimateDirection.z:0.00}";
    }

    private void SetSliderValues()
    {
        HiddenLayersCount.onValueChanged.AddListener(delegate { neuralService.hiddenLayersCount = (int)HiddenLayersCount.value; });
        HiddenLayersSize.onValueChanged.AddListener(delegate { neuralService.hiddenLayerSize = (int)HiddenLayersSize.value; });

        TimeScale.onValueChanged.AddListener(delegate { throwerService.timeScale = (float)TimeScale.value; });
        DeviationFactor.onValueChanged.AddListener(delegate { throwerService._deviationFactor = (int)DeviationFactor.value; });
    }

    public void SetNewTimeScale()
    {
        Time.timeScale = throwerService.timeScale;
    }

    public void CancelApplication()
    {
        Application.Quit();
    }
}
