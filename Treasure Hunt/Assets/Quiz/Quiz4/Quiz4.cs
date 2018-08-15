using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz4 : MonoBehaviour {
    public GameObject drehrad1, drehrad2, drehrad3;
    public Vector3 groesse = new Vector3(0.8f, 0.8f, 0.8f);
    Vector3 ecke11, ecke23, ecke34;

    // Use this for initialization
    void Start()
    {
        GameObject rad1 = Instantiate(drehrad1, drehrad1.transform.position, Quaternion.identity);
        if (!rad1.activeInHierarchy) rad1.SetActive(true);
        GameObject rad2 = Instantiate(drehrad2, drehrad2.transform.position, Quaternion.identity);
        if (!rad2.activeInHierarchy) rad2.SetActive(true);
        GameObject rad3 = Instantiate(drehrad3, drehrad3.transform.position, Quaternion.identity);
        if (!rad3.activeInHierarchy) rad3.SetActive(true);
        symboleZuewisen();
        vergleichen();
    }

    void symboleZuewisen()
    {
        Mesh mesh1 = drehrad1.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices1 = mesh1.vertices;
        ecke11 = vertices1[0];

        Mesh mesh2 = drehrad1.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices2 = mesh2.vertices;
        ecke11 = vertices2[2];

        Mesh mesh3 = drehrad1.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices3 = mesh3.vertices;
        ecke34 = vertices3[3];

    }
    void vergleichen()
    {
        if (ecke11 == ecke23 && ecke11 == ecke34)
        {
            Destroy(drehrad1);
            Destroy(drehrad2);
            Destroy(drehrad3);
        }
    }


        // Update is called once per frame
        void Update () {
		
	}
}
