using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Interaktion : MonoBehaviour {
    private bool IsHolding = false;
    private GameObject obj;
    private GameObject objekt3;

    public Texture2D kreuz;
    // Use this for initialization

    int klicknum = 0;
    public GameObject[] geklickt;
    public Transform pickup;

    void Start()
    {
        geklickt = new GameObject[2];
    }


    private void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 16, 16), kreuz);
    }




    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {

                //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
                
                //Rätsel1 (Steinplatten eindrücken und Paare finden)
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

                //Quiz2 (Objekt aufheben & auf Druckplatte legen)
                if(hit.collider.gameObject.tag == "hebObj")
                {
                    IsHolding = true;
                    Debug.Log("NOT USING GRAVITY!!!!");
                    obj = hit.collider.gameObject;
                    obj.GetComponent<Rigidbody>().useGravity = false;
                    obj.GetComponent<Rigidbody>().isKinematic = true;
                    //obj.transform.position = new Vector3 (Screen.width / 2, Screen.height / 2, 0.7f);
                    obj.transform.position = pickup.position;
                    obj.transform.parent = GameObject.Find("Spieler").transform;
                    obj.transform.parent = GameObject.Find("Main Camera").transform;
                }

                //Quiz3 (Objekte anklicken und damit zerstören)

                if (hit.collider.gameObject.tag == "Quiz3")
                    {
                    objekt3 = hit.collider.gameObject;
                    Destroy(objekt3);
                    }

                

            }
            

        }
        if (Input.GetMouseButtonDown(1))
        {
            if (hit.collider.gameObject.tag == "hebObj")
            {
                //Debug.Log("USING GRAVITY");
                //obj = hit.collider.gameObject;
                //obj.transform.parent = null;
                //obj.GetComponent<Rigidbody>().useGravity = true;

            }
            if (IsHolding)
            {
                if (!obj) return;
                obj.transform.parent = null;
                obj.GetComponent<Rigidbody>().useGravity = true;
                obj.GetComponent<Rigidbody>().isKinematic = false;
            }
        }


        if (!obj) return;
        Debug.Log(obj.GetComponent<Rigidbody>().useGravity);


    }


}

