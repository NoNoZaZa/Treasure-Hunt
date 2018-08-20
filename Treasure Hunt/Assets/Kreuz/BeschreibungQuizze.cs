using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeschreibungQuizze : MonoBehaviour {
    public Text BeschreibungQuiz1;
    public Vector3 posFig;
    public GameObject fig;
    public RoomGeneration room;

    // Use this for initialization
    void Start () {
        BeschreibungQuiz1.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        Anzeigen();
	}
    void Anzeigen()
    {
        
        posFig = fig.transform.position;
         
    }
}
