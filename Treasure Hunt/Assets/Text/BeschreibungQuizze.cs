using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeschreibungQuizze : MonoBehaviour {
    //public Text BeschreibungQuiz1;
    public TextAsset textfile;
    //public Vector3 posFig;
    //public GameObject fig;
    //public RoomGeneration room;
    public string[] textLines;

    // Use this for initialization
    void Start () {
        if(textfile != null)
        {
            textLines = (textfile.text.Split('\n'));
        }
        //BeschreibungQuiz1.enabled = false;
	}
	
	// Update is called once per frame
	//void Update () {
 //       //Anzeigen();
	//}
    //void Anzeigen()
    //{
        
    //    posFig = fig.transform.position;
         
    //}
}
