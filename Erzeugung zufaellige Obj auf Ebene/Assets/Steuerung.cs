using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steuerung : MonoBehaviour
{
    public Transform target;
    public float distance = 8.0f;
    public float xSpeed = 200.0f;
    public float ySpeed = 120.0f;
    public float yMinLimit = -20;
    public float yMaxLimit = 80;
    public float distMinLimit = 6.0f;
    public float distMaxLimit = 14.0f;
    public float wheelSpeed = 200.0f;

    private float x = 0.0f;
    private float y = 0.0f;

    //public Rigidbody rb;



    // Use this for initialization
    void Start()
    {
       // rb = GetComponent<Rigidbody>();
        var angles = transform.eulerAngles;
        x = angles.x;
        y = angles.y;

        CalcPos();
        

    }

    // Update is called once per frame
    void Update()
    {
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




        //Drehen

        distance = Input.GetAxis("Mouse ScrollWheel") * wheelSpeed * Time.deltaTime;

        distance = Mathf.Clamp(distance, distMinLimit, distMaxLimit);
        if (Input.GetMouseButton(0))
        {
            x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
            y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

            x = ClampAngle(x, 0, 0);
            y = ClampAngle(y, yMinLimit, yMaxLimit);


        }
        CalcPos();


    }

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }

        if (angle > 360)
        {
            angle -= 360;
        }

        if (min != 0 && max != 0)
        {
            angle = Mathf.Clamp(angle, min, max);
        }

        return angle;
    }

    void CalcPos()
    {

        Vector3 relativePos = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos);


        transform.rotation = Quaternion.Euler(y, x, 0);
       // transform.position = Quaternion.Euler(y,x, 0) * new Vector3 (0.0f, 0.0f, -distance);

    }
}



