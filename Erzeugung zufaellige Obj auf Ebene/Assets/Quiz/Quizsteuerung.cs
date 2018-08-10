using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quizsteuerung : MonoBehaviour {

    Texture texture1;
    Texture texture2;
    
    // Use this for initialization
    void Start () {
        anklicken();
       


    }

    // Update is called once per frame
    void Update () {
		
	}

    //void texturenVergleichen()
    //{
    //    if (texture1.Material.GetTexture() == texture2.Material.GetTexture() )
    //    {



    //    }


    //}

    void anklicken()
    {
        RaycastHit auswaehlen;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));


        if (Physics.Raycast(ray, out auswaehlen))
        {
            if (Input.GetMouseButtonDown(0))
            {
                auswaehlen.collider.gameObject.GetComponent<Renderer>().material.color = Color.blue;
            }
        }
    }
}
