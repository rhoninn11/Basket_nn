using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowerService : MonoBehaviour
{
    public int throwerCount;
    public BallThrower throwerPrefab;
    public BallTarget target;
    public DataProcessor dataProcessor;
    public NeularService neuralService;


    private BallThrower _thrower;
    private float _throwerExistingTime;
    public Vector3 LastThrowDirection { get; set;}
    private Vector3 _lastThrowPosition;
    private bool _first = true;

    private BallThrower _SpawnThrower()
    {
        if (throwerPrefab == null)
            throw new Exception("there is no thrower prefab");

        Vector3 position = _NewThrowerPosition();

        return Instantiate<BallThrower>(throwerPrefab, position, Quaternion.identity);
    }

    private Vector3 _NewThrowerPosition()
    {
        float xValue = UnityEngine.Random.Range(-4.0f, 4.0f);
        float zValue = UnityEngine.Random.Range(-6.0f, 2.5f);
        return new Vector3(xValue, 2, zValue);
    }

    private void _UpdateThrowerTime(float timeDelta)
    {
        _throwerExistingTime += timeDelta;
    }
    private void _MoveThrowerOnTrajectory()
    {
        float f = 0.1f;
        float omega = 2 * Mathf.PI * f;
        int multipler = 2;

        float xDelta = multipler * 2 * Mathf.Cos(omega * _throwerExistingTime) - _thrower.transform.position.x;
        float zDelta = multipler * -Mathf.Sin(omega * _throwerExistingTime * 2) - _thrower.transform.position.z;
        _thrower.transform.Translate(xDelta, 0, zDelta);
    }

    private void _ThrowingManagment()
    {
        if (_thrower.IsReady())
        {
            List<TrajectoryData> collectedData = _thrower.CollectTrajecoryData();

            if (collectedData.Count > 0)
            {
                Vector3 directionToLern = dataProcessor.findOptimalThrowDirection(collectedData, target, LastThrowDirection);
                if (!_first)
                    neuralService.NetAdaptation(LastThrowDirection, target.GetTargetCords(), directionToLern);
            }
            Vector3 throwPosition = _thrower.GetThrowPosition();
            Vector3 throwDirection = neuralService.CalculateThrowDirection(throwPosition, target.GetTargetCords());
            _thrower.DataGatteringThrow(throwDirection);
            LastThrowDirection = throwDirection;
            _lastThrowPosition = throwPosition;
            _first = false;
        }
    }

    public void CreateThrower()
    {
        if (_thrower != null)
            Destroy(_thrower.gameObject);

        _throwerExistingTime = 0;
        _thrower = _SpawnThrower();
        Time.timeScale = 3;
    }

    public void FixedUpdate()
    {
        if (_thrower != null)
        {
            _UpdateThrowerTime(Time.fixedDeltaTime);
            //_MoveThrowerOnTrajectory();
            _ThrowingManagment();
        }
    }


}
