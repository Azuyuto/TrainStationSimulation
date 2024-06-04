using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamera : MonoBehaviour
{

    public float normalSpeed = 0.05f;
    public int multiplySpeed = 3;
    public int mouseSpeed = 1;

    private Vector3 positionVector;
    private Vector3 rotationVector;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Position
        positionVector.x = Input.GetAxis("Horizontal");
        positionVector.y = Input.GetAxis("Updown");
        positionVector.z = Input.GetAxis("Vertical");
        positionVector *= normalSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            positionVector *= multiplySpeed;
        }

        transform.Translate(positionVector);
        //transform.Translate(0, positionVector.y, 0, Space.World);

        // Rotation
        //transform.Rotate(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        rotationVector = transform.rotation.eulerAngles;
        rotationVector.x -= Input.GetAxis("Mouse Y") * mouseSpeed;
        rotationVector.y += Input.GetAxis("Mouse X") * mouseSpeed;

        // Blockade for 90 degree view
        if (rotationVector.x < 180 && rotationVector.x > 0)
        {
            rotationVector.x = Mathf.Clamp(rotationVector.x, 0, 90);
        }
        else if (rotationVector.x < 360 && rotationVector.x > 180)
        {
            rotationVector.x = Mathf.Clamp(rotationVector.x, 270, 360);
        }
        transform.rotation = Quaternion.Euler(rotationVector.x, rotationVector.y, 0);

    }
}
