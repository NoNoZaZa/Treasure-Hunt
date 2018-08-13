using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz4 : MonoBehaviour {
    public GameObject drehrad1, drehrad2, drehrad3;
    public Vector3 groesse = new Vector3(0.8f, 0.8f, 0.8f);
    public Vector3 cubePos = new Vector3(2f, 0f, 3f);

    // Use this for initialization
    void Start()
    {
        GameObject rad1 = Instantiate(drehrad1, cubePos, Quaternion.identity);
        if (!rad1.activeInHierarchy) rad1.SetActive(true);
        GameObject rad2 = Instantiate(drehrad2, cubePos, Quaternion.identity);
        if (!rad2.activeInHierarchy) rad2.SetActive(true);
        GameObject rad3 = Instantiate(drehrad3, cubePos, Quaternion.identity);
        if (!rad3.activeInHierarchy) rad3.SetActive(true);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
