using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz2 : MonoBehaviour {

    public GameObject block, druckplatte;
    public Vector3 groesse = new Vector3(0.8f, 0.8f, 0.8f);
    public Vector3 cubePos = new Vector3(-2f, 0f, -3f);

    // Use this for initialization
    void Start () {
        //erzeugung();
        GameObject cubeInstance = Instantiate(block, cubePos, Quaternion.identity);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void erzeugung()
    {
        block = GameObject.CreatePrimitive(PrimitiveType.Cube);
        block.transform.localScale = groesse;
        block.AddComponent<Rigidbody>();
        block.gameObject.GetComponent<Renderer>().material.color = Color.green;
        block.tag = "hebObj";
        //block.transform.position = ;
        druckplatte = GameObject.CreatePrimitive(PrimitiveType.Cube);
        druckplatte.transform.localScale = new Vector3(1f, 0.25f, 1f);
        druckplatte.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        druckplatte.transform.position = new Vector3(2f, 0f, 3f);
    }

}
