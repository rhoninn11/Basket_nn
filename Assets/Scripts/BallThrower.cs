using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallThrower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ballPrefab;
    private List<Ball> ballCollection;
    private bool hasBallsPerformScoreCalculation = false;
    public int throwCount;

    public BallThrower()
    {
        ballCollection = new List<Ball>();
    }
    public Vector3 GetThrowPosition()
    {
        Vector3 heightOffset = new Vector3(0, 0.94f, 0);
        Vector3 throwPoint = this.transform.position + heightOffset;

        return throwPoint;
    }

    public void ThrowABall(Vector3 throwVector, BallTarget target)
    {

        if (ballPrefab == null)
            return;

        GameObject ballObject = Instantiate(ballPrefab, this.GetThrowPosition(), Quaternion.identity);
        ballObject.layer = 9;

        Ball ballToThrow = ballObject.GetComponent<Ball>();

        if (ballToThrow == null)
            return;

        ballToThrow.Throw(throwVector,target);
        ballCollection.Add(ballToThrow);
    }

    public void PerformaceSummary()
    {
        if (ballCollection.Count != throwCount)
            return;

        if (ballCollection.TrueForAll(b => b.HasThrowTimePass()))
        {
            float AveragePerformaceScore = 0;
            ballCollection.ForEach(b => AveragePerformaceScore += (float)(b.GetPerformanceScore() / 10.0));
            hasBallsPerformScoreCalculation = true;
        }
    }

    void Update()
    {
        if (!hasBallsPerformScoreCalculation)
            PerformaceSummary();
    }
}
