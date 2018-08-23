using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

    public Transform spieler;


    void LateUpdate () {

        Vector3 newPosition = spieler.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        //Rotation der Minimap
        //transform.rotation = Quaternion.Euler(90f, spieler.eulerAngles.y, 0f);
	}



    private void OnPreRender()
    {
        RenderSettings.ambientLight = Color.white;
    }

    void OnPostRender()
    {
        RenderSettings.ambientLight = Color.black;
    }

}
