using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallThrower : MonoBehaviour
{
    public BallPooler pooler;
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
        if (pooler == null)
            return null;

        Ball ball = pooler.GetBallFromPool(this.GetThrowPosition(), Quaternion.identity, 9);
        return ball;
    }

    private void _CheckingAllBallExpired()
    {
        _ready = _ballCollection.TrueForAll(b => b.IsLiveTimeExpired());
    }

    void FixedUpdate()
    {
        _CheckingAllBallExpired();
    }

    public void DataGatteringThrow(Vector3 direction,float deviation)
    {
        if (!_ready)
            return;

        int perAxisAlternative = 3;
        int offset = -1;

        for (int i = 0; i < perAxisAlternative; i++)
            for (int jj = 0; jj < perAxisAlternative; jj++)
                for (int kkk = 0; kkk < perAxisAlternative; kkk++)
                {   
                    float xDir = Mathf.Max(-1, Mathf.Min(direction.x + deviation * (i + offset), 1));
                    float yDir = Mathf.Max(-1, Mathf.Min(direction.y + deviation * (jj + offset), 1));
                    float zDir = Mathf.Max(-1, Mathf.Min(direction.z + deviation * (kkk + offset), 1));

                    Vector3 dir = new Vector3(xDir, yDir, zDir);
                    _directionBuffer.Add(dir);

                    ThrowABall(dir, dir == direction);
                }
    }

    public void ThrowABall(Vector3 throwVector, bool colored)
    {
        Ball ballToThrow = _SpawnBall();

        if (ballToThrow == null)
            return;

        _ready = false;
        _ballCollection.Add(ballToThrow);
        ballToThrow.Throw(throwVector,colored);
    }
    public List<TrajectoryData> CollectTrajecoryData()
    {
        if (!_ready)
            return null;

        List<TrajectoryData> ballData = new List<TrajectoryData>();

        int i = 0;
        _ballCollection.ForEach(b => ballData.Add(new TrajectoryData(_directionBuffer[i++],b.trajectory)));

        _ballCollection.ForEach(b =>{
            b.gameObject.SetActive(false);
            b.Refresh();
        });

        _ballCollection.Clear();
        _directionBuffer.Clear();
        return ballData;
    }

    public bool IsReady()
    {
        return _ready;
    }
}
