using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

    public Transform spieler;

    //Quelle des Codes in LateUpdate/ Zur allgemeinen Erstellung der Minimap: https://www.youtube.com/watch?v=28JTTXqMvOU
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
