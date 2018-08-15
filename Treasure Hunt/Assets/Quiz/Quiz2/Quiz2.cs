using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz2 : MonoBehaviour {

    public GameObject cube, druckplatte, player;
    public Vector3 groesse = new Vector3(0.8f, 0.8f, 0.8f);
    public float holdDistance = 1f;
    public float moveDelay = 2f;

    private Vector3 target = Vector3.zero;

    // Use this for initialization
    void Start () {
        //erzeugung();
        cube = Instantiate(cube, transform.position, Quaternion.identity);
        cube.transform.parent = this.transform;
        //if (!cubeInstance.activeInHierarchy) cubeInstance.SetActive(true);

        
    }
	
	// Update is called once per frame
	void Update () {
        target = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, holdDistance));

    }


    public void Wearing()
    {
        

        cube.transform.position = Vector3.Lerp(cube.transform.position, target, Time.deltaTime * moveDelay);
        //cube.transform.position = 
        cube.transform.rotation = player.transform.rotation;
    }


    void Erzeugung()
    {
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = groesse;
        cube.AddComponent<Rigidbody>();
        cube.gameObject.GetComponent<Renderer>().material.color = Color.green;
        cube.tag = "hebObj";
        //block.transform.position = ;
        druckplatte = GameObject.CreatePrimitive(PrimitiveType.Cube);
        druckplatte.transform.localScale = new Vector3(1f, 0.25f, 1f);
        druckplatte.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        druckplatte.transform.position = new Vector3(2f, 0f, 3f);
    }

}
