using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Interaktion : MonoBehaviour {
    public Texture2D kreuz;
    // Use this for initialization

    int klicknum = 0;
    public GameObject[] geklickt;

    void Start () {
        geklickt = new GameObject[2];
    }


    private void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 16, 16), kreuz);
    }




    // Update is called once per frame
    void Update () {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width /2, Screen.height /2));

        if(Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
                if (hit.collider.gameObject.tag == "stein")
                {
                    ++klicknum;
                    GameObject stein = hit.collider.gameObject;
                    
                    if (klicknum == 1 || klicknum == 2)
                    {
                        if (klicknum == 1)
                        {
                            geklickt[0] = stein;
                            stein.transform.position = new Vector3(stein.transform.position.x, stein.transform.position.y, -0.8f);
                        }
                        if (klicknum == 2)
                        {
                            geklickt[1] = stein;
                            stein.transform.position = new Vector3(stein.transform.position.x, stein.transform.position.y, -0.8f);
                            klicknum = 0;
                        }
                        //Bug "ein Würfel kann in beide Plätze abgespeichert werden, sodass nur dieser verschwindet" beheben
                        if (geklickt[0].GetComponent<Renderer>().material.color == geklickt[1].GetComponent<Renderer>().material.color)
                        {
                            Destroy(geklickt[0]);
                            Destroy(geklickt[1]);
                        }
                        if (geklickt[0].GetComponent<Renderer>().material.color != geklickt[1].GetComponent<Renderer>().material.color)
                        {
                            geklickt[0].transform.position = new Vector3(geklickt[0].transform.position.x, geklickt[0].transform.position.y, 0f);
                            geklickt[1].transform.position = new Vector3(geklickt[1].transform.position.x, geklickt[1].transform.position.y, 0f);
                            Array.Clear(geklickt, 0, 2);
                        }
                    }
                    else
                    {
                        
                        
                    }
                    
                }
            }
        }

	}
}
