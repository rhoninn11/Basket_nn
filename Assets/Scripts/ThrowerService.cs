using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnnClient))]
public class ThrowerService : MonoBehaviour
{
    public int throwerCount;
    public BallThrower throwerPrefab;
    public BallTarget throwerTarget;
    private BallThrower _thrower;

    private float _throwerExistingTime;

    public BallThrower SpawnThrower()
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

    public string CollectTrajectoryData()
    {
        VSDisct trajectories = _thrower.CollectBallsTrajecory();

        return JsonUtility.ToJson(trajectories);
    }

    public void MoveThrowerOnTrajectory(float timeDelta)
    {
        _throwerExistingTime += timeDelta;
        float f = 0.1f;
        float omega = 2 * Mathf.PI * f;
        int multipler = 2;

        float xDelta = multipler * 2 * Mathf.Cos(omega * _throwerExistingTime) - _thrower.transform.position.x;
        float zDelta = multipler * -Mathf.Sin(omega * _throwerExistingTime * 2) - _thrower.transform.position.z;
        _thrower.transform.Translate(xDelta, 0, zDelta);
    }

    public void CreateThrower(){
        if(_thrower != null)
            Destroy(_thrower.gameObject);

        _throwerExistingTime = 0;
        _thrower = SpawnThrower();
    }

    public async void ThrowingProccess()
    {
        string inputData = CollectTrajectoryData();
        string command = "solve" + inputData;

        string outputJson = await GetComponent<AnnClient>().ServerCommand("solve" + inputData);
        VS throwData = JsonUtility.FromJson<VS>(outputJson);

    }

    public void FixedUpdate(){
        if(_thrower != null)
            MoveThrowerOnTrajectory(Time.fixedDeltaTime);
    }


}
