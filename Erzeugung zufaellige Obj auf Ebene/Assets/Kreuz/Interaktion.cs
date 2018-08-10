using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                klicknum++;
                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
                if (hit.collider.gameObject.tag == "stein")
                {
                    GameObject stein = hit.collider.gameObject;
                    stein.transform.position = new Vector3(stein.transform.position.x, stein.transform.position.y, -0.8f);
                    if (klicknum == 1 || klicknum == 2)
                    {
                        if (klicknum == 1)
                        {
                            geklickt[0] = stein;
                        }
                        if (klicknum == 2)
                        {
                            geklickt[1] = stein;
                        }
                        if (geklickt[0].GetComponent<Renderer>().material.color == geklickt[1].GetComponent<Renderer>().material.color)
                        {
                            Destroy(geklickt[0]);
                            Destroy(geklickt[1]);
                        }
                    }
                    else
                    {
                        klicknum = 0;
                    }
                    
                }
            }
        }

	}
}
