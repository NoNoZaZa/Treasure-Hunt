using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaktion : MonoBehaviour {
    public Texture2D kreuz;
	// Use this for initialization
	void Start () {
		
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
                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
        }

	}
}
