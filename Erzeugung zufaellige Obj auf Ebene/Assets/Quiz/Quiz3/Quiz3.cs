using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz3 : MonoBehaviour {

    public float minGeschw = 1f;
    public float maxGeschw = 6f;
    private float geschwindigkeit;
    public float grenze = 3f;
   // Use this for initialization

    void Start()
    {
        geschwindigkeit = Random.Range(minGeschw, maxGeschw);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * geschwindigkeit, grenze), transform.position.y, transform.position.z);
        //transform.Translate(Vector3.left* geschwindigkeit * Time.deltaTime);
    }

   
    
}
