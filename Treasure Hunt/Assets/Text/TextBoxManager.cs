using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {
    public GameObject textBox;

    public Text meinText;

    public Queue<string> textLines;

    public int aktuelleZeile;
    public int endeZeile;

    public GameObject player;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<GameObject>();
        
	}

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            aktuelleZeile += 1;
        }
        if(aktuelleZeile > endeZeile)
        {
            textBox.SetActive(false);
        }
    }

}
