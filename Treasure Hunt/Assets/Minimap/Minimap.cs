﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

    public Transform spieler;
    Light pixelLight;


    void LateUpdate () {

        Vector3 newPosition = spieler.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        //Rotation der Minimap
        //transform.rotation = Quaternion.Euler(90f, spieler.eulerAngles.y, 0f);
	}

 
    void OnPreCull()
    {
        
    }

    private void OnPreRender()
    {
        RenderSettings.ambientLight = Color.white;
        pixelLight.enabled = true;
    }

    void OnPostRender()
    {
        
    }

}
