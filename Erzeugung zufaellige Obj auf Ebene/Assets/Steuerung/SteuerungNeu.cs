using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteuerungNeu : MonoBehaviour {

    public Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("w"))
        {
            Debug.Log("Ich wurde gedrückt");


        }
        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(new Vector3(0, 0, 10) * Time.deltaTime, ForceMode.VelocityChange);


        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddForce(new Vector3(0, 0, -10) * Time.deltaTime, ForceMode.VelocityChange);

        }
        //Bewegung nach rechts
        else if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(new Vector3(10, 0, 0) * Time.deltaTime, ForceMode.VelocityChange);
        }
        //Bewegung nach links
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(new Vector3(-10, 0, 0) * Time.deltaTime, ForceMode.VelocityChange);
        }
    }
}
