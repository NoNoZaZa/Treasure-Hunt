using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMovement : MonoBehaviour {

    public Puzzle puzzle;
    GameObject emptySlot;
    Transform slot;
    float xtemp;
    float ytemp;

    void Start()
    {
        emptySlot = GameObject.Find("empty");
    }

        private void OnMouseUp()
    {
        if (Vector3.Distance(transform.position, slot.position) == 1)
        {
            xtemp = transform.position.x;
            ytemp = transform.position.y;
            //this.transform.position.x = slot.position.x;
            //this.transform.position.y = slot.position.y;
            //slot.position.x = xtemp;
            //slot.position.y = ytemp;
        }



    }
}
