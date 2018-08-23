using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public int value = 1;
    public int rotationSpeed = 60;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter()
    {
        //Collect-Fkt aufrufen
        GameManager.instance.Collect(value, gameObject);
        //Sound
        AudioSource src = this.GetComponent<AudioSource>();
        src.Play();
    }
}
