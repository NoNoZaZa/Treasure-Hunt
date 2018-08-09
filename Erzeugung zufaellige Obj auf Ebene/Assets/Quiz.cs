using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour {

    public Texture m_MainTexture;
    Renderer m_Renderer;
    public GameObject cubegross;

    // Use this for initialization
    void Start () {    
        cubegross = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubegross.transform.position = new Vector3(10, 0.8F, 10);
        cubegross.transform.localScale += new Vector3(5.0F, 2.0F, 0.1F);
        
        cubegross.GetComponent<Renderer>().material.mainTexture = m_MainTexture;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
