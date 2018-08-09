using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quizausloeser : MonoBehaviour
{

    public GameObject wand;
    // Use this for initialization
    void Start()
    {
        //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cube.transform.position = new Vector3(0.0F, 3.5F, 4.5F);
        //cube.transform.localScale += new Vector3(0.2F, 0.2F, 0.2F);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Debug.Log("Collide!");
        wand.GetComponent<Renderer>().material.color = Color.red;
        Destroy(this.gameObject);
    }

}
