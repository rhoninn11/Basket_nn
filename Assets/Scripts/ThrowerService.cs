using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnnClient))]
public class ThrowerService : MonoBehaviour
{
    public int throwerCount;
    public BallThrower throwerPrefab;
    public Material baseMaterial;
    public BallTarget throwerTarget;
    private List<BallThrower> throwerList;

    public void SpawnThrowers()
    {
        if (throwerList == null)
            throwerList = new List<BallThrower>();

        int throwerRemain = throwerList.Count - throwerCount;
        for (int i = 0; i < 10; i++)
        {

            try
            {
                BallThrower thrower = SpawnThrower();
                thrower.GetComponent<Renderer>().material = RandomColorMaterial();
                throwerList.Add(thrower);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }

    public Material RandomColorMaterial()
    {
        if (baseMaterial == null)
            throw new Exception("there is no base material selected");

        Material material = new Material(baseMaterial);
        material.color = UnityEngine.Random.ColorHSV(0, 1);

        return material;
    }

    public BallThrower SpawnThrower()
    {
        if (throwerPrefab == null)
            throw new Exception("there is no thrower prefab");

        float xValue = UnityEngine.Random.Range(-4.0f, 4.0f);
        float zValue = UnityEngine.Random.Range(-6.0f, 2.5f);
        Vector3 position = new Vector3(xValue, 2, zValue);

        return Instantiate<BallThrower>(throwerPrefab, position, Quaternion.identity);
    }

    public string ReadThrowersData()
    {
        var throwData = new List<VectorData>();

        for (int i = 0; i < throwerList.Count; i++)
        {

            var throwPoint = throwerList[i].GetThrowPosition();

            throwData.Add(new VectorData(throwPoint));
        }

        return JsonUtility.ToJson(new VectorDataCollection(throwData.ToArray()));
    }

    public void ThrowersBallThrow(VectorDataCollection data)
    {

        int throwerCount = throwerList.Count;
        if (data.vectors.Length != throwerCount)
            return;

        for (int i = 0; i < throwerCount; i++)
            throwerList[i].ThrowABall(data.vectors[i].vector, throwerTarget);

    }

    public async void ThrowingProccess()
    {

        string inputData = ReadThrowersData();
        string command = "solve" + inputData;

        string outputJson = await GetComponent<AnnClient>().ServerCommand("solve" + inputData);
        VectorDataCollection throwData = JsonUtility.FromJson<VectorDataCollection>(outputJson);

        ThrowersBallThrow(throwData);
    }


}
