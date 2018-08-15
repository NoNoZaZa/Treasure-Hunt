using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public Rigidbody rb;

    private float x = 0.0f;
    private float y = 0.0f;

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 1F;
    public float sensitivityY = 1F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationX = 0F;
    float rotationY = 0F;
    Quaternion originalRotation;


    void Update()
    {
        rb = GetComponent<Rigidbody>();

        if (axes == RotationAxes.MouseXAndY)
        {
            // Read the mouse input axis
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);
            transform.localRotation = originalRotation * xQuaternion * yQuaternion;
        }
        else if (axes == RotationAxes.MouseX)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = originalRotation * xQuaternion;
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY, Vector3.right);
            transform.localRotation = originalRotation * yQuaternion;
        }


    

    // Update is called once per frame
        Vector3 pos = transform.position;

        //Laufen Rechts links vor zurück

        if (Input.GetKey(KeyCode.W))
        {

            pos.z += 2.5f * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.S))
        {
            pos.z -= 2.5f * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= 2.5f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += 2.5f * Time.deltaTime;
        }

        transform.position = pos;
    }
    void Start()
    { var angles = transform.eulerAngles;
        x = angles.x;
        y = angles.y;

        CalcPos();


        // Make the rigid body not change rotation
        if (rb)
            rb.freezeRotation = true;
        originalRotation = transform.localRotation;
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }

        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }


    void CalcPos() { 
    transform.rotation = Quaternion.Euler(y, x, 0);
        }
}