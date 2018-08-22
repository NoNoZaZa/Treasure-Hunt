using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMovement : MonoBehaviour {
    
    GameObject emptySlot;
    float xtemp;
    float ytemp;
    private Quiz4 quiz4;
    public GameObject[] steinPos;

    void Start()
    {
        quiz4 = GameObject.FindGameObjectWithTag("Quiz4").GetComponent<Quiz4>();
        emptySlot = GameObject.Find("empty");
        steinPos = new GameObject[16];
        steinPos = quiz4.steinPos;
    }

    //Anklicken der Puzzlesteine mit Maus teilweise schwierig, wenn der Cursor nicht auf der Mitte des Puzzlesteins liegt...
        private void OnMouseUp()
    {
        if (Vector3.Distance(transform.position, emptySlot.transform.position) == 1)
        {
            xtemp = transform.position.x;
            ytemp = transform.position.y;
            this.transform.position = new Vector3(emptySlot.transform.position.x, emptySlot.transform.position.y, 7f);
            int c = System.Array.IndexOf(steinPos, gameObject);
            Debug.Log(c);
            emptySlot.transform.position = new Vector3(xtemp, ytemp, 7f);
            int e = System.Array.IndexOf(steinPos, emptySlot);
            Debug.Log("E ist " + e);
            GameObject tempS = steinPos[c];
            steinPos[c] = emptySlot;
            steinPos[e] = tempS;
        }

    }
}
