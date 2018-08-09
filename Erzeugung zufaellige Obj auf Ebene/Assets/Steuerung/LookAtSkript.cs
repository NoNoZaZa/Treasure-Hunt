using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtSkript : MonoBehaviour {

    public Transform target;
	// Use this for initialization
	void Start () {
        Vector3 relativePos = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
