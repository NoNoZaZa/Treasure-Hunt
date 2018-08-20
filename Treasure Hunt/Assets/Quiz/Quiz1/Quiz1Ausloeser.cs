using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz1Ausloeser : MonoBehaviour {

    public GameObject quiz1Cube;
    //public GameObject quiz1ausloeser;

    // Use this for initialization
    void Start () {
        }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Destroy(this.gameObject);
        quiz1Cube.SetActive(true);
    }
}
