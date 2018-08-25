using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuerCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("Collisionobjekt: " + collision);
            Vector3 aktuellePosition = this.transform.position;
            this.transform.position = new Vector3(aktuellePosition.x + 2, aktuellePosition. y, aktuellePosition.z);
        }
    }

}
