using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMovement : MonoBehaviour {
    
    GameObject emptySlot;
    float xtemp;
    float ytemp;

    void Start()
    {
        emptySlot = GameObject.Find("empty");
    }

    //Anklicken der Puzzlesteine mit Maus teilweise schwierig, wenn der Cursor nicht auf der Mitte des Puzzlesteins liegt...
        private void OnMouseUp()
    {
        if (Vector3.Distance(transform.position, emptySlot.transform.position) == 1)
        {
            xtemp = transform.position.x;
            ytemp = transform.position.y;
            this.transform.position = new Vector3(emptySlot.transform.position.x, emptySlot.transform.position.y, 5f);
            emptySlot.transform.position = new Vector3(xtemp, ytemp, 5f);
        }



    }
}
