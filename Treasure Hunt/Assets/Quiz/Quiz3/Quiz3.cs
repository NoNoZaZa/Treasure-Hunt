using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz3 : MonoBehaviour {

    public float minGeschw = 1f;
    public float maxGeschw = 6f;
    private float geschwindigkeit;
    public float grenze = 3f;
    public float offset;
    //private float groesse = 0.8f;
    public List<GameObject> cubeListe;
    //public GameObject cubeForm;
    // Use this for initialization



    void Start()
    {
        //ErzeugungCubes();
        //AnordnungListe();
        geschwindigkeit = Random.Range(minGeschw, maxGeschw);
        
    }

    // Update is called once per frame
    void Update()
    {
        //CubesBewegen();
        transform.position = new Vector3(Mathf.PingPong(Time.time * geschwindigkeit, grenze) + offset, transform.position.y, transform.position.z);

    }

        //void ErzeugungCubes()
    //{
    //    for (int i = 0; i < 6; i++)
    //    {
    //        GameObject cube = Instantiate(cubeForm, transform.position, transform.rotation);
    //        cube.transform.localScale = new Vector3(groesse, groesse, groesse);
    //        cubeListe.Add(cube);
    //    }
    //}

    //void AnordnungListe()
    //{
    //    for(int j =0; j< cubeListe.Count; j++)
    //    {
    //        cubeListe[j].transform.Translate(0, j, 0);
    //    }
    //}

    //void CubesBewegen()
    // {  
    //foreach(GameObject element in cubeListe) { 
    //  transform.position = new Vector3(
    //  Mathf.PingPong(Time.time * geschwindigkeit, grenze) + offset, transform.position.y, transform.position.z);
    //      Debug.Log("Funktioniert");

    //  }
    //         //transform.Translate(Vector3.left* geschwindigkeit * Time.deltaTime);
    //     for(int c=0; c < cubeListe.Count; c++)
    //     {
    //         cubeListe[c].transform.position = new Vector3(
    //         Mathf.PingPong(Time.time * geschwindigkeit, grenze) + offset, transform.position.y, transform.position.z);
    //         Debug.Log(c);
    //     }
    // }

}
