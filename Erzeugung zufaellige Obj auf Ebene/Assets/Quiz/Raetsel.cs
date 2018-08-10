using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Raetsel : MonoBehaviour {
    // public Rigidbody rbc;
    public GameObject[,] bloecke;
    public ArrayList liste = new ArrayList();
    public GameObject stein, stein1, stein2, stein3, stein4, stein5, stein6, stein7, stein8,
        stein9, stein10, stein11, stein12, stein13, stein14, stein15, stein16;
    public int i;
    public int j;
    public System.Random random = new System.Random();
    public Vector3 groesse = new Vector3(0.8f,0.8f,0.8f);


    // Use this for initialization

    void Start () {
        
        bloecke = new GameObject[4,4];
        erzeugungObjekte();       
        arrayBefuellen();
        anordnung();
        


    }
	
	// Update is called once per frame
	void Update () {
    }

    void erzeugungObjekte()
    {
        stein1 = GameObject.CreatePrimitive(PrimitiveType.Cube);      
        stein1.transform.localScale = groesse;
        stein1.gameObject.GetComponent<Renderer>().material.color = Color.green;
        stein1.tag = "stein";
        liste.Add(stein1);
       
        stein2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stein2.transform.localScale = groesse;
        stein2.gameObject.GetComponent<Renderer>().material.color = Color.green;
        liste.Add(stein2);
        stein3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stein3.transform.localScale = groesse;
        stein3.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        liste.Add(stein3);
        stein4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stein4.transform.localScale = groesse;
        stein4.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        liste.Add(stein4);
        stein5 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stein5.transform.localScale = groesse;
        stein5.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        liste.Add(stein5);
        stein6 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stein6.transform.localScale = groesse;
        stein6.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        liste.Add(stein6);
        stein7 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stein7.transform.localScale = groesse;
        stein7.gameObject.GetComponent<Renderer>().material.color = Color.red;
        liste.Add(stein7);
        stein8 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stein8.transform.localScale = groesse;
        stein8.gameObject.GetComponent<Renderer>().material.color = Color.red;
        liste.Add(stein8);
        stein9 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stein9.transform.localScale = groesse;
        stein9.gameObject.GetComponent<Renderer>().material.color = Color.black;
        liste.Add(stein9);
        stein10 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stein10.transform.localScale = groesse;
        stein10.gameObject.GetComponent<Renderer>().material.color = Color.black;
        liste.Add(stein10);
        stein11 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stein11.transform.localScale = groesse;
        stein11.gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        liste.Add(stein11);
        stein12 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stein12.transform.localScale = groesse;
        stein12.gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        liste.Add(stein12);
        stein13 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stein13.transform.localScale = groesse;
        stein13.gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        liste.Add(stein13);
        stein14 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stein14.transform.localScale = groesse;
        stein14.gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        liste.Add(stein14);
        stein15 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stein15.transform.localScale = groesse;
        stein15.gameObject.GetComponent<Renderer>().material.color = Color.grey;
        liste.Add(stein15);
        stein16 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stein16.transform.localScale = groesse;
        stein16.gameObject.GetComponent<Renderer>().material.color = Color.grey;
        liste.Add(stein16);
    }


    void arrayBefuellen()
    {
        
        for(i=0; i <4; i++)
        {
            for (j = 0; j < 4; j++)
            {
                arrayRandomzuweisen();
                Debug.Log("Zahl");
            }
        }

    }

    void anordnung()
    {
        for(i = 0; i<4; i++)
        {
            for (j = 0; j < 4; j++)
            {
                bloecke[i, j].transform.position = new Vector3(i+5, j, 0);
                Debug.Log("Anordnung");
            }
        }
    }

    void arrayRandomzuweisen()
    {
        int zahl = random.Next(0, liste.Count);
        ((GameObject)liste[zahl]).GetComponent<Rigidbody>();
        ((GameObject)liste[zahl]).tag = "stein";
        bloecke[i, j] = (GameObject)liste[zahl];
        liste.RemoveAt(zahl);
    }
}
