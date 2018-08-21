using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeschreibungQuiz : MonoBehaviour {
    public Text BeschrQuiz3;
    
	// Use this for initialization
	void Start () {
        BeschrQuiz3.enabled = false;
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        BeschrQuiz3.enabled = true;
       
    }
}
