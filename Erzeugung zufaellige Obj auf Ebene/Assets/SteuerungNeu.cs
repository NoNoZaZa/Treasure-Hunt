using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteuerungNeu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;

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
        if(Input.GetKey(KeyCode.D))
        {
            pos.x += 2.5f * Time.deltaTime;
        }
        transform.position = pos;
	}
}
