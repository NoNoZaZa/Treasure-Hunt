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

        private void OnMouseUp()
    {
        if (Vector3.Distance(transform.position, emptySlot.transform.position) == 1)
        {
            xtemp = transform.position.x;
            ytemp = transform.position.y;
            this.transform.Translate(emptySlot.transform.position.x, emptySlot.transform.position.y, 5f);
            emptySlot.transform.Translate(xtemp, ytemp, 5f);
        }



    }
}
