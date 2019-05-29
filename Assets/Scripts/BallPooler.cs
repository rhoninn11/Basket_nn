using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPooler : MonoBehaviour
{
    private Queue<GameObject> _ballPool;
    public int poolSize;
    public GameObject prefab;
    void Start()
    {
        _ballPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            _ballPool.Enqueue(obj);
        }
    }

    public Ball GetBallFromPool(Vector3 position, Quaternion rotation, int layerNumber){
        GameObject ball = _ballPool.Dequeue();
        ball.transform.position = position;
        ball.transform.rotation = rotation;
        ball.layer = layerNumber;
        ball.SetActive(true);
        _ballPool.Enqueue(ball);

        return ball.GetComponent<Ball>();
    }
}
