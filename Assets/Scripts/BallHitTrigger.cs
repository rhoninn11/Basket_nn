using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHitTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){

        Ball interuptor = (Ball)other.gameObject.GetComponent(typeof(Ball));

        if(interuptor != null){
            interuptor.Hit();
            Debug.Log("Hit");
        }
    }
}
