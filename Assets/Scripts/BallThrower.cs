using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallThrower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ballPrefab;
    private List<Ball> _ballCollection = new List<Ball>();
    private bool _allThrowsPerformed = false;

    private Vector3 _GetThrowPosition()
    {
        Vector3 heightOffset = new Vector3(0, 0.94f, 0);
        Vector3 throwPoint = this.transform.position + heightOffset;

        return throwPoint;
    }

    public void ThrowABall(Vector3 throwVector)
    {
        Ball ballToThrow = _SpawnBall();

        if (ballToThrow == null)
            return;

        ballToThrow.Throw(throwVector);
        _allThrowsPerformed = false;
        _ballCollection.Add(ballToThrow);
    }
    public VSDisct CollectBallsTrajecory(){
        VSDisct ballData = new VSDisct();

        for(int i = 0; i < _ballCollection.Count; i++)
            ballData.vSDict.Add(i,new VS(_ballCollection[i].trajectory.ToArray()));

        foreach (var ball in _ballCollection)
            Destroy(ball);

        _ballCollection = new List<Ball>();
        return ballData;
    }

    private Ball _SpawnBall(){
        if (ballPrefab == null)
            return null;

        GameObject ballObject = Instantiate(ballPrefab, this._GetThrowPosition(), Quaternion.identity);
        ballObject.layer = 9;

        return ballObject.GetComponent<Ball>();
    }

    private void _CheckingAllBallExpired()
    {
       _allThrowsPerformed = _ballCollection.TrueForAll(b => b.IsLiveTimeExpired());
    }

    void Update()
    {
        _CheckingAllBallExpired();
    }
}
