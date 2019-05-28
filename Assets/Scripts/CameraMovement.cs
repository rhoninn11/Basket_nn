using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public float cameraSensitivity = 90;
    public float movementSpeed = 10;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private bool IsMoving = true;


    void Update()
    {
        if (IsMoving)
        {
            rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
            rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, -90, 90);

            transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);


            transform.position += transform.forward * movementSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
            transform.position += transform.right * movementSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            IsMoving = !IsMoving;
        }
    }
}