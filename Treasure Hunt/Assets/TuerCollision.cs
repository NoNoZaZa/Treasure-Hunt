using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuerCollision : MonoBehaviour {

    public bool unlockable;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //public void ToggleUnlockable() {
    //    if (unlockable)
    //    {
    //        unlockable = false;
    //    }
    //    else {
    //        unlockable = true;
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            //Debug.Log("Collisionobjekt: " + collision);
            Vector3 aktuellePosition = this.transform.position;

            if (unlockable) {
                this.transform.position = new Vector3(aktuellePosition.x + 2, aktuellePosition.y, aktuellePosition.z);

            }
            Debug.Log("unlockable: " + unlockable);
        }
    }

}
