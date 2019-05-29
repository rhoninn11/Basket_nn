using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public float cameraSensitivity = 70;
    public float movementSpeed = 5;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private bool IsMoving = false;


    void Update()
    {
        if (IsMoving)
        {
            rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
            rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, -90, 90);

            transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

            // var positionDelta = transform.forward * movementSpeed * Input.GetAxisRaw("Vertical") * Time.deltaTime;
            // Debug.Log(Input.GetAxis("Vertical"));
            // transform.position += positionDelta;
            // transform.position += transform.right * movementSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime; 
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            IsMoving = !IsMoving;
        }
    }

    public void MoveUp()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    public void MoveDown()
    {
        transform.position -= transform.forward * movementSpeed * Time.deltaTime;
    }
    public void MoveRight()
    {
        transform.position += transform.right * movementSpeed * Time.deltaTime;
    }
    public void MoveLeft()
    {
        transform.position -= transform.right * movementSpeed * Time.deltaTime;
    }
}