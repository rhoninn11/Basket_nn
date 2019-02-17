using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallThrower))]
public class Player : MonoBehaviour
{
    public float speed = 0.11f;
    public float throwForce = 5;
    BallTarget target;

    // Update is called once per frame
    void Update()
    {
        Walk();
        PerformThrow();
    }

    void Walk()
    {
        float horizontalDelta = Input.GetAxis("Horizontal") * speed;
        float verticalDelta = Input.GetAxis("Vertical") * speed;

        Vector3 positionDelta = new Vector3(horizontalDelta, 0, verticalDelta);
        this.transform.Translate(positionDelta);
    }

    void PerformThrow()
    {
        if (Input.GetAxis("Jump") == 1)
            GetComponent<BallThrower>().ThrowABall(new Vector3(0, 1, 1).normalized * throwForce,target);
    }

}
