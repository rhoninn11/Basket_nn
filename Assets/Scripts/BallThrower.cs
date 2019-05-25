using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallThrower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ballPrefab;
    private List<Ball> _ballCollection = new List<Ball>();
    private List<Vector3> _directionBuffer = new List<Vector3>();
    private bool _ready = false;

    public Vector3 GetThrowPosition()
    {
        Vector3 heightOffset = new Vector3(0, 0.94f, 0);
        Vector3 throwPoint = this.transform.position + heightOffset;

        return throwPoint;
    }

    private Ball _SpawnBall()
    {
        if (ballPrefab == null)
            return null;

        GameObject ballObject = Instantiate(ballPrefab, this.GetThrowPosition(), Quaternion.identity);
        ballObject.layer = 9;

        return ballObject.GetComponent<Ball>();
    }

    private void _CheckingAllBallExpired()
    {
        _ready = _ballCollection.TrueForAll(b => b.IsLiveTimeExpired());
    }

    void FixedUpdate()
    {
        _CheckingAllBallExpired();
    }

    public void DataGatteringThrow(Vector3 direction)
    {
        if(!_ready)
            return;

        float deviation = 0.37f;
     
        for (int i = 0; i < 3; i++)
            for (int jj = 0; jj < 3; jj++)
                for (int kkk = 0; kkk < 3; kkk++){
                    Vector3 dir = direction + new Vector3(deviation * i, deviation * jj, deviation * kkk);
                    _directionBuffer.Add(dir);
                    ThrowABall(dir);
                }
    }

    public void ThrowABall(Vector3 throwVector)
    {
        Ball ballToThrow = _SpawnBall();

        if (ballToThrow == null)
            return;

        _ready = false;
        _ballCollection.Add(ballToThrow);
        ballToThrow.Throw(throwVector);
    }
    public List<TrajectoryData> CollectTrajecoryData()
    {
        if(!_ready)
            return null;
            
        List<TrajectoryData> ballData = new List<TrajectoryData>();

        for (int i = 0; i < _ballCollection.Count; i++)
            ballData.Add(new TrajectoryData(_directionBuffer[i],
                                            _ballCollection[i].trajectory));

        foreach (var ball in _ballCollection)
            Destroy(ball.gameObject);

        _ballCollection = new List<Ball>();
        _directionBuffer = new List<Vector3>();
        return ballData;
    }

    public bool IsReady(){
        return _ready;
    }
}
