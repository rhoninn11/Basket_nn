using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    Camera camReference;
    public Collider cd;

    void Start()
    {
        camReference = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(!Input.GetButton("Fire1"))
            return;

        Ray cameraRay = camReference.ScreenPointToRay(Input.mousePosition);
        
        if(cd  == null)
            return;

        RaycastHit info;
        
        if(cd.Raycast(cameraRay, out info, 300)){
            Debug.Log("wkazano boxa");
        }
    }
}
