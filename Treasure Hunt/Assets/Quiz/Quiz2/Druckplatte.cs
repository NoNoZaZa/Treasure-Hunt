using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Druckplatte : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}


    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.collider.gameObject.tag == "hebObj")
        {
            GameObject hebObj = collision.collider.gameObject;
            Debug.Log("druckplatte");
            this.transform.position = new Vector3( this.transform.position.x, this.transform.position.y - 0.5f, this.transform.position.z);
            Destroy(hebObj);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
