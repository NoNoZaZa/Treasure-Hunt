using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raetsel : MonoBehaviour {
        Mesh kurve;
        List<Vector3> points;
        List<int> dreieck;
    // Use this for initialization

    void Start () {
        GetComponent<MeshFilter>().mesh = kurve;
        kurve.vertices = points.ToArray();
        kurve.triangles = dreieck.ToArray();
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
